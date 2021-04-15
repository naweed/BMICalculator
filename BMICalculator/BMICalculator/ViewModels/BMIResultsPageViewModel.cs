using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;

namespace BMICalculator.ViewModels
{
    public class BMIResultsPageViewModel : ViewModelBase
    {
        private float _selectedHeight, _selectedWeight;
        private string _selectedGender;

        private string _avatarImage;
        public string AvatarImage
        {
            get { return _avatarImage; }
            set { SetProperty(ref _avatarImage, value); }
        }

        private float _computedBMI = 0f;
        public float ComputedBMI
        {
            get { return _computedBMI; }
            set { SetProperty(ref _computedBMI, value); }
        }

        private bool _isDataReady = false;
        public bool IsDataReady
        {
            get { return _isDataReady; }
            set { SetProperty(ref _isDataReady, value); }
        }


        public BMIResultsPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "Your BMI";
        }

        public override async void OnNavigatedTo(INavigationParameters parameters)
        {
            if (parameters.ContainsKey("selectedHeight"))
                _selectedHeight = Convert.ToSingle(parameters["selectedHeight"]);

            if (parameters.ContainsKey("selectedWeight"))
                _selectedWeight = Convert.ToSingle(parameters["selectedWeight"]);

            if (parameters.ContainsKey("selectedGender"))
                _selectedGender = parameters["selectedGender"].ToString();

            AvatarImage = _selectedGender + ".png";

            ComputeBMI();
        }

        private async void ComputeBMI()
        {
            //Calculation: [weight (kg) / height (cm) / height (cm)] x 10,000
            ComputedBMI = 10000f * _selectedWeight / _selectedHeight / _selectedHeight;

            IsDataReady = true;
        }

    }
}
