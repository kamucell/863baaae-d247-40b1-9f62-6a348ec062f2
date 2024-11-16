using System;

namespace GunvorAssessment.LockDown
{
	/// <summary>
	/// This interface is used to manage LockDown mechanism. Once Lock down is started, then no accounts can be modified (deposits or Withdrawals are forbidden)
	/// </summary>
	/// <remarks>
	///	You CANNOT modify this file
	/// </remarks>
	public interface ILockDownManager
	{
		event EventHandler LockDownStarted;

		event EventHandler LockDownEnded;

		void StartLockDown();

		void EndLockDown();
	}
}