using System;

public class Program
{
    public static void Main()
    {
        Creatures creature = new Creatures(10);
        Simulations simulation = new Simulations();
        Seed teste = new Seed(0);
        teste.setNumberOfSeeds();
        teste.setSeedsNumberOfGenes();
        teste.buildSeeds(teste.numberOfSeeds, teste.numberOfSeedsGenes);
        simulation.setSimulation();
        simulation.startSimulation(simulation.generations);
        Console.WriteLine(simulation.generations);
        for (int i = 0; i < teste.seedsObj.Length; i++)
        {
            Console.WriteLine(teste.seedsObj[1].chosenGenes[1]);
        }
    }
}
public class Seed
{
    public int[] geneticConfiguration { get; set; }
    public int[] chosenGenes { get; set; }
    public int numberOfChosenGenes;
    public Seed[] seedsObj { get; set; }
    public int numberOfSeeds;
    public int numberOfSeedsGenes;

    public Seed(int numberOfSimulatedGenes)
    {
        this.numberOfChosenGenes = numberOfSimulatedGenes;
        this.geneticConfiguration = new int[numberOfChosenGenes];
        this.chosenGenes = new int[numberOfChosenGenes];
    }
    public void buildSeeds(int numberOfSeeds, int numberOfChosenGenes)
    {
        int i, j, k, h, g, f;
        int jumpLine = 0;
        int choose_gene;
        Random randomNumber = new Random();
        Seed[] seedsArray = new Seed[numberOfSeeds];
        Console.WriteLine(this.chosenGenes.Length.ToString());

        for (i = 0; i < numberOfSeeds; i++)
        {

            seedsArray[i] = new Seed(numberOfChosenGenes);

        }

        for (g = 0; g < numberOfChosenGenes; g++)
        {
            Console.Clear();
            Console.WriteLine("Choose genes\n");
            Console.WriteLine("[1] [2] [3] [4] [5] [6] [7] [8] [9] [10]\n");
            Console.WriteLine(numberOfChosenGenes - g + " more gene(s) to choose");
            choose_gene = int.Parse(Console.ReadLine());
            for (f = 0; f < numberOfSeeds; f++)
            {
                seedsArray[f].chosenGenes[g] = choose_gene;
            }
        }
        Console.Clear();
        Console.WriteLine("How do you want the seeds's genetics?");
        Console.WriteLine("[1] Random");
        Console.WriteLine("[2] Custom");
        int choose = int.Parse(Console.ReadLine());
        if (choose == 1)
        {
            for (k = 0; k < numberOfSeeds; k++)
            {
                for (h = 0; h < numberOfChosenGenes; h++)
                {

                    seedsArray[k].geneticConfiguration[h] = randomNumber.Next(0, 4);
                }
            }
        }
        else
        {
            //custom
        }
        for (k = 0; k < numberOfSeeds; k++)
        {
            for (j = 0; j < numberOfChosenGenes; j++)
            {
                Console.WriteLine("Seed " + k + " gene " + j + " = " + seedsArray[k].geneticConfiguration[j]);
                if (jumpLine == numberOfChosenGenes - 1)
                {
                    Console.WriteLine("\n");
                    jumpLine = 0;
                }
                else
                {
                    jumpLine = jumpLine + 1;
                }

            }
        }
        Console.WriteLine("Confirm?[Y/N]");
        Console.ReadLine();
        this.seedsObj = seedsArray;
    }

    public int setNumberOfSeeds()
    {
        Console.WriteLine("Number of seeds: ");
        this.numberOfSeeds = int.Parse(Console.ReadLine());
        Console.Clear();
        return this.numberOfSeeds;
    }
    public int setSeedsNumberOfGenes()
    {
        Console.WriteLine("Type the number of genes you wanna work with");
        this.numberOfSeedsGenes = int.Parse(Console.ReadLine());
        Console.Clear();
        return this.numberOfSeeds;

    }
}


public class Creatures
{
    public int[] geneticConfiguration { get; set; }
    public int[] chosenGenes { get; set; }
    public int numberOfChosenGenes;

    public Creatures(int numberOfChosenGenes)
    {
        this.numberOfChosenGenes = numberOfChosenGenes;
        this.geneticConfiguration = new int[numberOfChosenGenes];
        this.chosenGenes = new int[numberOfChosenGenes];
    }

}

class Simulations
{
    public int generations;
    int id1 = 1; // id = 0 + numberOfSeeds - 1
    int id2 = 1;
    int allBornCreatures = 0;
    int numberOfCouples = 1;
    int totalNumberOfCreatures = 0;
    int numberOfIndividualsThatDiedWithoutProcriating = 0;
    int totalNumberOfCouples = 0;
    int chosenCreature1 = 0;
    int chosenCreature2 = 0;
    int[] chosenCreaturesToCopulate = new int[1];


    public void startSimulation(int generations) //receives individualsArray or individualsArray data
    {
        Random randNum = new Random();
        for (int i = 0; i < generations - 3; i++)
        {
            for (int j = 0; j < numberOfCouples; j++)
            {
                Random randomBirths = new Random();
                int bornCreatures = randomBirths.Next(0, 6); //Generates a random number of born creatures for the next generation
                for (int m = 0; m < bornCreatures; m++) //Creates an object for each born creature
                {
                    Random numberRandom = new Random();
                    allBornCreatures = allBornCreatures + 2;
                    id1 = id1 + 1;



                    //até aqui ok 
                    //generate all possible gametes for all creatures
                    /*/public int generateGametes(individualsArray[id1],individualsArray[id2]){
                    }
                    /*/



                    //creaturesArray[id1] = new Creatures(); //
                }

                if (allBornCreatures % 2 == 0)
                {

                    for (i = 0; i < allBornCreatures; i++)
                    {
                        j = 0;
                        chosenCreature1 = randNum.Next(1, allBornCreatures + 1);
                        chosenCreature2 = randNum.Next(1, allBornCreatures + 1);
                        chosenCreaturesToCopulate[j] = chosenCreature1;
                        j = j + 1;
                        chosenCreaturesToCopulate[j] = chosenCreature2;


                        Console.WriteLine("gang gang bro");
                    }

                }
                else
                {

                }
            }
        }

    }

    public int setSimulation()
    {
        Console.WriteLine("Type the number of generations: ");
        this.generations = int.Parse(Console.ReadLine());
        return this.generations;
    }
}

