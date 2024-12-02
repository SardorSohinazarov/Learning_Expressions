using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expressions_3
{
    internal interface IDependencyContainer
    {
        void Register<TInterface, TImplementation>() where TImplementation : TInterface;
        T Resolve<T>();
    }
}
