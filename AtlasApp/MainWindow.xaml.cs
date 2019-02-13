using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Diagnostics;
using System.ComponentModel;
using System.Media;
using System.Resources;
using System.IO;
using System.Data;

namespace AtlasApp
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private bool _hasValidURI;
        public bool HasValidURI
        {
            get { return _hasValidURI; }
            set { _hasValidURI = value; OnPropertyChanged("HasValidURI"); }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string name)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(name));
        }

        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        private void ButtonClicked(object sender, RoutedEventArgs e)
        {
            Map subWindow = new Map();
            subWindow.Show();
            System.Media.SoundPlayer sp = new System.Media.SoundPlayer(Resource.tada);
            //sp.PlayLooping();
            sp.Play();
        }

        private void TSClicked(object sender, RoutedEventArgs e)
        {
            System.Media.SoundPlayer sp = new System.Media.SoundPlayer(Resource.connected);
            //sp.PlayLooping();
            sp.Play();
        }

        private void Atlasclick(object sender, RoutedEventArgs e)
        {
            System.Media.SoundPlayer sp = new System.Media.SoundPlayer(Resource.atlas3);
            //sp.PlayLooping();
            sp.Play();
        }

        private void SupportClick(object sender, RoutedEventArgs e)
        {
            System.Media.SoundPlayer sp = new System.Media.SoundPlayer(Resource.mail);
            //sp.PlayLooping();
            sp.Play();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            Uri uri;
            HasValidURI = Uri.TryCreate((sender as TextBox).Text, UriKind.Absolute, out uri);
        }

        private void TextBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Uri uri;
            if (Uri.TryCreate((sender as TextBox).Text, UriKind.Absolute, out uri))
            {
                Process.Start(new ProcessStartInfo(uri.AbsoluteUri));
            }
        }
        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri));
            e.Handled = true;
        }
        private void Twitchbox(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Möchtest du einem Admin auf Twitch zuschauen?", "Twitchbox", MessageBoxButton.YesNo, MessageBoxImage.Information);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    MessageBox.Show("Ich öffne nun die TwitchBox für dich", "Twitchbox", MessageBoxButton.OK, MessageBoxImage.Warning);
                    Twitch subWindow = new Twitch();
                    subWindow.Show();
                    break;
                case MessageBoxResult.No:
                    MessageBox.Show("Schade :(", "Twitchbox", MessageBoxButton.OK, MessageBoxImage.Error);
                    break;
            }
        }
    }
}
