using System;
using System.Collections.Generic;
using System.Text;

namespace electrical_network_simulator
{
    class SolarPowerPlant: PowerPlant
    {
     
        public new double energy;
        public double sun;
       
        public SolarPowerPlant(string name, double energy) : base(name,energy)
        {   
            
        }
        public void SetEnergyBasedOn(Meteo meteo)
        {
          
            base.energy = meteo.sunshine * 10;
            this.sun = meteo.sunshine;

        }

    }
}
