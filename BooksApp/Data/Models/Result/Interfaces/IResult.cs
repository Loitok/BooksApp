using BooksApp.Data.Models.Result.Implementations;

namespace BooksApp.Data.Models.Result.Interfaces
{
    public interface IResult
    {
        bool Success { get; }
        ResponseMessage ErrorMessage { get; }
    }
}
