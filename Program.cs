using System;
using System.Collections.Generic;
using System.Text;

namespace electrical_network_simulator
{
    
    class Program

    {
        static void Main(string[] args)
        {
            Random random = new Random(); //ça genere un chiffre plus petit que 1000, je l'utilise pour presenter la demande des clients.
            Market market = new Market(random.Next(10), random.Next(10));
            GasPowerPlant centrale1 = new GasPowerPlant("centrale au gaz1",40);     //ici je crée mes deux centrales et un consommateur
            NuclearPowerPlant centrale2 = new NuclearPowerPlant("centrale nucléaire",90);
            GasPowerPlant centrale3 = new GasPowerPlant("centrale au gaz2", 10);
            centrale1.GetPrice(market);
            centrale2.GetPrice(market);
            centrale3.GetPrice(market);

            int city2NEED = random.Next(1000);
            Consumer city2 = new Consumer("city2", city2NEED);
            

            List<PowerPlant> centrales = new List<PowerPlant> { centrale1, centrale2 ,centrale3 } ; // ici je crée la liste des centrales que le petits réseau a 
            List<Consumer> consommateurs = new List<Consumer> { city2 }; // same for consumers


            List<KeyValuePair<PowerPlant, List<int>>> PowerPlantsLines = new List<KeyValuePair<PowerPlant, List<int>>>(); 
            
            List<int> centrale1_line = new List<int> { 1,1000 };
            List<int> centrale2_line = new List<int> { 2, 1000 };
            List<int> centrale3_line = new List<int> { 3, 1000 };
            PowerPlantsLines.Add(new KeyValuePair<PowerPlant, List<int>>(centrale1, centrale1_line));
            PowerPlantsLines.Add(new KeyValuePair<PowerPlant, List<int>>(centrale2, centrale2_line));
            PowerPlantsLines.Add(new KeyValuePair<PowerPlant, List<int>>(centrale3, centrale3_line));

            List<KeyValuePair<Consumer, List<int>>> ConsumersLines = new List<KeyValuePair<Consumer, List<int>>>();
            List<int> city2_line = new List<int> { 1, 1000 };

            ConsumersLines.Add(new KeyValuePair<Consumer, List<int>>(city2, city2_line));


            Infrastructure infrastructure1 = new Infrastructure(PowerPlantsLines, ConsumersLines);
            Network Musti = new Network(1,infrastructure1);
            Musti.GetCO2_EnergyPrice(market);

            //second network 
            Meteo belgiumState = new Meteo(21, 22, 32);
            GasPowerPlant centrale4 = new GasPowerPlant("centrale au gaz1", 40);
            centrale4.GetPrice(market);
            SolarPowerPlant Solaire1 = new SolarPowerPlant("Solaire1", 0);
            Solaire1.SetEnergyBasedOn(belgiumState);


            int city3NEED = random.Next(800);
            Consumer city3 = new Consumer("city3", city3NEED);

            List<PowerPlant> centrales2 = new List<PowerPlant> { Solaire1, centrale4 }; // ici je crée la liste des centrales que le petits réseau a 
            List<Consumer> consommateurs2 = new List<Consumer> { city3 }; // same for consumers


            List<KeyValuePair<PowerPlant, List<int>>> PowerPlantsLines2 = new List<KeyValuePair<PowerPlant, List<int>>>();

            List<int> Solaire1_line = new List<int> { 1, 1000 };
            List<int> Centrale4_line = new List<int> { 2, 1000 };

            PowerPlantsLines2.Add(new KeyValuePair<PowerPlant, List<int>>(Solaire1, Solaire1_line));
            PowerPlantsLines2.Add(new KeyValuePair<PowerPlant, List<int>>(centrale4, Centrale4_line));


            List<KeyValuePair<Consumer, List<int>>> ConsumersLines2 = new List<KeyValuePair<Consumer, List<int>>>();
            List<int> city3_line = new List<int> { 1, 1000 };

            ConsumersLines2.Add(new KeyValuePair<Consumer, List<int>>(city3, city3_line));


            Infrastructure infrastructure2 = new Infrastructure(PowerPlantsLines2, ConsumersLines2);
            Network chacha = new Network(2, infrastructure2);
            chacha.GetCO2_EnergyPrice(market);

            // BIG NETWORK
            List <Network> NETWORKS = new List<Network> { Musti , chacha };
            GreatNetwork TheGreatNetwork = new GreatNetwork(NETWORKS);

            Console.WriteLine(TheGreatNetwork.ToString());
         






        }
    }
}
