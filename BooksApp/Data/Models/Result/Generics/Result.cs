﻿using BooksApp.Data.Models.Result.Implementations;
using System;

namespace BooksApp.Data.Models.Result.Generics
{
    internal class Result<TData> : IResult<TData>
    {
        public bool Success { get; private set; }
        public TData Data { get; private set; }
        public ResponseMessage ErrorMessage { get; private set; }

        private Result() { }

        public static Result<TData> CreateSuccess()
            => new Result<TData>
            {
                Success = true,
                Data = default
            };

        public static Result<TData> CreateSuccess(TData data)
            => new Result<TData>
            {
                Success = true,
                Data = data
            };

        public static Result<TData> CreateFailure(string message)
        {
            return new Result<TData>
            {
                Success = false,
                ErrorMessage = new ResponseMessage(message)
            };
        }

        public static Result<TData> CreateFailure(string message, Exception exception)
        {
            return new Result<TData>
            {
                Success = false,
                ErrorMessage = new ResponseMessage(message, exception)
            };
        }

        public static Result<TData> CreateFailure(ResponseMessage errorMessage)
        {
            return new Result<TData>
            {
                Success = false,
                ErrorMessage = errorMessage
            };
        }

        public static Result<TData> CreateFailure(TData data, Exception exception = null)
            => new Result<TData>()
            {
                Success = false,
                Data = data,
                ErrorMessage = new ResponseMessage("Error message", exception)
            };


    }
}
