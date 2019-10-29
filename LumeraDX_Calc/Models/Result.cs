using System;

namespace LumeraDX_Calc.Models
{
    public class Result<T>
    {
        /* 
         * in a better defined result type, attempts to access value 
         * property of a failure would also throw/log exceptions,
         * or we might even have polymorphic Result<T> <- Success<T>, Result<T> <- Failure<T>
         * This is just a simple implementation to serve the purpose of telling 
         * the rest of the program how to deal with what went wrong
         */
        public T Value { get; }
        public Exception Exception { get; }
        public bool Success => Exception == null;
        public Result(T value, Exception exception = null)
        {
            Exception = exception;
            Value = value;
        }
    }

    public static class ResultExtensions
    {
        public static void Match<T>(this Result<T> result, Action<T> onSuccess, Action<Exception> onError)  
        {
            if (result.Success)
            {
                onSuccess(result.Value);
            }
            else
            {
                onError(result.Exception);
            }
        }
    }
}