using AtlasApp.AppComposition;
using AtlasApp.Map;
using Light.GuardClauses;
using LightInject;

namespace AtlasApp.MainMenu
{
    public sealed class NavigateToMapCommand
    {
        private readonly IServiceFactory _container;

        public NavigateToMapCommand(IServiceFactory container) => 
            _container = container.MustNotBeNull(nameof(container));

        public void Navigate() => 
            _container.GetInstance<INavigator>().NavigateTo(_container.GetInstance<MapView>(),
                                                            _container.GetInstance<MainMenuView>());
    }
}
