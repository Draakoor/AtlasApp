using AtlasApp.AppComposition;
using AtlasApp.MainMenu;
using LightInject;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace AtlasApp
{
    public partial class App : Application
    {
        private readonly ServiceContainer _container;
        private readonly Uri _teamSpeakUri = new Uri("http://discord.reapercrew-multigaming.de");
        private readonly Uri _atlasUri = new Uri("steam://connect/theforest.reapercrew-multigaming.de:57561");
        private readonly Uri _supportMailUri = new Uri("mailto:support@reapercrew-multigaming.de?subject=[SUPPORT]Ich brauche Hilfe");
        private readonly Uri _HomepageUri = new Uri("https://reapercrew-multigaming.de");

        public App()
        {
            _container = new ServiceContainer(new ContainerOptions()
                                                  {
                                                      EnablePropertyInjection = false
                                                  });
        }

        protected override async void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            _container.RegisterApplicationShell()
                      .RegisterMainMenu(_teamSpeakUri,
                                        _atlasUri,
                                        _supportMailUri,
                                        _HomepageUri)
                      .RegisterMap()
                      .RegisterTwitch();

            MainWindow = _container.GetInstance<MainWindow>();
            MainWindow.Show();

            await Task.Delay(200);

            _container.GetInstance<INavigator>().NavigateTo(_container.GetInstance<MainMenuView>());
        }
    }
}
