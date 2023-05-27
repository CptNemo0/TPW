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
        private bool batchFirst;
        private bool firstEver;

        public override string Filename { get => filename; set => filename = value; }

        public Logger(string filename)
        {
            buffer = new StringBuilder();
            this.filename = filename;
            buffer.AppendLine("{\n \"collisions\":[\n");
            batchFirst = true;
            firstEver = true;
        }

        public override void LogCollision(ILogicBall a, ILogicBall b)
        {
            var collision = new
            {
                x_collision = (int)((a.Position_X + b.Position_X) / 2),
                y_collision = (int)((a.Position_Y + b.Position_Y) / 2),
                date = DateTime.Now.ToString("hh:mm:ss | dd-MM-yyyy"),
            };
            if(firstEver && batchFirst)
            {
                buffer.Append(JsonConvert.SerializeObject(collision));
                batchFirst = false;
                firstEver = false;
            }
            else if (batchFirst && !firstEver)
            {
                buffer.Append(",\n" + JsonConvert.SerializeObject(collision));
                batchFirst = false;
            }
            else
            {
                buffer.Append(",\n" + JsonConvert.SerializeObject(collision));
            }
        }

        public override void Write()
        {
            File.AppendAllText(filename, buffer.ToString());
            buffer = new StringBuilder();
            batchFirst = true;
        }

        public override void Finish()
        {
            File.AppendAllText(filename, "\n]}");
        }
    }
}
