using System;

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
    }
}
