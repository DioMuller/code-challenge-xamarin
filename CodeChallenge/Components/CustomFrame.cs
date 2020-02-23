using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace CodeChallenge.Components
{
    public class CustomFrame : Frame
    {
        #region Bindable Properties
        public static BindableProperty ElevationProperty = BindableProperty.Create(nameof(Elevation), typeof(float), typeof(CustomFrame), 5.0f);

        public float Elevation
        {
            get => (float)GetValue(ElevationProperty);
            set => SetValue(ElevationProperty, value);
        }
        #endregion
    }
}
