using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using MagpieProject.Database;
using MagpieProject.Styles;
using MagpieProject.Themes;
using MagpieProject.Views;
using MagpieProject.Views.ProfileModule;
using Plugin.Media;
using Plugin.Media.Abstractions;
using Rg.Plugins.Popup.Services;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace MagpieProject.ViewModels.ProfileModule
{
    public class ProfileViewModel:BaseViewModel
    {
        public INavigation navigation { get; set; }

        private string _FullName;

        public string FullName
        {
            get { return _FullName; }
            set
            {
                _FullName = value;

                OnPropertyChanged();
            }
        }
        private string _Email;

        public string Email
        {
            get { return _Email; }
            set
            {
                _Email = value;

                OnPropertyChanged();
            }
        }
        private string _Password;

        public string Password
        {
            get { return _Password; }
            set
            {
                _Password = value;

                OnPropertyChanged();
            }
        }

        private bool _IsDarkSelected;

        public bool IsDarkSelected
        {
            get { return _IsDarkSelected; }
            set
            {
                _IsDarkSelected = value;

                OnPropertyChanged();
            }
        }
        ImageSource photoPath;
        public ImageSource PhotoPath
        {
            get => photoPath;
            set
            {
                if (photoPath == value)
                    return;
                photoPath = value;
                OnPropertyChanged();
            }
        }
        public Command LogoutCommand => new Command(async () =>
        {
            Application.Current.Properties.Clear();
            DBManager.Instance().deleteLoggedInUser();
            App.Current.MainPage = new NavigationPage(new LoginView());
        }
        );

        public Command AddIconCommand => new Command(async () =>
        {
            //Open Popup
            //await navigation.PushAsync(new PickImagePopUP());
            await PopupNavigation.Instance.PushAsync(new PickImagePopUP(this));
        }
       );
        public Command PhotoLibraryCommand => new Command(async () =>
        {
            var file = await MediaPicker.PickPhotoAsync(new MediaPickerOptions
            {
                Title = "Please pick a photo"
            });
            //if (!CrossMedia.Current.IsPickPhotoSupported)
            //{
            //    await Application.Current.MainPage.DisplayAlert("Photos Not Supported", ":( Permission not granted to photos.", "OK");
            //    return;
            //}
            //var file = await CrossMedia.Current.PickPhotoAsync(new Plugin.Media.Abstractions.PickMediaOptions
            //{
            //    PhotoSize = Plugin.Media.Abstractions.PhotoSize.Medium

            //});
            await PopupNavigation.Instance.PopAllAsync();
            await LoadPhotoAsync(file);
           
        }
        );
        public Command TakePhotoCommand => new Command(async () =>
        {
            var photo = await MediaPicker.CapturePhotoAsync();
            await LoadPhotoAsync(photo);
            //await CrossMedia.Current.Initialize();

            //if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
            //{
            //    //DisplayAlert("No Camera", ":( No camera available.", "OK");
            //    return;
            //}

            //var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
            //{
            //    Directory = "Sample",
            //    Name = "test.jpg"
            //});

            //if (file == null)
            //    return;

            ////await DisplayAlert("File Location", file.Path, "OK");

            //PhotoPath = ImageSource.FromStream(() =>
            //{
            //    var stream = file.GetStream();
            //    return stream;
            //});
        }
        );
        async Task LoadPhotoAsync(FileResult file)
        {
            // canceled
            if (file == null)
            {
                PhotoPath = null;
                Application.Current.Properties.Remove("ProfileImage");
                return;
            }

            var newFile = Path.Combine(FileSystem.CacheDirectory, file.FileName);
            using (var stream = await file.OpenReadAsync())
            {
                using (var newStream = File.OpenWrite(newFile))
                {
                    await stream.CopyToAsync(newStream);
                }
            }
            PhotoPath = newFile;
            //PhotoPath = ImageSource.FromStream(() =>
            //{
            //    var stream = file.GetStream();
            //    return stream;
            //});
            var currentuser = DBManager.Instance().getLoggedInUser();
            currentuser.isprofileimagepresent = true;
            DBManager.Instance().UpdateUserAppSettings(currentuser);
            if (Application.Current.Properties.ContainsKey("ProfileImage"))
            {
                Application.Current.Properties["ProfileImage"] = PhotoPath;
            }
            else
            {
                Application.Current.Properties.Add("ProfileImage", PhotoPath);
            }
           
        }
        public Command ChooseFileCommand => new Command(async () =>
        {
            
        }
        );
        public Command DarkCommand => new Command(async () =>
        {
            IsDarkSelected = true;
            ICollection<ResourceDictionary> mergedDictionaries = App.Current.Resources.MergedDictionaries;
            if (mergedDictionaries != null)
            {
                App.IsLight = false;
                App.IsDark = true;
                mergedDictionaries.Clear();
                mergedDictionaries.Add(new DarkTheme());
             
                if (App.IsASmallDevice())
                {
                    mergedDictionaries.Add(SmallDevicesStyle.SharedInstance);
                }
                else
                {
                    mergedDictionaries.Add(GeneralDevicesStyle.SharedInstance);
                }
                App.Current.MainPage = new AppShell();
                AppShell content = (AppShell)App.Current.MainPage;
                content.SetCurrentToProfile();

            }
        });

        public Command LightCommand => new Command(async () =>
        {
            IsDarkSelected = false;
            ICollection<ResourceDictionary> mergedDictionaries = App.Current.Resources.MergedDictionaries;
            if (mergedDictionaries != null)
            {
                App.IsLight = true;
                App.IsDark = false;
                mergedDictionaries.Clear();
                mergedDictionaries.Add(new LightTheme());
                if (App.IsASmallDevice())
                {
                    mergedDictionaries.Add(SmallDevicesStyle.SharedInstance);
                }
                else
                {
                    mergedDictionaries.Add(GeneralDevicesStyle.SharedInstance);
                }
                App.Current.MainPage = new AppShell();
                AppShell content =(AppShell) App.Current.MainPage;
                content.SetCurrentToProfile();
            }
        });
        public ProfileViewModel()
        {
            var currentuser = DBManager.Instance().getLoggedInUser();
            if (currentuser!=null)
            {
                FullName = currentuser.fullname;
                Email = currentuser.email;
                Password = currentuser.password;
                if (currentuser.isprofileimagepresent && Application.Current.Properties.ContainsKey("ProfileImage"))
                {
                    PhotoPath = (ImageSource)Application.Current.Properties["ProfileImage"];
                }

            }
            AppTheme appTheme = AppInfo.RequestedTheme;
            ICollection<ResourceDictionary> mergedDictionaries = App.Current.Resources.MergedDictionaries;
            if (mergedDictionaries != null)
            {
                if (mergedDictionaries.First().GetType()==typeof(DarkTheme))
                {
                    IsDarkSelected = true;
                }
                else
                {
                    IsDarkSelected = false;
                }
               

            }
            else if(appTheme==AppTheme.Light)
            {
                IsDarkSelected = false;
            }
            else
            {
                IsDarkSelected = true;
            }
        }
    }
}
