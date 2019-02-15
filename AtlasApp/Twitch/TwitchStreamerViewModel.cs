using Light.GuardClauses;
using Light.ViewModels;
using System.Windows.Input;

namespace AtlasApp.Twitch
{
    public sealed class TwitchStreamerViewModel
    {
        private readonly TwitchViewModel _twitchViewModel;

        public TwitchStreamerViewModel(TwitchStreamer streamer,
                                       TwitchViewModel twitchViewModel)

        {
            SelectAsStreamerCommand = new DelegateCommand(SelectAsStreamer);
            Streamer = streamer.MustNotBeNull(nameof(streamer));
            _twitchViewModel = twitchViewModel.MustNotBeNull(nameof(twitchViewModel));
        }

        public ICommand SelectAsStreamerCommand { get; }

        public TwitchStreamer Streamer { get; }

        private void SelectAsStreamer() =>
            _twitchViewModel.SelectStreamer(Streamer);
    }
}