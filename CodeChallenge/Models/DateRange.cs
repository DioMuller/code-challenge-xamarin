﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DateRange.cs" company="ArcTouch LLC">
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
//   Defines the DateRange type.
// </summary>
//  --------------------------------------------------------------------------------------------------------------------

using System;

namespace CodeChallenge.Models.Data
{
    public class DateRange
    {
        public DateTimeOffset Maximum { get; set; }

        public DateTimeOffset Minimum { get; set; }
    }
}
