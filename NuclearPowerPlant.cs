using System;
using System.Collections.Generic;
using System.Text;

namespace electrical_network_simulator
{
    class NuclearPowerPlant: PowerPlant
    {
        public new double CO2;
        public NuclearPowerPlant(string name, double energy) : base(name, energy)
        {
            base.CO2 = base.energy / 12;
        }

    }
}
