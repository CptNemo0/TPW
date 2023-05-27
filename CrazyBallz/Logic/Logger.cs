using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Newtonsoft.Json;
using System.IO;

namespace Logic
{
    internal class Logger : LoggingApi
    {
        private string filename;
        private StringBuilder buffer;

        public override string Filename { get => filename; set => filename = value; }

        public Logger(string filename)
        {
            buffer = new StringBuilder();
            Filename = filename;
        }

        public override void LogCollision(ILogicBall a, ILogicBall b)
        {
            var collision = new
            {
                x_collision = (int)((a.Position_X + b.Position_X) / 2),
                y_collision = (int)((a.Position_Y + b.Position_Y) / 2),
                date = DateTime.Now.ToString("hh-mm-ss-dd-MM-yyyy"),
            };

            buffer.Append(JsonConvert.SerializeObject(collision));
        }

        public override void Write()
        {
            File.AppendAllText(filename, buffer.ToString() + Environment.NewLine);
            buffer = new StringBuilder();
        }
    }
}
