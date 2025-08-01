using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;

using Hardcodet.Wpf.TaskbarNotification;

namespace SK_DiscordRPC
{
    public partial class App : Application
    {
        protected override void OnStartup (StartupEventArgs e)
        {
            base.OnStartup(e);
            AppWindow.KL_VERSION = e.Args[0];
        }

        private void AppWindow_OnExit (object sender, ExitEventArgs e)
        {
            // For fucks sake please work.
            AppWindow.taskbarIcon.Visibility = Visibility.Hidden;
            AppWindow.taskbarIcon.Icon.Dispose();
            AppWindow.taskbarIcon.Dispose();

            // Exit the application.
            Environment.Exit(0);
        }
    }
}
