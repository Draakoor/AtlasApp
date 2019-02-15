using Light.GuardClauses;
using Light.ViewModels;
using System.Windows.Input;

namespace AtlasApp.AppComposition
{
    public sealed class MainWindowViewModel : BaseNotifyPropertyChanged, INavigator
    {
        private object _currentView;
        private object _navigateBackView;
        private bool _isNavigateBackVisible;

        public MainWindowViewModel()
        {
            NavigateBackCommand = new DelegateCommand(NavigateBack);
        }

        public ICommand NavigateBackCommand { get; }

        public object CurrentView
        {
            get => _currentView;
            private set => this.SetIfDifferent(ref _currentView, value);
        }

        public object NavigateBackView
        {
            get => _navigateBackView;
            private set => this.SetIfDifferent(ref _navigateBackView, value);
        }

        public bool IsNavigateBackVisible
        {
            get => _isNavigateBackVisible;
            private set => this.SetIfDifferent(ref _isNavigateBackVisible, value);
        }

        public void NavigateTo(object view, object navigateBackView = null)
        {
            _navigateBackView = navigateBackView;
            IsNavigateBackVisible = navigateBackView != null;
            CurrentView = view.MustNotBeNull(nameof(view));
        }

        public void NavigateBack()
        {
            if (NavigateBackView == null)
                return;

            NavigateTo(NavigateBackView);
        }
    }
}
