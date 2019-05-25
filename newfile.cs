using System;
using System.Linq;

public class Program
{
    public static void Main()
    {
        Settings settings = new Settings();
        Individuals individual = new Individuals();
        Simulation simulation = new Simulation();
        settings.setNumberOfSeeds();
        settings.setSeedsNumberOfGenes();
        settings.setChosenGenes(settings.numberOfSeedsGenes);
        settings.setSeedsGeneticConfiguration(settings.numberOfSeedsGenes);
        settings.seedsConfirmation(settings.numberOfSeedsGenes, settings.numberOfSeeds, settings.geneticConfiguration);
        settings.setGenerations();
        Individuals[] individualsArray = new Individuals[9999999];
        settings.buildSeeds(settings.numberOfSeeds, settings.numberOfSeedsGenes, settings.chosenGenes, individualsArray);
        simulation.startSimulation(settings.generations, settings.numberOfSeeds, individualsArray );
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
    public int[] geneticConfiguration = new int[999];
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
        Console.WriteLine("[0] Back");
        try
        {
            this.numberOfSeedsGenes = int.Parse(Console.ReadLine());
            if (this.numberOfSeedsGenes == 0)
            {
                Console.Clear();
                this.setNumberOfSeeds();
                this.setSeedsNumberOfGenes();
            }
            else if (this.numberOfSeedsGenes < 0)
            {
                Console.Clear();
                Console.WriteLine("You can't use negative values");
                this.setSeedsNumberOfGenes();
            }
            else
            {

            }
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
        for (int i = 0; i < this.numberOfSeedsGenes; i++)
        {
            Console.WriteLine("Choose genes\n");
            Console.WriteLine("[1] [2] [3] [4] [5] [6] [7] [8] [9] [10]\n\n [0] - BACK\n[00] - RESTART");
            Console.WriteLine(numberOfSeedsGenes - i + " more gene(s) to choose");
            Console.WriteLine("index.: " + i);
            this.chosenGenes[i] = int.Parse(Console.ReadLine());
            if (this.chosenGenes[i] == 0)
            {
                i = 0;
                Console.Clear();
                this.setSeedsNumberOfGenes();
                this.setChosenGenes(this.numberOfSeedsGenes);
            }
            else if (this.chosenGenes[i] == 00)
            {
                Console.Clear();
                i = -1;
            }
            else
            {

            }
            Console.Clear();
        }
        return this.chosenGenes;
    }

    public int[] generateRandomGenome(int numberOfSeedsGenes)
    {
        for (int i = 0; i < this.numberOfSeedsGenes; i++)
        {
            Random randNumber = new Random();
            this.geneticConfiguration[i] = randNumber.Next(0, 3);
        }

        return this.geneticConfiguration;
    }

    public int[] setSeedsGeneticConfiguration(int numberOfSeedsGenes)
    {
        Random randNumber = new Random();
        Console.WriteLine("How do you want to configurate the seeds' genome?");
        Console.WriteLine("\n[1] Random\n[2] Custom\n[3] Back");
        int choose = int.Parse(Console.ReadLine());
        if (choose == 1)
        {
            generateRandomGenome(this.numberOfSeedsGenes);
        }

        else if (choose == 2)
        {
            Console.Clear();
            this.setNumberOfSeeds();
        }

        else if (choose == 3)
        {
            Console.Clear();
            this.setChosenGenes(this.numberOfSeedsGenes);
        }

        else
        {
            Console.Clear();
            Console.WriteLine("Enter a valid value\n");
            this.setSeedsGeneticConfiguration(this.numberOfSeedsGenes);

        }
        return this.geneticConfiguration;
    }

    public void buildSeeds(int numberOfSeeds, int numberOfSeedsGenes, int[] chosenGenes, Individuals[] individualsArray)
    {
        for (int i = 0; i < this.numberOfSeeds; i++)
        {
            individualsArray[i] = new Individuals();
            for (int g = 0; g < this.numberOfSeedsGenes; g++)
            {
                individualsArray[i].chosenGenes[g] = this.chosenGenes[g];
                individualsArray[i].geneticConfiguration[g] = this.geneticConfiguration[g];
            }

        }
    }

    public int setGenerations()
    {
        Console.WriteLine("Enter the number of generations");
        this.generations = int.Parse(Console.ReadLine());
        return this.generations;
    }

    public void seedsConfirmation(int numberOfSeedsGenes, int numberOfSeeds, int[] geneticConfiguration)
    {
        int h;
        int n;
        int jumpLine = 0;
        Console.Clear();
        for (int k = 0; k < this.numberOfSeeds; k++)
        {
            for (int j = 0; j < this.numberOfSeedsGenes; j++)
            {
                h = j + 1;
                n = k + 1;
                if (this.geneticConfiguration[j] == 0)
                {
                    Console.WriteLine("Seed " + n + " gene " + h + " " + " = " + "Dominant homozygous (AA)");
                    if (jumpLine == this.numberOfSeedsGenes - 1)
                    {
                        Console.WriteLine("\n");
                        jumpLine = 0;
                    }
                    else
                    {
                        jumpLine = jumpLine + 1;
                    }
                }
                else if (this.geneticConfiguration[j] == 1)
                {
                    Console.WriteLine("Seed " + n + " gene " + h + " " + " = " + "Heterozygous (Aa)");
                    if (jumpLine == this.numberOfSeedsGenes - 1)
                    {
                        Console.WriteLine("\n");
                        jumpLine = 0;
                    }
                    else
                    {
                        jumpLine = jumpLine + 1;
                    }
                }

                else if (this.geneticConfiguration[j] == 2)
                {
                    Console.WriteLine("Seed " + n + " gene " + h + " " + " = " + "Recessive homozygous (aa)");
                    if (jumpLine == this.numberOfSeedsGenes - 1)
                    {
                        Console.WriteLine("\n");
                        jumpLine = 0;
                    }
                    else
                    {
                        jumpLine = jumpLine + 1;
                    }
                }

                else
                {
                    Console.WriteLine("FATAL ERROR - Invalid value for geneticConfiguration");
                }
            }

        }

        Console.WriteLine("\n[1] OK\n[2] Generate another random genome\n[3] Back");
        int choose = int.Parse(Console.ReadLine());
        if (choose == 1)
        {


        }
        else if (choose == 2)
        {
            generateRandomGenome(this.numberOfSeedsGenes);
            seedsConfirmation(this.numberOfSeedsGenes, this.numberOfSeeds, this.geneticConfiguration);
        }
        else if (choose == 3)
        {
            setSeedsGeneticConfiguration(this.numberOfSeedsGenes);
            seedsConfirmation(this.numberOfSeedsGenes, this.numberOfSeeds, this.geneticConfiguration);
        }
        else
        {
            Console.Clear();
            Console.WriteLine("Enter a valid value");
            Console.ReadLine();
        }
    }

}

public class Simulation
{
    public int actualGeneration = 0;
    public int generations;
    public int id;
    public int id2 = 1;
    public int[] allBornCreatures = new int[99999];
    public int numberOfCouples;
    public int newCreatures = 0;
    public int[,][] couplesArray = new int[9999,9999][];
    public int numberOfCreaturesThatDiedWithoutProcriating = 0;

    public void copulesAndBirths(int numberOfCouples, int[,][] couplesArray, Individuals[] individualsArray)
    {
        int counter = 0;
        int k = 0;
        int[][] individual1 = new int[999999][];
        int[][] individual2 = new int[999999][];
        for (int i = 0; i < numberOfCouples; i++)
        {
            k = i + 1;
            Console.WriteLine(i);
            //set a couple to have children
            individual1[0] = couplesArray[i, i];
            individual2[0] = couplesArray[k, k];
            Random randomBirths = new Random();
            int bornCreatures = randomBirths.Next(0, 6); //Generates a random number of born creatures for the next generation
            for (int m = 0; m < bornCreatures; m++) //Creates an object for each born creature
            {
                allBornCreatures[counter] = bornCreatures;
                counter = counter + 1;
            }
            receivePairOfGenes(individual1, individual2, allBornCreatures, individualsArray);
        }


    }

    public int[,][] formCouples(int[,][] couplesArray, Individuals[] individualsArray, int numberOfSeeds)
    {
        Random randomNumber = new Random();
        if (this.allBornCreatures.Length != 0) //Form couples with the current generations' creatures
        {
   

   
        }

        else //Form the first couples with the seeds
        {
            int[] remainingSeedsToChoose = new int[numberOfSeeds - (numberOfSeeds % 2)];
            int randomSeed1 = 0;
            int randomSeed2 = 0;
            int k;
            for (int i = 0; i < numberOfSeeds - (numberOfSeeds%2); i++)
            {   
                k = i + 1;
                chooseRandomSeed1(randomSeed1, numberOfSeeds, individualsArray, this.couplesArray, remainingSeedsToChoose);
                this.couplesArray[i, i] = individualsArray[randomSeed1].geneticConfiguration;
                chooseRandomSeed2(randomSeed2, numberOfSeeds, individualsArray, this.couplesArray, remainingSeedsToChoose);
                this.couplesArray[k, k] = individualsArray[randomSeed2].geneticConfiguration;
            }

            if (numberOfSeeds %2 == 1)
            {
                for(int i=0; i < numberOfSeeds % 2; i++)
                {
                    numberOfCreaturesThatDiedWithoutProcriating = numberOfCreaturesThatDiedWithoutProcriating + 1;
                }

            }

            else
            {


            }
        }

        return this.couplesArray;
    }

    public int chooseRandomSeed1(int randomSeed1, int numberOfSeeds, Individuals[] individualsArray, int[,][] couplesArray, int[] remainingSeedsToChoose)
    {
        Random randomNumber = new Random();
        randomSeed1 = randomNumber.Next(0, numberOfSeeds - (numberOfSeeds % 2));
        if (remainingSeedsToChoose.Contains(randomSeed1))
        {
            remainingSeedsToChoose[randomSeed1] = 0;
        }

        else
        {
            chooseRandomSeed1(randomSeed1, numberOfSeeds, individualsArray, this.couplesArray, remainingSeedsToChoose);
        }
        randomSeed1 = randomNumber.Next(0, numberOfSeeds - (numberOfSeeds % 2));

        return randomSeed1;
    }

    public int chooseRandomSeed2(int randomSeed2, int numberOfSeeds, Individuals[] individualsArray, int[,][] couplesArray, int[] remainingSeedsToChoose)
    {
        Random randomNumber = new Random();
        randomSeed2 = randomNumber.Next(0, numberOfSeeds - (numberOfSeeds % 2));
        if (remainingSeedsToChoose.Contains(randomSeed2))
        {
            remainingSeedsToChoose[randomSeed2] = 0;
        }
        else 
        {
            chooseRandomSeed2(randomSeed2, numberOfSeeds, individualsArray, this.couplesArray, remainingSeedsToChoose);
        }
        return randomSeed2;
    }

    public Individuals[] receivePairOfGenes(int[][] individual1, int[][] individual2, int[] allBorncreatures, Individuals[] individualsArray) //Determines the genetic configuration of the creature
    {

        return individualsArray;
    }

    public void startSimulation(int generations, int numberOfSeeds, Individuals[] individualsArray) //receives individualsArray or individualsArray data
    {
        Random randNum = new Random();
        for (int i = 0; i < generations; i++)
        {
            actualGeneration = actualGeneration + 1;
            Console.WriteLine("Generation = " + actualGeneration);
            Console.WriteLine("Total creatures number = " + individualsArray.Length);
            Console.ReadKey();
            this.formCouples(this.couplesArray,individualsArray, numberOfSeeds);
            this.numberOfCouples = this.couplesArray.GetLength / 2;
            this.copulesAndBirths(this.numberOfCouples, this.couplesArray, individualsArray);
        }

    }
}
