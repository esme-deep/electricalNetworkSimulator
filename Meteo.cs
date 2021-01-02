using System;
using System.Collections.Generic;
using System.Text;

namespace electrical_network_simulator
{
    class Meteo
    {
        public double wind;
        public double sunshine;
        public double temperature;
        public Meteo( double wind, double sunshine,double temperature )
        {
            this.wind = wind;
            this.sunshine = sunshine;
            this.temperature = temperature;
            
        }
    }
}
