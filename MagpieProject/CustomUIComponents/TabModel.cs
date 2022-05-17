using System;
using MagpieProject.Interfaces;
using MagpieProject.ViewModels;
using Xamarin.Forms;

namespace MagpieProject.CustomUIComponents
{
    public class TabModel : BaseViewModel, ITabViewControlTabItem
    {
        public string TabViewControlTabItemTitle { get; set; }
        public ImageSource TabViewControlTabItemIconSource { get; set; }
        private ContentView _Page;

        public ContentView Page
        {
            get
            {
                return _Page;
            }
            set
            {
                _Page = value;
                OnPropertyChanged();
            }
        }

        public void TabViewControlTabItemFocus()
        {
            
        }
    }
}
