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
            new TwitchStreamer("DragonFighter", new Uri("https://twitch.tv/dragonfighter666")),
            new TwitchStreamer("EvilGirly", new Uri("https://twitch.tv/evilgirly_666"))
        };
    }
}
