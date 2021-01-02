using System;
using System.Collections.Generic;
using System.Text;

namespace electrical_network_simulator
{
    class Market
    {
        public double combustible_price;
        public double energy_price;
        public double external_energy_price;
        public Market( double combustible_price,double external_energy_price)
        {
            this.combustible_price = combustible_price;
            this.energy_price = 3* combustible_price;
            this.external_energy_price = external_energy_price;
        }
    }
}
