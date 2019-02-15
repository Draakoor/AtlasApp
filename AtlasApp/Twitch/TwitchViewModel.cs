using Light.GuardClauses;
using Light.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtlasApp.Twitch
{
    public sealed class TwitchViewModel : BaseNotifyPropertyChanged
    {
        private List<TwitchStreamerViewModel> _streamers;
        private Uri _webBrowserUri;

        public TwitchViewModel(List<TwitchStreamer> streamers)
        {
            streamers.MustNotBeNull(nameof(streamers));
            Streamers = streamers.Select(streamer => new TwitchStreamerViewModel(streamer, this))
                                 .ToList();
        }

        public List<TwitchStreamerViewModel> Streamers
        {
            get => _streamers;
            set => this.SetIfDifferent(ref _streamers, value);
        }

        public Uri WebBrowserUri
        {
            get => _webBrowserUri;
            set => this.SetIfDifferent(ref _webBrowserUri, value);
        }

        public void SelectStreamer(TwitchStreamer streamer)
        {
            WebBrowserUri = streamer.Uri;
        }
    }
}
