using System;
using System.Text.RegularExpressions;
using Acr.UserDialogs;
using MagpieProject.Database;
using MagpieProject.Models;
using MagpieProject.Models.UserSettings;
using MagpieProject.Utilities;
using Xamarin.Forms;

namespace MagpieProject.ViewModels
{
    public class LoginViewModel:BaseViewModel
    {
        private string _email;

        public string Email
        {
            get { return _email; }
            set
            {
                _email = value;
                OnPropertyChanged(nameof(Email));
            }
        }
        private string _password;

        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        private bool _IsEmailError;

        public bool IsEmailError
        {
            get { return _IsEmailError; }
            set
            {
                _IsEmailError = value;
                OnPropertyChanged(nameof(IsEmailError));
            }
        }
        private bool _IsPasswordError;

        public bool IsPasswordError
        {
            get { return _IsPasswordError; }
            set
            {
                _IsPasswordError = value;
                OnPropertyChanged(nameof(IsPasswordError));
            }
        }
        public LoginViewModel()
        {
            IsPasswordError = false;
            IsEmailError = false;
        }
        public Command LoginCommand => new Command(async () =>
        {
            if(String.IsNullOrEmpty(Email) || String.IsNullOrEmpty(Password))
            {
                UserDialogs.Instance.Toast("Credentials cannot be empty");
                IsPasswordError = true;
                IsEmailError = true;
                return;
            }
            if (!Regex.Match(Email,Constants.EmailRegex).Success)
            {
                UserDialogs.Instance.Toast("Enter valid email");
                IsPasswordError = false;
                IsEmailError = true;
                return;
            }
            string wherecondn="Email='"+Email.ToLower()+"' and Password='"+Password+"'";
            var loggedinUser = DBManager.Instance().QueryTable<Users>("Users", wherecondn);
            if(loggedinUser!=null && loggedinUser.Count > 0)
            {
                DBManager.Instance().InsertData(new UserLoginDetails()
                {
                    userId = Email,
                    email = Email,
                    fullname = loggedinUser[0].FullName,
                    password = loggedinUser[0].Password,
                    isprofileimagepresent = false,
                });
            }
            else
            {
                UserDialogs.Instance.Toast("Invalid Credentials");
                IsPasswordError = true;
                IsEmailError = true;
                return;
            }
            
            App.UserID = Email;
            DBManager.Instance().FillAllDummyData();
            Application.Current.Properties.Clear();
            App.Current.MainPage = new AppShell();
        });

        public Command SignUp_TappedCommand => new Command(async () =>
        {
            UserDialogs.Instance.Toast("Page under contruction");
        });


    }
}
