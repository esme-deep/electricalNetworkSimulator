using System;
using System.Collections.Generic;
using System.Text;

namespace electrical_network_simulator
{
    class Infrastructure 
        //ici c'est une mini infrastructure qui juste lie des centrales a des consommateurs 
        //donc en gros elle crée un noeud de concentration et un noeud de distribution et comme ils sont sur la meme ligne on leurs donne le même numéro.
    {
        public List<KeyValuePair<PowerPlant, List<int>>> PowerPlantsLines; // elle recoit la liste {centrale,[numero de ligne,puissance max]}
        public List<KeyValuePair<Consumer, List<int>>> ConsumersLines; // same here for the list{consommateur,[numero de ligne,puissance max]}
        public Infrastructure(List<KeyValuePair<PowerPlant, List<int>  >> PowerPlantsLines, List<KeyValuePair<Consumer, List<int>>> ConsumersLines)
        {
            this.PowerPlantsLines = PowerPlantsLines;
            this.ConsumersLines = ConsumersLines;
        }


    }
}
