using asd_1_collunionfind.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace asd_1_collunionfind
{
    internal abstract class AbstractRunnableApp
    {
        virtual public void Run(string[]? args = null)
        {
            Logger.WriteLine($"Run the \"{this.GetType().FullName}\"");
        }
    }
}
