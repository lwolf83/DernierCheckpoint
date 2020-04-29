using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Media;

namespace WildCircus
{
    public class TreeUI
    {
        public static UIElement GetElementByName(string name)
        {
            Application curApp = Application.Current;
            Window mainWindow = curApp.MainWindow;
            UIElement uIElement = (UIElement) mainWindow.FindName(name);
            return uIElement;
        }


    }
}
