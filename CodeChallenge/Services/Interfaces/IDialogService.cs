﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IDialogService.cs" company="ArcTouch LLC">
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
//   Defines the IDialogService type.
// </summary>
//  --------------------------------------------------------------------------------------------------------------------

namespace CodeChallenge.Services.Interfaces
{
    public interface IDialogService
    {
        void ShowDialog(string text, string title = null);
    }
}