using System;
using System.Collections.Generic;

namespace Ave.Extensions.Functional
{
	public class Result
	{
		private readonly IReadOnlyCollection<Error> _errors;

		internal Result(IReadOnlyCollection<Error> errors) {
			_errors = errors;
		}

		public bool IsSuccess => _errors == null;

		public bool IsFailure => _errors != null;

		public IReadOnlyCollection<Error> Errors 
		{ 
			get 
			{ 

				if(_errors == null)
				{
					throw new InvalidOperationException();
				}

				return _errors; 
			} 
		}

		public static Result Success()
		{
			return new Result(null);
		}

		public static Result<T> Success<T>(T value)
		{
			return new Result<T>(value);
		}

		public static Result Failure(IReadOnlyCollection<Error> errors)
		{
			return new Result(errors);
		}

		public static Result Failure(Error error)
		{
			return new Result(new[] { error } );
		}
	}


	public class Result<T> : Result
	{
		private readonly T _value;

		internal Result(T value)	
			: base(null)
		{
			_value = value;
		}

		private Result(IReadOnlyCollection<Error> errors)
	        : base( errors)
		{
			_value = default(T);
		}

		public T Value
		{
			get
			{
				if (IsFailure)
				{
					throw new InvalidOperationException();
				}

				return _value;
			}
		}

		public static Result<T> Success(T value)
		{
			return new Result<T>(value);
		}

		public static new Result<T> Failure(Error error)
		{
			return new Result<T>(new[] { error });
		}

		public static new Result<T> Failure(IReadOnlyCollection<Error> errors)
		{
			return new Result<T>(errors);
		}
	}
}
