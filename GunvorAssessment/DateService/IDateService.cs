using System;

namespace GunvorAssessment.DateService
{
	/// <summary>
	/// This interface returns current date in the system.
	/// IT allows to fake the date for unit tests
	/// </summary>
	/// <remarks>
	/// You CANNOT modify this file
	/// </remarks>
	public interface IDateService
	{
		DateTimeOffset GetCurrentDateTime();
	}
}
