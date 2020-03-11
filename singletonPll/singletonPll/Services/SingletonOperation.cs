using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace singletonPll.Services
{
    public interface ISingletonOperation: IOperations
    {

    }
    public class SingletonOperation : ISingletonOperation
    { 
        public Guid Id { get; }

        public SingletonOperation()
        {
            Id = Guid.NewGuid();
        }
    }
}
