using System;
using Xamarin.Forms;

namespace MagpieProject.Templates
{
    public class PersonListDataTemplateSelector : DataTemplateSelector
    {
        public DataTemplate PersonTemplate { get; set; }
        public DataTemplate CounterTemplate { get; set; }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            if (item is Models.Person)
                return PersonTemplate;
            else
                return CounterTemplate;
        }
    }
}
