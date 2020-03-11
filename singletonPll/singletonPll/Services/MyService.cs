using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace singletonPll.Services
{
    public interface IMyService
    {

    }
    public class MyService : IMyService
    {
        private readonly ISingletonOperation _singletonOperation; 

        public MyService(ISingletonOperation singletonOperation)
        {
            this._singletonOperation = singletonOperation;
            
        }
    }
}
