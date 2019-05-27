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
        Console.Clear();
        simulation.startSimulation(settings.generations, settings.numberOfSeeds, individualsArray);
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
    public int index { get; set; }

    public Individuals()
    {
        this.index = this.index + 1;
    }
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
    public int numberOfBornCreatures;
    public int numberOfCouples;
    public int numberOfCreatures;
    public int [][] individualsOfCurrentGeneration = new int[99999][];
    public int[][] individualsToReceiveGenes = new int[99999][];
    public int newCreatures = 0;
    public int[][] couplesArray = new int[99999][];
    public int numberOfCreaturesThatDiedWithoutProcriating = 0;

    public int[][] copulesAndBirths(int numberOfCouples, int[][] couplesArray, Individuals[] individualsArray, int numberOfBornCreatures)
    {
        //start making the allBornCreatures array fully null
        int numberOfCreaturesToReceiveGenes = 0;
        int k = 0;
        int[][] parent1 = new int[999999][];
        int[][] parent2 = new int[999999][];
        for (int i = 0; i < numberOfCouples; i++)
        {
            k = i + 1;
            Console.WriteLine("Generating births");
            //set a couple to have children
            parent1[0] = couplesArray[i];
            parent2[0] = couplesArray[k];
            Random randomBirths = new Random();
            for (int m = 0; m < randomBirths.Next(1,7); m++) //Creates an object for each born creature
            {
                numberOfBornCreatures = numberOfBornCreatures + 1;
                numberOfCreaturesToReceiveGenes = numberOfCreaturesToReceiveGenes + 1;   
            }

            buildNewIndividuals(parent1, parent2, numberOfCreaturesToReceiveGenes, individualsArray, individualsToReceiveGenes);

            for (int j=0; j<numberOfCreaturesToReceiveGenes;j++) //pass the genes to the array of the creatures of the current generation
            {
                if (individualsOfCurrentGeneration != null)
                {
                    individualsOfCurrentGeneration[j] = individualsToReceiveGenes[j];
                }
            }

            for (int h=0;h<individualsToReceiveGenes.Length;h++)  //reset individualsToReceiveGenes array, to be able to receive the next brooding's genes
            {
                if(individualsToReceiveGenes[h] != null)
                {
                    individualsToReceiveGenes[h] = null;
                }
            }

            for (int y=0;y<parent1.Length;y++) // reset parent1 array to receive the next parent 1
            {
                if (parent1[y] != null)
                {
                    parent1[y] = null;
                }
            }

            for (int z=0; z<parent2.Length;z++) //reset parent2 array to receive the next parent 2
            {
                if (parent2[z] != null)
                {
                    parent2[z] = null;
                }
            }
                
            numberOfCreaturesToReceiveGenes = 0; //reset the variable to receive the number of creatures in the next brooding
        }
        Console.WriteLine("Births finalized");
        Console.ReadKey();
        return individualsOfCurrentGeneration;
    }

    public int[][] formCouples(int[][] couplesArray, Individuals[] individualsArray, int numberOfSeeds, int numberOfBornCreatures)
    {
        int[] remainingSeedsToChoose = new int[(numberOfSeeds - (numberOfSeeds % 2) + 2)];
        int randomIndividual = 0;
        int randomSeed = 0;
        Random randomNumber = new Random();
        if (numberOfBornCreatures != 0) //Form couples with the current generations' creatures
        {
            int[] remainingIndividualsToChoose = new int[(numberOfBornCreatures - (numberOfBornCreatures % 2)) - 1]; //Fill the remainingIndividualsToChoose array
            for (int v = 0; v < numberOfBornCreatures; v++)
            {
                    remainingIndividualsToChoose[v + 1] = individualsArray[id].index; // ajeitar    
            }

            for (int r = 0; r < numberOfBornCreatures - (numberOfBornCreatures % 2); r++)
            {
                Console.WriteLine("picking random creatures to form couples");
                chooseRandomIndividual(randomIndividual, numberOfBornCreatures, individualsArray, this.couplesArray, remainingIndividualsToChoose);
                this.couplesArray[r] = individualsArray[randomIndividual].geneticConfiguration;
            }


        }

        else //Form the first couples with the seeds
        {
            for(int v =0 ; v<numberOfSeeds;v++) //Fill the remainingSeedsToChoose
            {
                remainingSeedsToChoose[v] = v;
            }

            for (int i = 0; i < numberOfSeeds - (numberOfSeeds % 2); i++)
            {
                Console.WriteLine("picking random seed" + i + " to form couples");
                Console.ReadKey();
                chooseRandomSeed(randomSeed, numberOfSeeds, individualsArray, this.couplesArray, remainingSeedsToChoose);
                this.couplesArray[i] = individualsArray[randomSeed].geneticConfiguration;
            }

            if (numberOfSeeds % 2 == 1)
            {
                for (int i = 0; i < numberOfSeeds % 2; i++)
                {
                    numberOfCreaturesThatDiedWithoutProcriating = numberOfCreaturesThatDiedWithoutProcriating + 1;
                }

            }

            else
            {


            }
        }

        // reset remainingIndividualsToChoose array and lock the other iteration

        return this.couplesArray;
    }

    public int chooseRandomIndividual(int randomIndividual, int allBornCreatures, Individuals[] individualsArray, int[][] couplesArray, int[] remainingIndividualsToChoose)
    {
        Random randomNumber = new Random();
        randomIndividual = randomNumber.Next(1, numberOfBornCreatures + 1);
        if (remainingIndividualsToChoose.Contains(randomIndividual))
        {
            remainingIndividualsToChoose[randomIndividual] = 0;
        }

        else
        {
            chooseRandomIndividual(randomIndividual, numberOfBornCreatures, individualsArray, this.couplesArray, remainingIndividualsToChoose);
        }

        return randomIndividual;

    }

    

    public int chooseRandomSeed(int randomSeed, int numberOfSeeds, Individuals[] individualsArray, int[][] couplesArray, int[] remainingSeedsToChoose)
    {
        Random randomNumber = new Random();
        randomSeed = randomNumber.Next(1, numberOfSeeds + 1);
        if (remainingSeedsToChoose.Contains(randomSeed))
        {
            remainingSeedsToChoose[randomSeed] = 0;
        }

        else
        {
            chooseRandomSeed(randomSeed, numberOfSeeds, individualsArray, this.couplesArray, remainingSeedsToChoose);
        }

        return randomSeed;
    }

    

    public int[][] buildNewIndividuals(int[][] parent1, int[][] parent2, int numberOfCreaturesToReceiveGenes, Individuals[] individualsArray, int[][] individualsToReceiveGenes) //Determines the genetic configuration of the creature
    {
        Random randomAlleleToDonate = new Random();
        for(int i=0; i<numberOfCreaturesToReceiveGenes;i++)
        {
           for(int j=0;j<parent1.Length;j++) //Randomly chooses one allel of parent 1 from each genetic pair
            {
                if(parent1[j] != null)
                {
                    for(int f=0;f<parent1[0].Length;)
                    if(parent1[0] == )
                    {

                    }

                    else if(parent1[j] == 1)
                    {

                    }

                    else if(parent1[j] == 2)
                    {

                    }

                }
                
            }
           for(int k=0;k<parent2.Length;k++) //Randomly chooses one allel of parent 2 from each genetic pair
            {
                if(parent2[k] != null)
                {
                    if(parent2[0] == 0)
                    {

                    }

                    else if (parent2[0] == 1)
                    {

                    }

                    else if (parent2[0] == 2)
                    {

                    }

                }
            }
            
        }

        return individualsToReceiveGenes;
    }

    public int getNumberOfCouples(int[][] couplesArray)
    {
        this.numberOfCouples = 0;
        int counter1 = 0;
        for (int i = 0; i < this.couplesArray.Length; i++)
        {
            if (this.couplesArray[i] != null)
            {
                counter1 = counter1 + 1;
                Console.WriteLine("getting number of couples1 = " + counter1);
                Console.ReadKey();
                this.numberOfCouples = this.numberOfCouples + 1;
            }

            else
            {

            }
            
        }
        this.numberOfCouples = this.numberOfCouples / 2;
        return this.numberOfCouples;
    }

    public int getNumberOfCreatures(Individuals[] individualsArray)
    {
        for (int j = 0; j < individualsArray.Length; j++)
        {
            if (individualsArray[j] != null)
            {
                this.numberOfCreatures = this.numberOfCreatures + 1;
            }
        }

        return this.numberOfCreatures;
    }

    public void resetCouplesArray(int[][] couplesArray, int numberOfCouples)
    {
        for(int i=0; i<this.couplesArray.Length;i++)
        {
            if (this.couplesArray[i] != null)
            {
                Console.WriteLine("deleting couple" + i);
                this.couplesArray[i] = null;
            }

            else
            {

            }

        }

    }


    public void startSimulation(int generations, int numberOfSeeds, Individuals[] individualsArray) //receives individualsArray or individualsArray data
    {
        Random randNum = new Random();
        int id = numberOfSeeds;
        for (int i = 0; i < generations; i++)
        {
            actualGeneration = actualGeneration + 1;
            this.formCouples(this.couplesArray, individualsArray, numberOfSeeds, numberOfBornCreatures); //Form random couples
            this.numberOfBornCreatures = 0; //Reset the number of born creatures
            getNumberOfCouples(this.couplesArray); //Get the number of couples
            getNumberOfCreatures(individualsArray); //Get the total number of creatures
            Console.WriteLine("Generation = " + actualGeneration + "   Number of creatures = " + this.numberOfCreatures + "   Number of couples = " + this.numberOfCouples);
            Console.ReadKey();
            this.copulesAndBirths(this.numberOfCouples, this.couplesArray, individualsArray, numberOfBornCreatures);
            this.resetCouplesArray(this.couplesArray, this.numberOfCouples); //Reset the couples array
            getNumberOfCouples(this.couplesArray);
            Console.WriteLine("new generation? [Press any key]");
            Console.ReadKey();

        }

    }
}
