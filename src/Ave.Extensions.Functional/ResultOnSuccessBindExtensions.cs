using System;
using System.Runtime.CompilerServices;

namespace Ave.Extensions.Functional
{
	public static class ResultOnSuccessBindExtensions
	{
        public static Result<Tout, E> OnSuccessBind<Tin, Tout, E>(this Result<Tin, E> source, Func<Tin, Result<Tout,E>> bind)
        {
            if (source.IsSuccess)
            {
                return bind(source.Value);
            }
            return Result<Tout, E>.Failure(source.Error);
        }
    }
}
