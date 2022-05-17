using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace MagpieProject.CustomUIComponents
{
    public class TabPageCustom : ContentView
    {
        #region ItemsSource property

        public static readonly BindableProperty ItemsSourceProperty =
            BindableProperty.Create(
                nameof(ItemsSource),
                typeof(IList),
                typeof(TabPageCustom),
                null,
                propertyChanged: OnItemsSourceModified);

        public IList ItemsSource
        {
            get
            {
                return (IList)GetValue(ItemsSourceProperty);
            }
            set
            {
                SetValue(ItemsSourceProperty, value);
            }
        }

        private static void OnItemsSourceModified(object sender, object oldValue, object newValue)
        {
            TabPageCustom rv = (TabPageCustom)sender;
            rv._itemsContainerLayout.Children.Clear();

            IEnumerator iter = ((IList)newValue).GetEnumerator();
            int index = 0;
            while (iter.MoveNext())
            {
                string label = (string)iter.Current;

                StackLayout layout = new StackLayout()
                {
                    Orientation = StackOrientation.Vertical,
                    VerticalOptions = LayoutOptions.FillAndExpand,
                    HorizontalOptions = LayoutOptions.Start,
                    Padding = new Thickness(10, 10, 10, 0),
                };
                Label titleLabel = new Label()
                {
                    Text = label,
                    TextColor = rv.TextColor,
                    FontSize = rv.FontSize,
                    Style = rv.Style,
                    VerticalTextAlignment = TextAlignment.Center,
                    HorizontalTextAlignment = TextAlignment.Center,
                    VerticalOptions = LayoutOptions.FillAndExpand,
                    HorizontalOptions = LayoutOptions.FillAndExpand
                };

                BoxView box = new BoxView()
                {
                    BackgroundColor = rv.BarColor,
                    VerticalOptions = LayoutOptions.EndAndExpand,
                    HeightRequest = 2,
                    HorizontalOptions = LayoutOptions.FillAndExpand
                };
                layout.Children.Add(titleLabel);
                layout.Children.Add(box);

                layout.GestureRecognizers.Add(new TapGestureRecognizer()
                {
                    Command = new Command((obj) =>
                    {
                        rv.OnSelectedItem(label);
                    })
                });

                ++index;

                rv._itemsContainerLayout.Children.Add(layout);
            }

            rv.OnSelectedItem(((List<string>)rv.ItemsSource).ElementAt(rv.SelectedItemIndex));
        }

        #endregion ItemsSource property

        #region Textcolor property

        public static readonly BindableProperty TextColorProperty =
            BindableProperty.Create(nameof(TextColor), typeof(Color), typeof(TabPageCustom), Color.Black);

        public Color TextColor
        {
            get
            {
                return (Color)GetValue(TextColorProperty);
            }
            set
            {
                SetValue(TextColorProperty, value);
            }
        }

        #endregion Textcolor property

        public static new readonly BindableProperty StyleProperty =
            BindableProperty.Create(nameof(Style), typeof(Style), typeof(TabPageCustom), null);

        public new Style Style
        {
            get
            {
                return (Style)GetValue(StyleProperty);
            }
            set
            {
                SetValue(StyleProperty, value);
            }
        }

        #region Textcolor property

        public static readonly BindableProperty BarColorProperty =
            BindableProperty.Create(nameof(BarColor), typeof(Color), typeof(TabPageCustom), Color.Black);

        public Color BarColor
        {
            get
            {
                return (Color)GetValue(BarColorProperty);
            }
            set
            {
                SetValue(BarColorProperty, value);
            }
        }

        #endregion Textcolor property

        #region Textcolor property

        public static readonly BindableProperty FontSizeProperty =
            BindableProperty.Create(nameof(FontSize), typeof(int), typeof(TabPageCustom), 13);

        public int FontSize
        {
            get
            {
                return (int)GetValue(FontSizeProperty);
            }
            set
            {
                SetValue(FontSizeProperty, value);
            }
        }

        #endregion Textcolor property

        #region SelectedItem property

        public static readonly BindableProperty SelectedItemIndexProperty =
            BindableProperty.Create(nameof(SelectedItemIndex), typeof(int), typeof(TabPageCustom), 0);

        public int SelectedItemIndex
        {
            get
            {
                return (int)GetValue(SelectedItemIndexProperty);
            }
            set
            {
                SetValue(SelectedItemIndexProperty, value);
            }
        }

        #endregion SelectedItem property

        #region Textcolor property

        public static readonly BindableProperty ItemSelectedProperty =
            BindableProperty.Create(nameof(ItemSelected), typeof(Command), typeof(TabPageCustom), null);

        public Command ItemSelected
        {
            get
            {
                return (Command)GetValue(ItemSelectedProperty);
            }
            set
            {
                SetValue(ItemSelectedProperty, value);
            }
        }

        #endregion Textcolor property

        private readonly StackLayout _itemsContainerLayout;

        public TabPageCustom()
        {
            ScrollView scroll = new ScrollView()
            {
                HorizontalOptions = LayoutOptions.Fill,
                Orientation = ScrollOrientation.Horizontal,
            };
            StackLayout _mainLayout = new StackLayout()
            {
                Padding = new Thickness(0),
                Spacing = 0
            };
            scroll.Content = _mainLayout;

            _itemsContainerLayout = new StackLayout()
            {
                Orientation = StackOrientation.Horizontal,

                Padding = new Thickness(5, 5, 5, 0),
                Spacing = 0
            };
            _mainLayout.Children.Add(_itemsContainerLayout);

            Content = _mainLayout;
        }

        private void OnSelectedItem(string labelTitle)
        {
            int i = 0;
            IEnumerator iter = ItemsSource.GetEnumerator();

            if (this.SelectedItemIndex > -1)
            {
                StackLayout itemStack = (StackLayout)_itemsContainerLayout.Children.ToArray()[this.SelectedItemIndex];
                BoxView bv = (BoxView)itemStack.Children.ToArray()[1];
                bv.BackgroundColor = this.BackgroundColor;
            }

            while (iter.MoveNext())
            {
                StackLayout itemStack = (StackLayout)_itemsContainerLayout.Children.ToArray()[i];
                BoxView bv = (BoxView)itemStack.Children.ToArray()[1];

                if (((string)iter.Current).CompareTo(labelTitle) == 0)
                {
                    bv.BackgroundColor = this.BarColor;
                    this.SelectedItemIndex = i;
                }
                else
                {
                    bv.BackgroundColor = this.BackgroundColor;
                }
                i += 1;
            }

            if (ItemSelected != null)
            {
                ItemSelected.Execute(this.SelectedItemIndex);
            }
        }
    }
}
