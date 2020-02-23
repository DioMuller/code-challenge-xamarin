// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CustomFrame.cs" company="ArcTouch LLC">
//   Copyright 2020 ArcTouch LLC.
//   All rights reserved.
//
//   This file, its contents, concepts, methods, behavior, and operation
//   (collectively the "Software") are protected by trade secret, patent,
//   and copyright laws. The use of the Software is governed by a license
//   agreement. Disclosure of the Software to third parties, in any form,
//   in whole or in part, is expressly prohibited except as authorized by
//   the license agreement.
// </copyright>
// <summary>
//   Defines the CustomFrame type.
// </summary>
//  --------------------------------------------------------------------------------------------------------------------

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
