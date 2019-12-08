using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;

namespace SK_DiscordRPC
{
    public partial class App : Application
    {
        private void AppWindow_OnExit(object sender, ExitEventArgs e)
        {
            //AppWindow.client.Deinitialize();
            //AppWindow.client.Dispose();
        }
    }
}
