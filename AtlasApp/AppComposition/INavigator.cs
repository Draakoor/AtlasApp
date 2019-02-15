namespace AtlasApp.AppComposition
{
    public interface INavigator
    {
        void NavigateTo(object view, object navigateBackView = null);

        void NavigateBack();

        object NavigateBackView { get; }
    }
}
