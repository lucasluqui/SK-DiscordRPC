using System;
using System.IO;
using System.Reflection;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using DiscordRPC;
using DiscordRPC.Logging;
using Hardcodet.Wpf.TaskbarNotification;
using SK_DiscordRPC.Data;
using SK_DiscordRPC.Framework;
using SK_DiscordRPC.Util;

namespace SK_DiscordRPC
{
    public partial class AppWindow : Window
    {
        public static string KL_VERSION = "undefined";

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
            SetupLogging();

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
                Console.WriteLine("[skdiscord-rpc] Detected game running, starting RPC");
                SetupRPC();
            }
            else
            {
                Console.WriteLine("[skdiscord-rpc] Game not running, started ticker");
                InitGameTicker();
            }
        }

        public void SetupLogging ()
        {
            String logFile = System.AppDomain.CurrentDomain.BaseDirectory + "skdiscordrpc.log";
            if (File.Exists(logFile)) 
            {
                File.Delete(logFile);
            }
            var writer = new StreamWriter(logFile) { AutoFlush = true };
            Console.SetOut(writer);
            Console.SetError(writer);
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
            Console.WriteLine("[skdiscord-rpc] Checking for game process...");
            if (Parser.isGameRunning())
            {
                Console.WriteLine("[skdiscord-rpc] Detected game running, starting RPC");
                SetupRPC();
            }
            else 
            {
                Console.WriteLine("[skdiscord-rpc] Game not running yet, checking again next tick");
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
                Console.WriteLine("[skdiscord-rpc] Detected game shutdown, stopping RPC");
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
            Console.WriteLine("[skdiscord-rpc] Starting shutdown process...");

            // Dispose of the presence ticker.
            presenceTicker.Dispose();
            Console.WriteLine("[skdiscord-rpc] Presence ticker disposed.");

            // Save any settings that have been changed.
            Properties.Settings.Default.Save();
            Console.WriteLine("[skdiscord-rpc] Settings saved.");

            // Finally close the application.
            Console.WriteLine("[skdiscord-rpc] Shutting down...");
            Environment.Exit(0);

            // Breakthrough: If you don't do anything below, everything works fine.
            // Why? I don't know. But it does.

            // Clear current presence and dispose of the Discord client object.
            //discordClient.Deinitialize();
            //discordClient.ClearPresence();
            //discordClient.Dispose();
            //Console.WriteLine("[skdiscord-rpc] Discord client deinitialized and disposed.");

            // Save any settings that have been changed.
            //Properties.Settings.Default.Save();
            //Console.WriteLine("[skdiscord-rpc] Settings saved.");

            // Hide the taskbar icon and dispose of it.
            // For some reason, the icon will sometimes linger in the tray bar. God knows why.
            // If you happen to have any leads, please feel free to open a pull request.
            //taskbarIcon.Visibility = Visibility.Hidden;
            //taskbarIcon.Icon.Dispose();
            //taskbarIcon.Dispose();
            //Console.WriteLine("[skdiscord-rpc] Taskbar icon disposed.");

            // Finally close the application.
            //Console.WriteLine("[skdiscord-rpc] Shutting down...");
            //Environment.Exit(0);
        }

    }
}
