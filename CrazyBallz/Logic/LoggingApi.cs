using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public abstract class LoggingApi
    {
        public abstract string Filename { get; set; }

        public static LoggingApi Instatiate(string filename)
        {
            return new Logger(filename);
        }
        public abstract void LogCollision(ILogicBall a, ILogicBall b);
        public abstract void Write();
    }
}
