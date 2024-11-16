using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GunvorAssessment.Exceptions
{
    public  class ExceedOverDraftLimit : UnauthorizedAccountOperationException
    {
        public ExceedOverDraftLimit() :base("The limit has been exceeded.")
        {
            
        }
    }
}
