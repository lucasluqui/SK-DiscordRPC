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
using SK_DiscordRPC.Data;
using SK_DiscordRPC.Framework;

namespace SK_DiscordRPC
{
    public partial class AppWindow : Window

    {
        public static DiscordRpcClient client;
        public static Timestamps GlobalTime = Timestamps.Now;
        public static Whereabout curWhere;
        private Timer ticker;
        private string CLIENT_ID = "626524043209867274";

        public AppWindow()
        {
            InitializeComponent();
            SetupRPC();
        }

        public void SetupRPC()
        {
            client = new DiscordRpcClient(CLIENT_ID);
            client.Logger = new ConsoleLogger() { Level = LogLevel.Warning };
            client.OnReady += (sender, e) =>
            {
                Console.WriteLine("Received Ready from user {0}", e.User.Username);
            };
            client.OnPresenceUpdate += (sender, e) =>
            {
                Console.WriteLine("Received Update! {0}", e.Presence);
            };
            client.Initialize();
            client.SetPresence(new RichPresence()
            {
                Details = "",
                State = "",
                Assets = new Assets()
                {
                    LargeImageKey = "",
                    LargeImageText = ""
                }
            });
            InitTicker();
        }
        public void InitTicker()
        {
            ticker = new Timer(5000);
            ticker.Elapsed += OnTimedEvent;
            ticker.Enabled = true;
        }

        private void OnTimedEvent(object sender, EventArgs e)
        {
            ClientPresence.update();
        }

    }
}
