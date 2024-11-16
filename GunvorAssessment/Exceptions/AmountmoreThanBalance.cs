using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GunvorAssessment.Exceptions
{
    public  class AmountmoreThanBalance : UnauthorizedAccountOperationException
    {
        public AmountmoreThanBalance() :base("The amount cannot exceed the balance.")
        {
            
        }
    }
}
