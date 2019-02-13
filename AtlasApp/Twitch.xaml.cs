﻿using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace AtlasApp
{
    /// <summary>
    /// Interaktionslogik für Twitch.xaml
    /// </summary>
    public partial class Twitch : Window
    {
        public Twitch()
        {
            InitializeComponent();
            WebBrowserHelper.FixBrowserVersion();
        }
        private void Domi(object sender, RoutedEventArgs e)
        {
            // Get URI to navigate to  
            string domain = "https://twitch.tv/draakoor";
            Uri uri = new Uri(domain);

            // Navigate to the desired URL by calling the .Navigate method  
            this.myWebBrowser.Navigate(domain);
        }
        private void Torsten(object sender, RoutedEventArgs e)
        {
            // Get URI to navigate to  
            string domain = "https://twitch.tv/dragonfighter666";
            Uri uri = new Uri(domain);

            // Navigate to the desired URL by calling the .Navigate method  
            this.myWebBrowser.Navigate(domain);
        }
        private void Sabine(object sender, RoutedEventArgs e)
        {
            // Get URI to navigate to  
            string domain = "https://www.twitch.tv/evilgirly_666";
            Uri uri = new Uri(domain);

            // Navigate to the desired URL by calling the .Navigate method  
            this.myWebBrowser.Navigate(domain);
        }
        public class WebBrowserHelper
        {


            public static int GetEmbVersion()
            {
                int ieVer = GetBrowserVersion();

                if (ieVer > 9)
                    return ieVer * 1000 + 1;

                if (ieVer > 7)
                    return ieVer * 1111;

                return 7000;
            } // End Function GetEmbVersion

            public static void FixBrowserVersion()
            {
                string appName = System.IO.Path.GetFileNameWithoutExtension(System.Reflection.Assembly.GetExecutingAssembly().Location);
                FixBrowserVersion(appName);
            }

            public static void FixBrowserVersion(string appName)
            {
                FixBrowserVersion(appName, GetEmbVersion());
            } // End Sub FixBrowserVersion

            // FixBrowserVersion("<YourAppName>", 9000);
            public static void FixBrowserVersion(string appName, int ieVer)
            {
                FixBrowserVersion_Internal("HKEY_LOCAL_MACHINE", appName + ".exe", ieVer);
                FixBrowserVersion_Internal("HKEY_CURRENT_USER", appName + ".exe", ieVer);
                FixBrowserVersion_Internal("HKEY_LOCAL_MACHINE", appName + ".vshost.exe", ieVer);
                FixBrowserVersion_Internal("HKEY_CURRENT_USER", appName + ".vshost.exe", ieVer);
            } // End Sub FixBrowserVersion 

            private static void FixBrowserVersion_Internal(string root, string appName, int ieVer)
            {
                try
                {
                    //For 64 bit Machine 
                    if (Environment.Is64BitOperatingSystem)
                        Microsoft.Win32.Registry.SetValue(root + @"\Software\Wow6432Node\Microsoft\Internet Explorer\Main\FeatureControl\FEATURE_BROWSER_EMULATION", appName, ieVer);
                    else  //For 32 bit Machine 
                        Microsoft.Win32.Registry.SetValue(root + @"\Software\Microsoft\Internet Explorer\Main\FeatureControl\FEATURE_BROWSER_EMULATION", appName, ieVer);


                }
                catch (Exception)
                {
                    // some config will hit access rights exceptions
                    // this is why we try with both LOCAL_MACHINE and CURRENT_USER
                }
            } // End Sub FixBrowserVersion_Internal 

            public static int GetBrowserVersion()
            {
                // string strKeyPath = @"HKLM\SOFTWARE\Microsoft\Internet Explorer";
                string strKeyPath = @"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Internet Explorer";
                string[] ls = new string[] { "svcVersion", "svcUpdateVersion", "Version", "W2kVersion" };

                int maxVer = 0;
                for (int i = 0; i < ls.Length; ++i)
                {
                    object objVal = Microsoft.Win32.Registry.GetValue(strKeyPath, ls[i], "0");
                    string strVal = System.Convert.ToString(objVal);
                    if (strVal != null)
                    {
                        int iPos = strVal.IndexOf('.');
                        if (iPos > 0)
                            strVal = strVal.Substring(0, iPos);

                        int res = 0;
                        if (int.TryParse(strVal, out res))
                            maxVer = Math.Max(maxVer, res);
                    } // End if (strVal != null)

                } // Next i

                return maxVer;
            } // End Function GetBrowserVersion 


        }
    }
}