using AtlasApp.AppComposition;
using AtlasApp.Twitch;
using Light.GuardClauses;
using LightInject;

namespace AtlasApp.MainMenu
{
    public sealed class NavigateToTwitchCommand
    {
        private readonly IServiceFactory _container;

        public NavigateToTwitchCommand(IServiceFactory container) => 
            _container = container.MustNotBeNull(nameof(container));

        public void Navigate() => 
            _container.GetInstance<INavigator>().NavigateTo(_container.GetInstance<TwitchView>(),
                                                            _container.GetInstance<MainMenuView>());
    }
}
