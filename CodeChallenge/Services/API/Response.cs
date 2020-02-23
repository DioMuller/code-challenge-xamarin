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
        public string Error { get; private set; }
        public Exception Exception { get; private set; }
        #endregion

        #region Constructors
        public Response(T data)
        {
            Result = data;
            IsError = false;
            Error = null;
            Exception = null;
        }

        public Response(Exception exception)
        {
            Result = default(T);
            IsError = true;
            Error = exception.Message;
            Exception = exception;
        }

        public Response(string error)
        {
            Result = default(T);
            IsError = true;
            Error = error;
            Exception = null;
        }
        #endregion
    }
}
