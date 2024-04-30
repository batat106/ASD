using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace asd_1_collunionfind.utils
{
    /// <summary>
    /// A helper class to write an informtaion into system console
    /// </summary>
    internal static class Logger
    {
        /// <summary>
        /// Write all arguments sequentially in a single line
        /// </summary>
        /// <param name="args">A sequence of arguments</param>
        public static void Write(params object[] args)
        {
            for (int i=0; i < args.Length; i++)
            {
                Console.Write(args[i].ToString());
                if (i < args.Length - 1)
                {
                    Console.Write("; ");
                }
            }
        }

        /// <summary>
        /// Write all arguments starting from a new line
        /// </summary>
        /// <param name="args">A sequence of arguments</param>
        public static void WriteLine(params object[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine();
                return;
            }

            foreach (var arg in args)
            {
                Console.WriteLine(arg.ToString());
            }
        }
    }
}
