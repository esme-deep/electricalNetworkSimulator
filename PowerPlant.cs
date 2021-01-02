using System;
using System.Collections.Generic;
using System.Text;

namespace electrical_network_simulator
{
    class PowerPlant
    {
        public string name;
        public double energy;
        public double price;
        public  double CO2;
        //public int ligneNum;
        

        public PowerPlant(string name,double energy)
        {
            this.name = name;
            this.energy = energy;
            this.CO2 = 0;
        }
        public void SetToZero()
        {
            this.energy = 0;


        }
        public void GetPrice(Market market)
        {
            this.price = market.energy_price;
        }

    }

}
