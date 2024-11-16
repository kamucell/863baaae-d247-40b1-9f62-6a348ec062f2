using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GunvorAssessment.Exceptions
{
    public  class AmountLessThanZero : GunvorAssessmentException
    {
        public AmountLessThanZero() :base("Amount Can Not Less Than Zero")
        {
            
        }
    }
}
