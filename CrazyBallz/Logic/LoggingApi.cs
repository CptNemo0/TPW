using System.IO;

namespace Logic
{
    public abstract class LoggingApi
    {
        public abstract string Filename { get; set; }

        public static LoggingApi Instatiate(string filename)
        {
            try
            {
                File.WriteAllText(filename, "");
            }
            catch 
            { 
                File.Create(filename);
            }
            return new Logger(filename);
        }
        public abstract void LogCollision(ILogicBall a, ILogicBall b);
        public abstract void Write();
        public abstract void Finish();
    }
}
