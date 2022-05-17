using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace MagpieProject.ViewModels
{
    public class BaseViewModel : BindableObject, INotifyPropertyChanged
    {
        private string _HeaderText;
        private Type _targetPage;
        private string title;

        public BaseViewModel()
        {
           
        }
        public string HeaderText
        {
            get { return _HeaderText; }
            set
            {
                _HeaderText = value;

                OnPropertyChanged();
            }
        }
        public Type TargetPage
        {
            get { return _targetPage; }
            set { SetProperty(ref _targetPage, value); }
        }

        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }


        protected bool SetProperty<T>(ref T backingStore, T value, Action onChanged = null,
            [CallerMemberName] string propertyName = "")
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;
            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }

     
        #region INotifyPropertyChanged

        public new event PropertyChangedEventHandler PropertyChanged;

        protected new void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChangedEventHandler changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion INotifyPropertyChanged

      
    }
}
