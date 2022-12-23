using System;

namespace Ave.Extensions.Functional
{
	public class Error
	{
		public Error(string code, string message)
		{
			if(string.IsNullOrEmpty(code))
			{
				throw new ArgumentNullException(nameof(code));
			}

			if(string.IsNullOrEmpty(message))
			{
				throw new ArgumentNullException(nameof(message));
			}

			Code = code;	
			Message = message;	
		}

		public string Code { get; }

		public string Message { get; }
	}
}
