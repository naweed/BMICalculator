using BMICalculator.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BMICalculator.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Step2Page : ContentPage
    {
        double gridPadding;
        Step2PageViewModel viewModel;

        public Step2Page()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            viewModel = this.BindingContext as Step2PageViewModel;

            viewModel.HeightWeightChanged += ViewModel_HeightWeightChanged;

            if (SelectionGrid.Height > 400)
            {
                gridPadding = (SelectionGrid.Height - 400) / 2;
                SelectionGrid.Padding = new Thickness(0, gridPadding);
            }

            SetDimensions();
        }

        private void ViewModel_HeightWeightChanged(object sender, EventArgs e)
        {
            SetDimensions();
        }


        private void SetDimensions()
        {
            if (viewModel.SelectedHeight == 0 || viewModel.SelectedWeight == 0)
                return;

            AvatarImage.HeightRequest = SelectionGrid.Height - 15f - gridPadding * 2 - (HeightControl.Height - 30f) * (HeightControl.Maximum - viewModel.SelectedHeight) / (HeightControl.Maximum - HeightControl.Minimum);

            AvatarImage.WidthRequest = viewModel.SelectedWeight * (this.Width - 160 - 100) / (WeightControl.Maximum - WeightControl.Minimum);
        }

    }
}