using System;
using System.Threading.Tasks;

namespace Ave.Extensions.Functional
{
    public static class ResultOnFailureDoExtensions
    {
        public static Result<Tin, E> OnFailureDo<Tin, E>(this Result<Tin, E> source, Action<E> action)
        {
            if (source.IsFailure)
            {
                action(source.Error);
            }

            return source;
        }

		public static async Task<Result<Tin, E>> OnFailureDo<Tin, E>(this Task<Result<Tin, E>> awaitableSource, Action<E> action)
		{
            var source = await awaitableSource.ConfigureAwait(false);
			if (source.IsFailure)
			{
				action(source.Error);
			}

			return source;
		}
	}
}
