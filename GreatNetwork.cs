using System;
using System.Collections.Generic;
using System.Text;

namespace electrical_network_simulator
{
    class GreatNetwork
    {
        public List<Network> networks;

        public GreatNetwork(List<Network> networks)
        {
            this.networks = networks; 
        }
        public override string ToString()
        {
            string display ="";
           
            foreach(Network net in  this.networks)
            { 
                display  = display + net.ToString() +"\n";
            }
            return display ; 
        }

    }
}
