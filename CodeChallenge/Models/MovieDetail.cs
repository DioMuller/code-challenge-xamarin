// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MovieDetail.cs" company="ArcTouch LLC">
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
//   Defines the MovieDetail type.
// </summary>
//  --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;

namespace CodeChallenge.Models
{
    public class MovieDetail : Movie
    {
        public int VoteCount { get; set; }

        public bool Video { get; set; }

        public double VoteAverage { get; set; }

        public double Popularity { get; set; }

        public string OriginalLanguage { get; set; }

        public string OriginalTitle { get; set; }

        public List<Genre> Genres { get; set; }

        public bool Adult { get; set; }
    }
}
