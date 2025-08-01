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
        private void AppWindow_OnExit (object sender, ExitEventArgs e)
        {
            AppWindow.taskbarIcon.Visibility = Visibility.Hidden;
            AppWindow.taskbarIcon.Icon.Dispose();
            AppWindow.taskbarIcon.Dispose();

            // Exit the application.
            Environment.Exit(0);
        }
    }
}
