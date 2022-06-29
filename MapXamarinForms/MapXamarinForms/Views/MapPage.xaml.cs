using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace MapXamarinForms.Views
{
    public partial class MapPage : ContentPage
    {
        public MapPage()
        {
            InitializeComponent();
            NavigationPage.SetHasBackButton(this, true);
        }
    }
}
