using Light.GuardClauses;
using System.Windows.Controls;

namespace AtlasApp.Map
{
    public partial class MapView : UserControl
    {
        public MapView(MapViewModel viewModel)
        {
            DataContext = viewModel.MustNotBeNull(nameof(viewModel));
            InitializeComponent();
        }
    }
}
