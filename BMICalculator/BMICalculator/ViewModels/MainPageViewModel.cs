using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BMICalculator.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private string _selectedGender = String.Empty;
        public string SelectedGender
        {
            get { return _selectedGender; }
            set { SetProperty(ref _selectedGender, value); }
        }

        private bool _isMaleSelected = false;
        public bool IsMaleSelected
        {
            get { return _isMaleSelected; }
            set { SetProperty(ref _isMaleSelected, value); }
        }

        private bool _isFemaleSelected = false;
        public bool IsFemaleSelected
        {
            get { return _isFemaleSelected; }
            set { SetProperty(ref _isFemaleSelected, value); }
        }

        public DelegateCommand<string> SelectGenderCommand { get; set; }
        public DelegateCommand GoToStep2PageCommand { get; set; }

        private IPageDialogService _pageDialogService { get; set; }

        public MainPageViewModel(INavigationService navigationService, IPageDialogService dialogService)
            : base(navigationService)
        {
            _pageDialogService = dialogService;

            Title = "Choose your gender";

            SelectGenderCommand = new DelegateCommand<string>(SelectGender);
            GoToStep2PageCommand = new DelegateCommand(GoToStep2Page);
        }

        private async void SelectGender(string gender)
        {
            SelectedGender = gender;

            IsMaleSelected = false;
            IsFemaleSelected = false;

            if (gender == "Male")
                IsMaleSelected = true;
            else
                IsFemaleSelected = true;
        }

        private async void GoToStep2Page()
        {
            if (string.IsNullOrEmpty(SelectedGender))
            {
                //Display a message and do nothing
                await _pageDialogService.DisplayAlertAsync("GENDER SELECTION", "Please choose your gender before proceeding further.", "OK, Got it!");

                return;
            }

                await NavigationService.NavigateAsync($"Step2Page?selectedGender={SelectedGender}", useModalNavigation: false);
        }

    }
}
