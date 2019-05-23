using System;

public class Program
{
    public static void Main()
    {
        Settings settings = new Settings();
        Individuals individual = new Individuals();
        settings.setNumberOfSeeds();
        settings.setSeedsNumberOfGenes();
        settings.setChosenGenes(settings.numberOfSeedsGenes);
        settings.setGenerations();
        Individuals[] individualsArray = new Individuals[9999999];
        settings.buildSeeds(settings.numberOfSeeds, settings.numberOfSeedsGenes, settings.chosenGenes, individualsArray);
        Console.WriteLine(individualsArray[5].chosenGenes[2]);        
        Console.WriteLine("end");
        Console.ReadLine();
    }
}


public class Individuals
{
    public int[] geneticConfiguration = new int[99999];
    public int[] chosenGenes = new int[99999];
    public int numberOfChosenGenes;
    public int numberOfSeeds;
    public int numberOfSeedsGenes;
}


public class Settings
{
    public int numberOfChosenGenes;
    public int[] geneticConfiguration;
    public int[] chosenGenes = new int[900];
    public int numberOfSeeds;
    public int numberOfSeedsGenes;
    private string choose;
    public int generations;

    public int setNumberOfSeeds()
    {
        Console.WriteLine("Number of seeds: ");
        try
        {
            this.numberOfSeeds = int.Parse(Console.ReadLine());
        }
        catch
        {
            Console.Clear();
            Console.WriteLine("enter a valid value");
            this.setNumberOfSeeds();
        }
        this.confirmationScreen();
        if (this.choose == "Y")
        {

        }
        else if (this.choose == "N")
        {
            Console.Clear();
            this.setNumberOfSeeds();
        }
        Console.Clear();
        return this.numberOfSeeds;
    }
    public int setSeedsNumberOfGenes()
    {
        Console.WriteLine("Type the number of genes you wanna work with");
        try
        {
            this.numberOfSeedsGenes = int.Parse(Console.ReadLine());
        }
        catch
        {
            Console.WriteLine("enter a valid value");
            Console.Clear();
            this.setSeedsNumberOfGenes();
        }
        confirmationScreen();
        Console.Clear();
        return this.numberOfSeedsGenes;
    }

    public string confirmationScreen()
    {
        Console.WriteLine("confirm? [Y/N]");
        this.choose = Console.ReadLine();
        if (this.choose == "Y" || this.choose == "y")
        {
            this.choose = "Y";
        }

        else if (this.choose == "N" || this.choose == "n")
        {
            this.choose = "N";
        }
        else
        {
            Console.Clear();
            Console.WriteLine("enter a valid value");
            this.confirmationScreen();
        }
        return this.choose;
    }

    public int[] setChosenGenes(int numberOfSeedsGenes)
    {
        int i = 0;
        for (i = 0; i < this.numberOfSeedsGenes; i++)
        {
            Console.WriteLine("Choose genes\n");
            Console.WriteLine("[1] [2] [3] [4] [5] [6] [7] [8] [9] [10]\n\n [0] - BACK\n[00] - RESTART");
            Console.WriteLine(numberOfSeedsGenes - i + " more gene(s) to choose");
            this.chosenGenes[i] = int.Parse(Console.ReadLine());
            if (this.chosenGenes[i] == 0)
            {
                Console.Clear();
                this.setSeedsNumberOfGenes();

            }
            else if (this.chosenGenes[i] == 00)
            {
                Console.Clear();
                i = 0;
                this.setChosenGenes(this.numberOfSeedsGenes);
            }
            else
            {

            }
            Console.Clear();
        }
        return this.chosenGenes;
    }

    public void setSeedsGeneticConfiguration(int[] chosenGenes)
    {
        Random randNumber = new Random();
        Console.WriteLine("How do you want to configurate the Seeds genetics?");
        Console.WriteLine("\n[1] Random\n[2] Custom");
        this.choose = Console.ReadLine();
        this.confirmationScreen();
        if (this.choose == "1")
        {
            if (this.choose == "Y")
            {
                Console.Clear();
                for(int i = 0;i<this.numberOfChosenGenes;i++)
                {
                    this.geneticConfiguration[i] = randNumber.Next(0, 3);
                }

            }
            else
            {
                Console.Clear();
                this.setSeedsGeneticConfiguration(this.chosenGenes);
            }


        }

        

        else if (this.choose == "N")
        {
            Console.Clear();
            this.setNumberOfSeeds();
        }
         
        else
        {
           Console.Clear();
           Console.WriteLine("Enter a valid value\n");
           this.setSeedsGeneticConfiguration(this.chosenGenes);
        }

    }

    public void buildSeeds(int numberOfSeeds, int numberOfSeedsGenes, int[] chosenGenes, Individuals[] individualsArray)
    {
        for (int i = 0; i < this.numberOfSeeds; i++)
        {
            individualsArray[i] = new Individuals();
            for (int g=0; g < this.numberOfSeedsGenes; g++)
            {
                individualsArray[i].chosenGenes[g] = this.chosenGenes[g];
            }
        }
    }

    public int setGenerations()
    {
        Console.WriteLine("Enter the number of generations");
        this.generations = int.Parse(Console.ReadLine());
        return this.generations;
    }


}



public class Simulation
{
    int passedGenerations = 0;
    int numberOfCreaturesInThisGeneration;
    public int generations;
    int id1;
    int id2 = 2;
    int allBornCreatures = 0;
    int numberOfCouples = 1;
    int totalNumberOfCreatures = 0;
    int numberOfIndividualsThatDiedWithoutProcriating = 0;
    int totalNumberOfCouples = 0;
    int chosenCreature1 = 0;
    int chosenCreature2 = 0;
    int[] chosenCreaturesToCopulate = new int[1];
    int newCreatures = 0;

    public object[] startSimulation(int generations, int numberOfSeeds, Individuals[] individualsArray, int numberOfSimulatedGenes) //receives individualsArray or individualsArray data
    {
        int id = 0;
        id = numberOfSeeds + 1;
        numberOfCouples = numberOfSeeds / 2;
        Random randNum = new Random();
        for (int i = 0; i < generations - 3; i++)
        {
            passedGenerations = passedGenerations + 1;
            Console.WriteLine("Generation = " + passedGenerations);
            Console.WriteLine("Number of creatures in this generation = " + allBornCreatures);
            for (int j = 0; j < numberOfCouples; j++)
            {
                Random randomBirths = new Random();
                int bornCreatures = randomBirths.Next(0, 6); //Generates a random number of born creatures for the next generation
                for (int m = 0; m < bornCreatures; m++) //Creates an object for each born creature
                {
                    Random numberRandom = new Random();
                    allBornCreatures = allBornCreatures + bornCreatures;
                    //até aqui ok 
                    //generate all possible gametes for all creatures
                    /*/public int generateGametes(individualsArray[id1],individualsArray[id2]){
                    }
                    /*/
                    seedsArray[id] = new Seed(numberOfSimulatedGenes);
                    id = id + 1;
                }
                numberOfCouples = allBornCreatures / 2;


                if (allBornCreatures % 2 == 0)
                {

                    for (i = 0; i < allBornCreatures; i++)
                    {
                        for (int w = 0; w < 2; w++)
                        {
                            chosenCreature1 = randNum.Next(1, allBornCreatures + 1);
                            chosenCreature2 = randNum.Next(1, allBornCreatures + 1);
                        }
                    }
                }
                else
                {

                }

                numberOfCouples = newCreatures / 2;
            }
        }
        return seedsArray;
    }
}






