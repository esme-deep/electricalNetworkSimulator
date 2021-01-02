# Simulateur de réseaux électrique - Documentation 
                          by : Chaîmae Mottaki 18231 
                          & Asmae Malouli 18185

### Bienvenue dans ce simulateur de réseaux électriques. Cette documentation vous permettra de naviguer au mieux à travers le code.

## Comment créer un réseau :
Afin de créer un grand réseau "GreatNetwork" ou on trouve des groupes de centrales qui fournissent de l'énergie à des groupes de consommateurs, on commence par créer les petits groupes qu'on appelle "network"; donc chaque petit réseau aura un noeud de distribution et un noeud de concentration qui sont reliés par une ligne => c'est cette ligne qui fera "l'dentifiant" qu'on appelle "Node" de chaque réseau et comme elle est unique et propre au fournisseurs/consommateurs elle identifira aussi les noeuds implicitement.


## Ajouter une centrale
Une centrale est definié en créant une instance du type de centrale qu'on souhaite insérer dans le réseau. On instancie une centrale en lui donnant un nom,
Voici une liste des types de centrales à disposition:
* Centrale nucléaire 
* Centrale au gaz
* Parc éolien
* Centrale solaire

Exemple:

```cs
GasPowerPlant centrale1 = new GasPowerPlant("centrale au gaz1",10); 
NuclearPowerPlant centrale2 = new NuclearPowerPlant("centrale nucléaire",40);   
```
Le premier argument étant le nom de la centrale est le deuxième étant l'énergie qui fournit, cette enerige peut être modifiée par après selon la demande surtout pour les centrales au gaz.

Pour créer un nouveau type de centrale, on instancie la classe PowerPlant.

Exemple:
Si on veut ajouter une centrale 'cloud', on écrirait:
```cs
PowerPlant cloud = new PowerPlant;
```
## Ajout d'un consommateur 

Si on souhaite ajouter un consommateur, on peut simplement le faire en instanciant la classe Consumer comme suit:

```cs
Consumer city2 = new Consumer("city2", city2NEED);   
```
(ou city2Need est un chiffre Random pour mieux voir la simulation qui change pour chaque appel de la méthode ToString)


## Création du réseau
### Un réseau est construit à partir des éléments suivants:
* le numéro du noeud concentration/distribution
* une infrastructure

## Création d'une infrastructure 
une infrastructure est propre à chaque petit reseau "Network" donc lui donne en paramètres :
* les centrales qui fournissent l'energie, et pour chaque centrale on précise la ligne et l'energie maximale qui peut y circuler.
```cs
List<int> centrale1_line = new List<int> { 1,1000 }; 
PowerPlantsLines.Add(new KeyValuePair<PowerPlant, List<int>>(centrale1, centrale1_line));
```
* les consommateurs qui consomment sur ce noeud "Node", et pour chaque consommateur on précise la ligne et l'energie maximale.
```cs
List<int> city2_line = new List<int> { 1, 1000 };
 ConsumersLines.Add(new KeyValuePair<Consumer, List<int>>(city2, city2_line));
```
donc maintenant on peut instancier l'infrastructue : 
```cs
Infrastructure infrastructure1 = new Infrastructure(PowerPlantsLines, ConsumersLines);
```

## Mise à jour

Afin de mettre à jour l'état du réseau que vous avez créé, on peut appeler la méthode ToString()
```cs
Network reseau = new Network;
reseau.ToString();   
```

## Affichage de tous les réseaux
On peut afficher tous les reseaux se trouvant dans une même liste de reseau avec une instance de la classe GreatNetwork.
On peut alors l'afficher sur la Console avec Console.WriteLine();
```cs
List<Network> NETWORKS = new List<Network> { reseau };
GreatNetwork TheGreatNetwork = new GreatNetwork(NETWORKS);

Console.WriteLine(TheGreatNetwork.ToString());
  
```
## Le marché 
Avant d'essayer d'afficher les réseaux il faut préciser les prix pour chaque petit réseau et appeler la méthode suivante : 
```cs
ElementaryNetwork.GetCO2_EnergyPrice(market);
```
en faisant cela le réseau aura le prix du combustible et de l'électricité pour chaque fournisseur/consommateur.

## La méteo 
l'énergie des centrales solaires et éoliennes depends de la méteo donc si on souhaites les associer à une infrastructure il faut appeler la méthode setEnergyBasedOn(Meteo : meteo)  : 
 ```cs
SolarPowerPlant Solaire1 = new SolarPowerPlant("Solaire1", 0);
Solaire1.SetEnergyBasedOn(belgiumState);
```

