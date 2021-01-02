using System;
using System.Collections.Generic;
using System.Text;

namespace electrical_network_simulator
{
    class GasPowerPlant : PowerPlant
    {
        public new double CO2;
        public GasPowerPlant(string name, double energy) : base ( name, energy)
        {
            base.CO2 = base.energy/10;
        }
    }
}
