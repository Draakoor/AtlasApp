using AtlasApp.Twitch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtlasApp.AppComposition
{
    public static class Configuration
    {
        public static IReadOnlyList<TwitchStreamer> Streamers = new List<TwitchStreamer>()
        {
            new TwitchStreamer("Draakoor", new Uri("https://twitch.tv/draakoor")),
            new TwitchStreamer("Nudel", new Uri("https://www.twitch.tv/nudel1408")),
            new TwitchStreamer("Jacktheripper", new Uri ("https://www.twitch.tv/jacktheripper030"))
        };
    }
}
