using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GGJ2019.Tests.Common
{
    internal interface ITest
    {
        void SetupContainer();

        void Construct();
    }
}
