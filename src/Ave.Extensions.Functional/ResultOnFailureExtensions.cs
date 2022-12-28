using System;

namespace Ave.Extensions.Functional
{
    public static class ResultOnFailureExtensions
    {   
        public static Result<T, Eout> OnFailure<T, Ein, Eout>(this Result<T,Ein> source, Func<Ein,Eout> mapError)
        {
            if(source.IsFailure)
            {
                return Result<T,Eout>.Failure(mapError(source.Error));
            }
            return Result<T, Eout>.Success(source.Value);
        }
    }
}
