using AtlasApp.MainMenu;
using AtlasApp.Map;
using AtlasApp.Twitch;
using LightInject;
using System;
using System.Linq;

namespace AtlasApp.AppComposition
{
    public static class CompositionRoot
    {
        public static ServiceContainer RegisterApplicationShell(this ServiceContainer container)
        {
            container.Register<MainWindow>(new PerContainerLifetime())
                     .Register<MainWindowViewModel>(new PerContainerLifetime())
                     .Register<INavigator>(f => f.GetInstance<MainWindowViewModel>());

            return container;
        }

        public static ServiceContainer RegisterMainMenu(this ServiceContainer container, 
                                                        Uri teamSpeakUri, 
                                                        Uri atlasUri, 
                                                        Uri supportMailUri)
        {
            container.Register<MainMenuView>(new PerContainerLifetime())
                     .Register<MainMenuViewModel>(c => new MainMenuViewModel(c.GetInstance<NavigateToMapCommand>(),
                                                                             c.GetInstance<NavigateToTwitchCommand>(),
                                                                             teamSpeakUri,
                                                                             atlasUri,
                                                                             supportMailUri), 
                                                  new PerContainerLifetime())
                     .Register<NavigateToMapCommand>(c => new NavigateToMapCommand(c), 
                                                     new PerContainerLifetime())
                     .Register<NavigateToTwitchCommand>(c => new NavigateToTwitchCommand(c),
                                                        new PerContainerLifetime());

            return container;
        }

        public static ServiceContainer RegisterMap(this ServiceContainer container)
        {
            container.Register<MapView>()
                     .Register<MapViewModel>();

            return container;
        }

        public static ServiceContainer RegisterTwitch(this ServiceContainer container)
        {
            container.Register<TwitchView>()
                     .Register<TwitchViewModel>(c => new TwitchViewModel(Configuration.Streamers.ToList()));

            return container;
        }
    }
}
