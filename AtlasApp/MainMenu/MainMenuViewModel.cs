using Light.GuardClauses;
using Light.ViewModels;
using System;
using System.Diagnostics;
using System.Windows.Input;

namespace AtlasApp.MainMenu
{
    public sealed class MainMenuViewModel : BaseNotifyPropertyChanged
    {
        private readonly NavigateToMapCommand _navigateToMapCommand;
        private readonly NavigateToTwitchCommand _navigateToTwitchCommand;
        private readonly Uri _teamSpeakUri;
        private readonly Uri _atlasUri;
        private readonly Uri _supportMailUri;

        public MainMenuViewModel(NavigateToMapCommand navigateToMapCommand,
                                 NavigateToTwitchCommand navigateToTwitchCommand,
                                 Uri teamSpeakUri,
                                 Uri atlasUri,
                                 Uri supportMailUri)
        {
            _navigateToMapCommand = navigateToMapCommand.MustNotBeNull(nameof(navigateToMapCommand));
            _navigateToTwitchCommand = navigateToTwitchCommand.MustNotBeNull(nameof(navigateToTwitchCommand));
            _teamSpeakUri = teamSpeakUri.MustNotBeNull(nameof(teamSpeakUri));
            _atlasUri = atlasUri.MustNotBeNull(nameof(atlasUri));
            _supportMailUri = supportMailUri.MustNotBeNull(nameof(supportMailUri));
            
            StartTeamSpeakCommand = new DelegateCommand(StartTeamSpeak);
            NavigateToMapCommand = new DelegateCommand(NavigateToMap);
            StartAtlasCommand = new DelegateCommand(StartAtlas);
            OpenSupportMailCommand = new DelegateCommand(OpenSupportMail);
            NavigateToTwitchCommand = new DelegateCommand(NavigateToTwitch);
        }

        public ICommand StartTeamSpeakCommand { get; }

        public ICommand NavigateToMapCommand { get; }

        public ICommand StartAtlasCommand { get; }

        public ICommand OpenSupportMailCommand { get; }

        public ICommand NavigateToTwitchCommand { get; }

        private void StartTeamSpeak() => 
            Process.Start(new ProcessStartInfo(_teamSpeakUri.AbsoluteUri));

        private void NavigateToMap() => 
            _navigateToMapCommand.Navigate();

        private void StartAtlas() => 
            Process.Start(new ProcessStartInfo(_atlasUri.AbsoluteUri));

        private void OpenSupportMail() => 
            Process.Start(new ProcessStartInfo(_supportMailUri.AbsoluteUri));

        private void NavigateToTwitch() => 
            _navigateToTwitchCommand.Navigate();
    }
}
