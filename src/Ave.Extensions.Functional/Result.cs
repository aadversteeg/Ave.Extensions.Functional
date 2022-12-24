using System;

namespace Ave.Extensions.Functional
{
	public struct Result<T,E>
	{
		private readonly bool _isSuccess;
		private readonly E _error;
		private readonly T _value;

		private Result(bool isSuccess, T value, E error)
		{
			_isSuccess = isSuccess;
			_value = value;
			_error = error;
		}

		public bool IsSuccess => _isSuccess;

		public bool IsFailure => !_isSuccess;

		public E Error
		{ 
			get 
			{ 
				if(_isSuccess)
				{
					throw new InvalidOperationException();
				}

				return _error; 
			} 
		}

		public T Value
		{
			get
			{
				if (!_isSuccess)
				{
					throw new InvalidOperationException();
				}

				return _value;
			}
		}

		public static Result<T,E> Success(T value)
		{
			return new Result<T,E>(true, value, default);
		}

		public static Result<T,E> Failure(E error)
		{
			return new Result<T,E>(false, default, error);
		}
	}
}
