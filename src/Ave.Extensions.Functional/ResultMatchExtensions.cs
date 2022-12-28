using System;
using System.Threading.Tasks;

namespace Ave.Extensions.Functional
{
	public static class ResultMatchExtensions
	{
		public static Result<TOut, E> Match<TIn, TOut, E>(this Result<TIn, E> source, Func<TIn, TOut> onSuccess, Func<E, TOut> onError)
		{
			if(source.IsSuccess) {
				return Result<TOut, E>.Success(onSuccess(source.Value));
			}

			return Result<TOut, E>.Success(onError(source.Error));
		}

		public static async Task<Result<TOut, E>> Match<TIn, TOut, E>(this Task<Result<TIn, E>>  awaitableSource, Func<TIn, TOut> onSuccess, Func<E, TOut> onError)
		{
			var source = await awaitableSource.ConfigureAwait(false);
			if (source.IsSuccess)
			{
				return Result<TOut, E>.Success(onSuccess(source.Value));
			}

			return Result<TOut, E>.Success(onError(source.Error));
		}
	}
}
