using System;

namespace GunvorAssessment.Exceptions
{

	[Serializable]
	public class UnauthorizedAccountOperationException : GunvorAssessmentException
	{
		public UnauthorizedAccountOperationException() { }
		public UnauthorizedAccountOperationException(string message) : base(message) { }
		public UnauthorizedAccountOperationException(string message, Exception inner) : base(message, inner) { }
		protected UnauthorizedAccountOperationException(
		  System.Runtime.Serialization.SerializationInfo info,
		  System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
	}
}
