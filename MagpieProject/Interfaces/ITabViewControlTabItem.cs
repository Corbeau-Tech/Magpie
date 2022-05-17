using System;
using Xamarin.Forms;

namespace MagpieProject.Interfaces
{
    public interface ITabViewControlTabItem
    {
        string TabViewControlTabItemTitle { get; set; }
        ImageSource TabViewControlTabItemIconSource { get; set; }

        /// <summary>
        /// called when the view receives focus
        /// </summary>
        void TabViewControlTabItemFocus();
    }
}
