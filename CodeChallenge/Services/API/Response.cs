// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Response.cs" company="ArcTouch LLC">
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
//   Defines the Response type.
// </summary>
//  --------------------------------------------------------------------------------------------------------------------

using Refit;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeChallenge.Services.API
{
    public class Response<T>
    {
        #region Properties
        public T Result { get; private set; }
        public bool IsError { get; private set; }
        public bool IsApiError { get; private set; }
        public int StatusCode { get; private set; }
        public string Error { get; private set; }
        public Exception Exception { get; private set; }
        #endregion

        #region Constructors
        public Response(T data)
        {
            Result = data;
            IsError = false;
            IsApiError = false;
            StatusCode = 0;
            Error = null;
            Exception = null;
        }

        public Response(Exception exception)
        {
            Result = default(T);
            IsError = true;
            IsApiError = exception is ApiException;
            StatusCode = IsApiError ? (int) (exception as ApiException).StatusCode : 0;
            Error = exception.Message;
            Exception = exception;
        }

        public Response(string error, bool isApiError = false, int statusCode = 0)
        {
            Result = default(T);
            IsError = true;
            IsApiError = isApiError;
            StatusCode = statusCode;
            Error = error;
            Exception = null;
        }
        #endregion
    }
}
