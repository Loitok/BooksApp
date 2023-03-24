using BooksApp.Data.Models.Result.Interfaces;

namespace BooksApp.Data.Models.Result.Generics
{
    public interface IResult<out TData> : IResult
    {
        TData Data { get; }
    }
}
