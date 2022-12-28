using System;

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
    }
}
