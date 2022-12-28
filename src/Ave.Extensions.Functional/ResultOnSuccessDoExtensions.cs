using System;
using System.Threading.Tasks;

namespace Ave.Extensions.Functional
{
    public static class ResultOnSuccessDoExtensions
    {
        public static Result<Tin, E> OnSuccessDo<Tin, E>(this Result<Tin, E> source, Action<Tin> action)
        {
            if (source.IsSuccess)
            {
                action(source.Value);
            }

            return source;
        }

		public static async Task<Result<Tin, E>> OnSuccessDo<Tin, E>(this Task<Result<Tin, E>> awaitableSource, Action<Tin> action)
		{
            var source = await awaitableSource;
			if (source.IsSuccess)
			{
				action(source.Value);
			}

			return source;
		}
	}
}
