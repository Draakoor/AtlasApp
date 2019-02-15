using Light.GuardClauses;
using System;

namespace AtlasApp.Twitch
{
    public sealed class TwitchStreamer
    {
        public TwitchStreamer(string name,
                              Uri uri)
        {
            Name = name.MustNotBeNull(nameof(name));
            Uri = uri.MustNotBeNull(nameof(uri));
        }

        public string Name { get; }
        
        public Uri Uri { get; }
    }
}
