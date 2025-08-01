using System;
using System.Timers;
using System.Windows;
using System.Windows.Controls;

using DiscordRPC;
using DiscordRPC.Logging;

using Hardcodet.Wpf.TaskbarNotification;

using SK_DiscordRPC.Util;
using SK_DiscordRPC.Data;
using SK_DiscordRPC.Framework;

namespace SK_DiscordRPC
{
    public partial class AppWindow : Window
    {
        public static DiscordRpcClient discordClient;
        private string DISCORD_CLIENT_ID = "626524043209867274";

        private const int CHECK_INTERVAL_SECONDS = 5;
        private Timer presenceTicker = new Timer(CHECK_INTERVAL_SECONDS * 1000);
        private Timer gameTicker = new Timer(CHECK_INTERVAL_SECONDS * 1000);

        public static Whereabouts currentWhereabouts = new Whereabouts();

        public static TaskbarIcon taskbarIcon;

        public AppWindow ()
        {
            InitializeComponent();
            taskbarIcon = (TaskbarIcon) FindName("TrayIcon");
            taskbarIcon.ShowBalloonTip(
                "Now running in tray bar", "You can configure or exit the module there.", BalloonIcon.None);

            if (Properties.Settings.Default.ShowKnight)
            {
                ShowKnightItem = (MenuItem) FindName("ShowKnightItem");
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

        public void SetupRPC ()
        {
            discordClient = new DiscordRpcClient(DISCORD_CLIENT_ID);
            discordClient.Logger = new ConsoleLogger() { Level = LogLevel.Warning };
            discordClient.OnReady += (sender, e) =>
            {
                Console.WriteLine("[skdiscord-rpc] ready received for: {0}", e.User.Username);
            };
            discordClient.OnPresenceUpdate += (sender, e) =>
            {
                Console.WriteLine("[skdiscord-rpc] updated: {0}", e.Presence);
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

            if (gameTicker.Enabled) { gameTicker.Dispose(); }
            InitPresenceTicker();
        }

        public void InitGameTicker ()
        {
            gameTicker.Elapsed += OnGameTimedEvent;
            gameTicker.Enabled = true;
        }

        public void InitPresenceTicker ()
        {
            presenceTicker.Elapsed += OnPresenceTimedEvent;
            presenceTicker.Enabled = true;
        }

        private void OnGameTimedEvent (object sender, EventArgs e)
        {
            if (Parser.isGameRunning())
            {
                SetupRPC();
            }
        }

        private void OnPresenceTimedEvent (object sender, EventArgs e)
        {
            if (Parser.isGameRunning())
            {
                ClientPresence.update();
            }
            else
            {
                shutdown();
            }
        }

        private void Exit_Click (object sender, RoutedEventArgs e)
        {
            shutdown();
        }

        private void ShowKnight_Click (object sender, RoutedEventArgs e)
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

        private void shutdown () { 
            // Dispose of the presence ticker.
            presenceTicker.Dispose();

            // Dispose of the Discord Client object.
            discordClient.Deinitialize();
            discordClient.Dispose();

            // Save any settings that have been changed.
            Properties.Settings.Default.Save();

            // Hide the taskbar icon and dispose of it.
            // For some reason, the icon will sometimes linger in the tray bar. God knows why.
            // If you happen to have any leads, please feel free to open a pull request.
            taskbarIcon.Visibility = Visibility.Hidden;
            taskbarIcon.Icon.Dispose();
            taskbarIcon.Dispose();

            // Finally close the application.
            Close();
            Environment.Exit(0);
        }

    }
}
