using Prism.Commands;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;

namespace BMICalculator.ViewModels
{
    public class Step2PageViewModel : ViewModelBase
    {
        private string _selectedGender;

        private string _avatarImage;
        public string AvatarImage
        {
            get { return _avatarImage; }
            set { SetProperty(ref _avatarImage, value); }
        }

        private float _selectedHeight = 0f;
        public float SelectedHeight
        {
            get { return _selectedHeight; }
            set
            {
                SetProperty(ref _selectedHeight, value);

                //Raise the Event to notify the page of size changes
                HeightWeightChanged?.Invoke(this, new EventArgs());

            }
        }

        private float _selectedWeight = 0f;
        public float SelectedWeight
        {
            get { return _selectedWeight; }
            set
            {
                SetProperty(ref _selectedWeight, value);

                //Raise the Event to notify the page of size changes
                HeightWeightChanged?.Invoke(this, new EventArgs());

            }
        }

        public event EventHandler HeightWeightChanged;

        public DelegateCommand GoToResultsPageCommand { get; set; }

        public Step2PageViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "Your height & weight";

            SelectedHeight = 160;
            SelectedWeight = 60;

            GoToResultsPageCommand = new DelegateCommand(GoToResultsPage);
        }

        private async void GoToResultsPage()
        {
            await NavigationService.NavigateAsync($"BMIResultsPage?selectedHeight={SelectedHeight}&selectedWeight={SelectedWeight}&selectedGender={_selectedGender}", useModalNavigation: false);
        }


        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            if (parameters.ContainsKey("selectedGender"))
                _selectedGender = parameters["selectedGender"].ToString();

            AvatarImage = _selectedGender + ".png";

        }

    }
}
