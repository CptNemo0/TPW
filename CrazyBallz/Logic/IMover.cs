using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public abstract class IMover
    {
        public abstract IBall Ball { get; set; }
        public abstract Vector2 BoardSize { get; set; }
        public abstract void Stop();
        public abstract void Move();
        public abstract void ChangeXdirection();
        public abstract void ChangeYdirection();        
    }
}
