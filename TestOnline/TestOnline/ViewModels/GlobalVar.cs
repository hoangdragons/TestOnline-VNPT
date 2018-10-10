using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Plugin.Settings;
using Plugin.Settings.Abstractions;


namespace TestOnline.ViewModels
{
    public class GlobalVar : BaseViewModel
    {
        // Singleton
        public static GlobalVar Current = new GlobalVar();

        private GlobalVar()
        {
            isUserLoggedIn = false;
        }

        private bool isUserLoggedIn;

        public bool IsUserLoggedIn
        {
            get { return isUserLoggedIn; }

            set { SetProperty(ref isUserLoggedIn, value); }
        }

        static ISettings AppSettings
        {
            get
            {
                return CrossSettings.Current;
            }
        }
        public string Username
        {
            get => AppSettings.GetValueOrDefault(nameof(Username), string.Empty);
            set { OnPropertyChanged(); AppSettings.AddOrUpdateValue(nameof(Username), value); }
        }

        public string Password
        {
            get => AppSettings.GetValueOrDefault(nameof(Password), string.Empty);
            set { OnPropertyChanged(); AppSettings.AddOrUpdateValue(nameof(Password), value); }
        }
        public void Logout()
        {
            IsUserLoggedIn = false;
        }
        public void ClearAllData()
        {
            IsUserLoggedIn = false;
            AppSettings.Clear();
        }
    }
}
