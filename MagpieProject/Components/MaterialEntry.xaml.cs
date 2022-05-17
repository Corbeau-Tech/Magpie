using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MagpieProject.Components
{
    public partial class MaterialEntry : ContentView
    {
        public static void Init() { }
        public static BindableProperty TextProperty = BindableProperty.Create(nameof(Text), typeof(string), typeof(MaterialEntry), defaultBindingMode: BindingMode.TwoWay,propertyChanged: (bindable,oldVal,newVal)=>
        {
            var matEntry = (MaterialEntry)bindable;
            matEntry.EntryField.Text = (string)newVal;
        });
        public static BindableProperty imgSourceProperty = BindableProperty.Create(nameof(imgSource), typeof(ImageSource), typeof(MaterialEntry), defaultBindingMode: BindingMode.TwoWay);

        public static BindableProperty PlaceholderProperty = BindableProperty.Create(nameof(Placeholder), typeof(string), typeof(MaterialEntry), defaultBindingMode: BindingMode.TwoWay, propertyChanged: (bindable, oldVal, newval) =>
        {
            var matEntry = (MaterialEntry)bindable;
            matEntry.EntryField.Placeholder = (string)newval;
            matEntry.HiddenLabel.Text = (string)newval;
        });

        public static BindableProperty IsPasswordProperty = BindableProperty.Create(nameof(IsPassword), typeof(bool), typeof(MaterialEntry), defaultValue: false, propertyChanged: (bindable, oldVal, newVal) =>
        {
            var matEntry = (MaterialEntry)bindable;
            matEntry.EntryField.IsPassword = (bool)newVal;
        });
       
        
        public static BindableProperty KeyboardProperty = BindableProperty.Create(nameof(Keyboard), typeof(Keyboard), typeof(MaterialEntry), defaultValue: Keyboard.Default, propertyChanged: (bindable, oldVal, newVal) =>
        {
            var matEntry = (MaterialEntry)bindable;
            matEntry.EntryField.Keyboard = (Keyboard)newVal;
        });

        public static BindableProperty IsErrorProperty = BindableProperty.Create(nameof(IsError), typeof(bool), typeof(MaterialEntry), defaultValue: false, propertyChanged: (bindable, oldVal, newVal) =>
        {
            var matEntry = (MaterialEntry)bindable;
            //matEntry.EntryField.IsPassword = (bool)newVal;
        });

        public static BindableProperty AccentColorProperty = BindableProperty.Create(nameof(AccentColor), typeof(Color), typeof(MaterialEntry), defaultValue: Color.Accent);
        public Color AccentColor
        {
            get
            {
                return (Color)GetValue(AccentColorProperty);
            }
            set
            {
                SetValue(AccentColorProperty, value);
            }
        }
        public Keyboard Keyboard
        {
            get
            {
                return (Keyboard)GetValue(KeyboardProperty);
            }
            set
            {
                SetValue(KeyboardProperty, value);
            }
        }

        public bool IsPassword
        {
            get
            {
                return (bool)GetValue(IsPasswordProperty);
            }
            set
            {
                SetValue(IsPasswordProperty, value);
            }
        }
        private bool _IsPasswordVisible;

        public bool IsPasswordVisible
        {
            get { return _IsPasswordVisible; }
            set
            {
                _IsPasswordVisible = value;

                OnPropertyChanged();
            }
        }

        public bool IsError
        {
            get
            {
                return (bool)GetValue(IsErrorProperty);
            }
            set
            {
                SetValue(IsErrorProperty, value);
            }
        }

        public string Text
        {
            get
            {
                return (string)GetValue(TextProperty);
            }
            set
            {
                SetValue(TextProperty, value);
            }
        }
        public ImageSource imgSource
        {
            get
            {
                return (ImageSource)GetValue(imgSourceProperty);
            }
            set
            {
                SetValue(imgSourceProperty, value);
            }
        }
        public string Placeholder
        {
            get
            {
                return (string)GetValue(PlaceholderProperty);
            }
            set
            {
                SetValue(PlaceholderProperty, value);
            }
        }
        public MaterialEntry()
        {
            InitializeComponent();
            EntryField.BindingContext = this;
            ImageField.BindingContext = this;
            mainFrame.BindingContext = this;
            IsPasswordVisible = false;
            EntryField.Focused += async (s, a) =>
            {
                if (!IsError)
                {
                    HiddenLabel.TextColor = AccentColor;
                }
                HiddenLabel.IsVisible = true;
                if (string.IsNullOrEmpty(EntryField.Text))
                {
                    // animate both at the same time
                    await Task.WhenAll(
                        HiddenLabel.FadeTo(1, 60),
                        HiddenLabel.TranslateTo(HiddenLabel.TranslationX, EntryField.Y - EntryField.Height, 200, Easing.BounceIn)
                     );
                    EntryField.Placeholder = null;
                }
            };
            EntryField.Unfocused += async (s, a) =>
            {

                if (!IsError)
                {
                    HiddenLabel.TextColor = Color.Gray;
                }
                if (string.IsNullOrEmpty(EntryField.Text))
                {
                    // animate both at the same time
                    await Task.WhenAll(
                        HiddenLabel.FadeTo(0, 180),
                        HiddenLabel.TranslateTo(HiddenLabel.TranslationX, EntryField.Y, 200, Easing.BounceIn)
                       

                     );
                    HiddenLabel.IsVisible = false;
                    EntryField.Placeholder = Placeholder;
                }
                
            };
        }

        void showpassword_Tapped(System.Object sender, System.EventArgs e)
        {
            //if (!EntryField.IsPassword) return;

                if (IsPasswordVisible) { IsPasswordVisible = false; EntryField.IsPassword = true; }
                else { IsPasswordVisible = true; EntryField.IsPassword = false; }
        }
    }
}
