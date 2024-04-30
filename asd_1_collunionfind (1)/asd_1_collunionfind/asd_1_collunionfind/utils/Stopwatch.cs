using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace asd_1_collunionfind.utils
{
    internal class Stopwatch
    {
        private long _start;

        /// <summary>
        /// Initializes a new stopwatch
        /// </summary>
        public Stopwatch()
        {
            _start = Now();
        }

        private static long Now()
        {
            return DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
        }

        /// <summary>
        /// Reset the time stamp
        /// </summary>
        public void Reset()
        {
            _start = Stopwatch.Now();
        }

        /// <summary>
        /// Returns the Elapsed time [s] since the stopwatch was reset
        /// </summary>
        /// <returns>Elapsed time [s]</returns>
        public double GetElapsedTime()
        {
            return (Stopwatch.Now() - _start) / 1000.0;
        }
    }
}
