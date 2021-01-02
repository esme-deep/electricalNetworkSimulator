using System;
using System.Collections.Generic;
using System.Text;

namespace electrical_network_simulator
{
    class Dissipator : Consumer
    {
        public int line;
        public Dissipator(string name,double energy,int line) : base(name,energy)
        {
            this.energy = 50;
            this.line = line;

        }
    }
}
