using System;
using System.Runtime.CompilerServices;

namespace Ave.Extensions.Functional
{
	public static class ResultOnSuccessMapExtensions
	{
		public static Result<Tout,E> OnSuccessMap<Tin,Tout, E>(this Result<Tin,E> source, Func<Tin,Tout> map)
		{
			if(source.IsSuccess)
			{
				return Result<Tout, E>.Success(map(source.Value));
			}
			return Result<Tout, E>.Failure(source.Error);
		}
    }
}
