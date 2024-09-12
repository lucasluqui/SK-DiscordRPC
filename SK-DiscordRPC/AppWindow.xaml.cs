using System;
using System.Timers;
using System.Windows;
using DiscordRPC;
using DiscordRPC.Logging;
using Hardcodet.Wpf.TaskbarNotification;
using SK_DiscordRPC.Util;
using SK_DiscordRPC.Data;
using SK_DiscordRPC.Framework;
using System.Windows.Controls;

namespace SK_DiscordRPC
{
    public partial class AppWindow : Window

    {
        public static TaskbarIcon tb;

        public static DiscordRpcClient discordClient;
        private string DISCORD_CLIENT_ID = "626524043209867274";

        private const int CHECK_INTERVAL_SECONDS = 5;
        private Timer presenceTicker = new Timer(CHECK_INTERVAL_SECONDS * 1000);
        private Timer gameTicker = new Timer(CHECK_INTERVAL_SECONDS * 1000);

        public static Whereabout curWhere = new Whereabout();

        public AppWindow()
        {
            InitializeComponent();
            tb = (TaskbarIcon)FindName("TrayIcon");
            tb.ShowBalloonTip("Now running in tray bar", "You can configure or exit the module there.", BalloonIcon.None);

            if (Properties.Settings.Default.ShowKnight)
            {
                ShowKnightItem = (MenuItem)FindName("ShowKnightItem");
                ShowKnightItem.IsChecked = true;
            }

            if (Parser.isGameRunning())
            {
                SetupRPC();
            }
            else
            {
                InitGameTicker();
            }
        }

        public void SetupRPC()
        {
            discordClient = new DiscordRpcClient(DISCORD_CLIENT_ID);
            discordClient.Logger = new ConsoleLogger() { Level = LogLevel.Warning };
            discordClient.OnReady += (sender, e) =>
            {
                Console.WriteLine("ready received for: {0}", e.User.Username);
            };
            discordClient.OnPresenceUpdate += (sender, e) =>
            {
                Console.WriteLine("updated: {0}", e.Presence);
            };
            discordClient.Initialize();
            discordClient.SetPresence(new RichPresence()
            {
                Details = "",
                State = "",
                Timestamps = Timestamps.Now,
                Assets = new Assets()
                {
                    LargeImageKey = "",
                    LargeImageText = "",
                    SmallImageKey = "",
                    SmallImageText = ""
                }
            });

            if(gameTicker.Enabled) { gameTicker.Dispose(); }
            InitPresenceTicker();
        }

        public void InitGameTicker()
        {
            gameTicker.Elapsed += OnGameTimedEvent;
            gameTicker.Enabled = true;
        }

        public void InitPresenceTicker()
        {
            presenceTicker.Elapsed += OnPresenceTimedEvent;
            presenceTicker.Enabled = true;
        }

        private void OnGameTimedEvent(object sender, EventArgs e)
        {
            if (Parser.isGameRunning())
            {
                SetupRPC();
            }
        }

        private void OnPresenceTimedEvent(object sender, EventArgs e)
        {
            if (Parser.isGameRunning())
            {
                ClientPresence.update();
            }
            else
            {
                shutdownRoutine();
            }
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            shutdownRoutine();
        }

        private void ShowKnight_Click(object sender, RoutedEventArgs e)
        {
            if (Properties.Settings.Default.ShowKnight)
            {
                Properties.Settings.Default.ShowKnight = false;
                ShowKnightItem.IsChecked = false;
                Properties.Settings.Default.Save();
            }
            else
            {
                Properties.Settings.Default.ShowKnight = true;
                ShowKnightItem.IsChecked = true;
                Properties.Settings.Default.Save();
            }
        }

        private void shutdownRoutine() { 
            presenceTicker.Dispose();

            discordClient.Deinitialize();
            discordClient.Dispose();

            Properties.Settings.Default.Save();

            tb.Visibility = Visibility.Hidden;
            tb.Icon.Dispose();
            tb.Dispose();

            Close();

            Environment.Exit(0);
        }

    }
}
