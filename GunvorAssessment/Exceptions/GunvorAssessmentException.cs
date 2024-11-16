using System;

namespace GunvorAssessment.Exceptions
{
	[Serializable]
	public class GunvorAssessmentException : Exception
	{
		public GunvorAssessmentException() { }
		public GunvorAssessmentException(string message) : base(message) { }
		public GunvorAssessmentException(string message, Exception inner) : base(message, inner) { }
		protected GunvorAssessmentException(
			System.Runtime.Serialization.SerializationInfo info,
			System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
	}
}