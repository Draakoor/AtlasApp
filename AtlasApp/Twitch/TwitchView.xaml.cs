using Light.GuardClauses;
using System;
using System.Windows;
using System.Windows.Controls;

namespace AtlasApp.Twitch
{
    public partial class TwitchView : UserControl
    {
        public TwitchView(TwitchViewModel viewModel)
        {
            DataContext = viewModel.MustNotBeNull(nameof(viewModel));
            InitializeComponent();
        }
    }
}