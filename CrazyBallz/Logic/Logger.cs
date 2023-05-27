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
    public class Logger
    {
        private string filename;
        private StringBuilder buffer; 

        public string Filename { get => filename; set => filename = value; }

        public Logger(string filename)
        {
            this.buffer = new StringBuilder();
            this.Filename = filename;
        }

        public void LogCollision(IBall a, IBall b)
        {
            var collision = new
            {
                x_collision = (int)((a.Position_X + b.Position_X) / 2),
                y_collision = (int)((a.Position_Y + b.Position_Y) / 2),
                date = DateTime.Now.ToString("dd-MM-yyyy"),
            };

            buffer.Append(JsonConvert.SerializeObject(collision));
        }

        public void Write()
        {
            File.AppendAllText(filename, buffer.ToString() + Environment.NewLine);
            buffer = new StringBuilder();
        }
    }
}
