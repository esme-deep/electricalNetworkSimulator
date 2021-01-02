using System;
using System.Collections.Generic;
using System.Text;

namespace electrical_network_simulator
{
    class Consumer {
        public string name;
        public double energy;
        public Consumer (string name, double energy)
        {
            this.name = name;
            this.energy = energy;
        }

    }
}
