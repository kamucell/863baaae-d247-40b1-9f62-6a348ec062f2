using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GunvorAssessment.LockDown
{
    public class LockDownManager : ILockDownManager
    {
        private bool _isLocked;

        public event EventHandler LockDownStarted;
        public event EventHandler LockDownEnded;

        public void StartLockDown()
        {
            if (!_isLocked)
            {
                _isLocked = true;
                OnLockDownStarted();
            }
        }

        public void EndLockDown()
        {
            if (_isLocked)
            {
                _isLocked = false;
                OnLockDownEnded();
            }
        }

        public bool IsLocked()
        {
            return _isLocked;
        }

        protected virtual void OnLockDownStarted()
        {
            LockDownStarted?.Invoke(this, EventArgs.Empty);
        }

        protected virtual void OnLockDownEnded()
        {
            LockDownEnded?.Invoke(this, EventArgs.Empty);
        }
    }
}
