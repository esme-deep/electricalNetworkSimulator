using System;
using System.Collections.Generic;
using System.Text;

namespace electrical_network_simulator
{
    class WindTurbine : PowerPlant
    {
        public double wind_velocity;
        public WindTurbine(string name, double energy) : base(name, energy)
        {

        }
        public void SetEnergyBasedOn(Meteo meteo)
        {

            base.energy = meteo.wind * 10;
            this.wind_velocity = meteo.wind;

        }

    }
}
