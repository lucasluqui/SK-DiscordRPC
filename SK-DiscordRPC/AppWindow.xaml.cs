using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DiscordRPC;
using DiscordRPC.Logging;
using SK_DiscordRPC.Util;
using SK_DiscordRPC.Data;
using SK_DiscordRPC.Framework;

namespace SK_DiscordRPC
{
    public partial class AppWindow : Window

    {
        public static DiscordRpcClient client;
        public static Whereabout curWhere = new Whereabout();
        private const int interval = 5;
        private Timer presenceTicker = new Timer(interval * 1000);
        private Timer gameTicker = new Timer(interval * 1000);
        private string CLIENT_ID = "626524043209867274";

        public AppWindow()
        {
            InitializeComponent();
            if(Parser.isGameRunning())
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
            client = new DiscordRpcClient(CLIENT_ID);
            client.Logger = new ConsoleLogger() { Level = LogLevel.Warning };
            client.OnReady += (sender, e) =>
            {
                Console.WriteLine("ready recv: {0}", e.User.Username);
            };
            client.OnPresenceUpdate += (sender, e) =>
            {
                Console.WriteLine("update: {0}", e.Presence);
            };
            client.Initialize();
            client.SetPresence(new RichPresence()
            {
                Details = "",
                State = "",
                Timestamps = Timestamps.Now,
                Assets = new Assets()
                {
                    LargeImageKey = "",
                    LargeImageText = ""
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
                presenceTicker.Dispose();
                client.Deinitialize();
                client.Dispose();
                InitGameTicker();
            }
        }
    }
}
