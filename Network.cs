using System;
using System.Collections.Generic;
using System.Text;

namespace electrical_network_simulator
{
    class Network 
    {
        public int Node ;
        public Infrastructure Infrastructure;
        public double NetworkNeededEnergy ;//l'energie demandé par les consommateurs
        public double energy_price;
        public double combustible_price;
        
        public Network(int Node, Infrastructure Infrastructure)
        {
            this.Node =Node ;
            this.Infrastructure = Infrastructure;
            this.NetworkNeededEnergy = this.GetNetworkNeededEnergy();  
           
        }
        public double getProductionOf(List<PowerPlant> power_plants)
        {
            double energy = 0;
            foreach(PowerPlant pp in power_plants)
            {
                energy += pp.energy;
            }
            return energy;
        }
        public void  GetCO2_EnergyPrice(Market market)
        {
            this.energy_price = market.energy_price;
            this.combustible_price = market.combustible_price;
        }
        public void stopProduction(PowerPlant Power_plant)
        {
            Power_plant.energy = 0;
        }
        public double GetNetworkNeededEnergy()
        {
            foreach (KeyValuePair<Consumer, List<int>> elt in this.Infrastructure.ConsumersLines)
            {
                this.NetworkNeededEnergy += elt.Key.energy;
            }
            return this.NetworkNeededEnergy ;
        }
        string message = "Messages : " + "\n";
        public void setProduction()
        {
            double sum = 0;
            List<PowerPlant> gas_power_plants = new List<PowerPlant>();
            List<PowerPlant> nuclear_power_plants = new List<PowerPlant>();
            int i = 0;
            int j = 0;

            foreach (KeyValuePair<PowerPlant, List<int>> elt in this.Infrastructure.PowerPlantsLines)
            {
               sum += elt.Key.energy;
               if (elt.Key is GasPowerPlant)
                {// jeregarde laquelle des centrales est une centrale au gaz pour pouvoir changer sa production
                    gas_power_plants.Add(elt.Key);
                    i++;
                }
                if (elt.Key is NuclearPowerPlant)
                {// jeregarde laquelle des centrales est une centrale nucleaire
                    nuclear_power_plants.Add(elt.Key);
                    j++;
                }

            }

            if (sum < this.NetworkNeededEnergy)
                

            {
                message = message + "\t" + " alert on a besoin de l'energie !! \n";
                //si la demande est plus grande d-que la production on demande au centrales d'augmenter la production
                double Need = this.NetworkNeededEnergy - sum;
                foreach(PowerPlant item in gas_power_plants)
                {
                    item.energy = item.energy + (int)Math.Ceiling(Need / i) ;
                    item.CO2 = item.energy / 10;

                    message =message + "\t"+ "la centrale " + item.name + " à ajouté " +  Math.Ceiling(Need / i).ToString() + " à sa production." + "\n";
               
                }


            }

            if (sum == this.NetworkNeededEnergy)
            { //s'ils sont egaux tout va bien 
                message = message + "\t" + "tous va bien";
                
            }

            if (sum > this.NetworkNeededEnergy)
               
            { //si on produit plus que ce qu'on demande 
                message = message + "\t" + " alert on a beaucoup d'energie !! \n";
                double Over = sum - this.NetworkNeededEnergy;
                if (Over >= 100)
                {


                    if (getProductionOf(nuclear_power_plants) > Over)
                    {
                        foreach (PowerPlant pp in gas_power_plants)
                        {
                            pp.SetToZero();
                            pp.CO2 = 0;
                        }
                        message = message + "\t" + "la centrale nuléaire fournit assez toutes les autres ont arêté leurs production \n";//nuclear took care of evrything
                    }


                    else
                    {
                        double deleted_energy = 0;
                        
                        foreach (PowerPlant item in gas_power_plants)
                        {

                            if (item.energy < (int)Math.Floor(Over / i))
                            {
                                deleted_energy += item.energy;
                                item.energy = 0;
                                item.CO2 = 0;
                                message = message + "\t" + "la centrale " + item.name.ToString() + " a arrêté production " + "\n";
                             

                            }
                            
                            if (item.energy >= (int)Math.Floor(Over / i))
                            {
                                //double deleted = item.energy + getProductionOf(nuclear_power_plants) - this.NetworkNeededEnergy;
                                //item.energy = this.NetworkNeededEnergy - getProductionOf(nuclear_power_plants) ;
                                item.energy = item.energy - (int)Math.Floor(Over/ i);
                                item.CO2 = item.energy / 10;
                                message = message + "\t" + "la centrale " + item.name + " à enlevé " + ((int)Math.Floor(Over/i)).ToString() + " à sa production." + "\n";
                            }
                        }
                        
                        
                    }

                }

                else
                {
                    //here no need to bother the power plants we just discharge it to the dissipator or stock
                    if (Over > 50)
                    {


                        this.Infrastructure.ConsumersLines.Add(new KeyValuePair<Consumer, List<int>>(new Dissipator("dissipateur", 50, 14), new List<int> { 14, 50 }));

                        this.Infrastructure.ConsumersLines.Add(new KeyValuePair<Consumer, List<int>>(new Dissipator("dissipateur", 50, 15), new List<int> { 15, 50 }));
                    }
                    else
                    {
                        this.Infrastructure.ConsumersLines.Add(new KeyValuePair<Consumer, List<int>>(new Dissipator("dissipateur", 50, 14), new List<int> { 14, 50 }));
                    }

                }
            }




        }
        public  override string ToString()
        {
            this.setProduction();
            string fournisseurs = "les fournisseurs de l'energie dans ce petit réseau " + this.Node.ToString() + "  sont:" + "\n";
            string recepteurs = "les recepteurs de l'energie dans ce petit réseau " + this.Node.ToString() + "  sont:" + "\n";
            foreach (KeyValuePair<PowerPlant , List<int> > elt in this.Infrastructure.PowerPlantsLines)
            {
                fournisseurs += "\t" + "\t" + elt.Key.name + " qui fournit " + elt.Key.energy.ToString() + " sur la ligne " + elt.Value[0].ToString() + " et qui payera " + (this.combustible_price * elt.Key.CO2).ToString() + " EURO" +
                    " sachant qu'elle a consommé " + elt.Key.CO2.ToString() + " de CO2. \n"  ;
            }
            foreach (KeyValuePair<Consumer, List<int>> elt in this.Infrastructure.ConsumersLines)
            {
                 recepteurs+= "\t" +"\t" + elt.Key.name + " qui recoit " + elt.Key.energy.ToString() + " sur la ligne " + elt.Value[0].ToString() + " et qui payera "+ (this.energy_price* elt.Key.energy).ToString() + " EURO. \n";
            }
            string title = "Reseau n° " + this.Node.ToString() + ": \n";
            string prices = "les prix actuels sont de  :   " + this.energy_price.ToString() + " Euro comme prix d'un 1kwatt et " + this.combustible_price.ToString() + " Euro comme prix d'1unité de combustible. \n \t";



            return prices + title + "\t" + fournisseurs + "\t" + recepteurs + "\t" + message ;
            
        }


        

    }
}
