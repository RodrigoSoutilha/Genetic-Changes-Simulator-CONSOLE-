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
        simulation.startSimulation(settings.generations, settings.numberOfSeeds, individualsArray, settings.numberOfSeedsGenes);
        Console.WriteLine("end");
        Console.ReadLine();

    }
}


public class Individuals
{
    public int?[] geneticConfiguration = new int?[99999];
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
    public int?[] geneticConfiguration = new int?[99999];
    public int[] chosenGenes = new int[999999];
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

    public int?[] generateRandomGenome(int numberOfSeedsGenes)
    {
        for (int i = 0; i < this.numberOfSeedsGenes; i++)
        {
            Random randNumber = new Random();
            this.geneticConfiguration[i] = randNumber.Next(0, 3);
        }

        return this.geneticConfiguration;
    }

    public int?[] setSeedsGeneticConfiguration(int numberOfSeedsGenes)
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

    public void seedsConfirmation(int numberOfSeedsGenes, int numberOfSeeds, int?[] geneticConfiguration)
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
    public int?[][] individualsOfCurrentGeneration = new int?[99999][];
    public int?[][] builtIndividualsFromCurrentCouple = new int?[99999][];
    public int newCreatures = 0;
    public int?[][] couplesArray = new int?[99999][];
    public int numberOfCreaturesThatDiedWithoutProcriating = 0;
    bool seedsCouplesFormed = false;
    Random randomNumber = new Random();


    public int?[][] copulesAndBirths(int numberOfCouples, int?[][] couplesArray, Individuals[] individualsArray, int numberOfBornCreatures, int numberOfSeedsGenes)
    {
        //start making the allBornCreatures array fully null
        Random randomCouple = new Random();
        int numberOfCreaturesToReceiveGenes = 0;
        int parent1 = 0;
        int parent2 = 0;
        int?[] chosenParent1 = new int?[9999];
        int?[] chosenParent2 = new int?[9999];
        int?[] newIndividual = new int?[numberOfSeedsGenes];
        for (int i = 0; i < numberOfCouples; i++)
        {
            Console.WriteLine("Generating births");
            //set a couple to have children
            parent1 = chooseRandomCouple(parent1, couplesArray);
            parent2 = parent1 + 1;
            for (int l = 0; l < numberOfSeedsGenes; l++)
            {
                chosenParent1[l] = couplesArray[parent1][l];
                chosenParent2[l] = couplesArray[parent2][l];
            }

            //couplesArray[parent1];
            //couplesArray[parent2];
            Random randomBirths = new Random();
            for (int m = 0; m < randomBirths.Next(1, 7); m++) //Creates an object for each born creature
            {
                numberOfBornCreatures = numberOfBornCreatures + 1;
                numberOfCreaturesToReceiveGenes = numberOfCreaturesToReceiveGenes + 1;
            }


            for (int w = 0; w < numberOfCreaturesToReceiveGenes; w++)
            {
                builtIndividualsFromCurrentCouple[0] = buildNewIndividual(chosenParent1, chosenParent2, numberOfCreaturesToReceiveGenes, individualsArray, newIndividual, numberOfSeedsGenes);
                for (int b = 0; b < newIndividual.Length; b++)
                {
                    if (newIndividual != null) // Clear newIndividual array for the next creature
                    {
                        newIndividual[b] = null;
                    }
                    else
                    {

                    }
                }
            }

            for (int j = 0; j < numberOfCreaturesToReceiveGenes; j++) //pass the individuals from builtIndividualsFromCurrentCouple to individualsOfCurrentGeneration
            {
                if (individualsOfCurrentGeneration != null)
                {
                    individualsOfCurrentGeneration[j] = builtIndividualsFromCurrentCouple[j];
                }
            }

            for (int h = 0; h < builtIndividualsFromCurrentCouple.Length; h++)  //reset individualsToReceiveGenes array, to be able to receive the next brooding's genes
            {
                if (builtIndividualsFromCurrentCouple[h] != null)
                {
                    builtIndividualsFromCurrentCouple[h] = null;
                }
            }

            for (int y = 0; y < chosenParent1.Length; y++) // reset chosenParent1 array to receive the next chosen parent 1
            {
                if (chosenParent1[y] != null)
                {
                    chosenParent1[y] = null;
                }
            }

            for (int z = 0; z < chosenParent2.Length; z++) //reset chosenParent2 array to receive the next chosen parent 2
            {
                if (chosenParent2[z] != null)
                {
                    chosenParent2[z] = null;
                }
            }


            parent1 = 0;
            parent2 = 0;

            numberOfCreaturesToReceiveGenes = 0; //reset the variable to receive the number of creatures in the next brooding
        }
        Console.WriteLine("Births finalized");
        Console.ReadKey();
        return individualsOfCurrentGeneration;
    }

    public int?[][] formCouples(int?[][] couplesArray, Individuals[] individualsArray, int numberOfSeeds, int numberOfBornCreatures, int?[][] individualsOfCurrentGeneration)
    {
        int?[] remainingSeedsToChoose = new int?[(numberOfSeeds - (numberOfSeeds % 2) + 2)];
        int?[] remainingIndividualsToChoose = new int?[(numberOfBornCreatures - (numberOfBornCreatures % 2)) + 9999];
        int randomIndividual = 0;
        int randomSeed1 = 0;
        int randomSeed2 = 0;

        if (numberOfBornCreatures != 0) //Form couples with the current generations' creatures
        {
            for (int v = 0; v < this.numberOfBornCreatures; v++) //Fill the reamainingIndividualsToChoose array
            {
                remainingIndividualsToChoose[v] = v; // ajeitar    
            }

            for (int r = 0; r < numberOfBornCreatures - (numberOfBornCreatures % 2); r++)
            {
                Console.WriteLine("picking random creature " + r + "  to form couples");
                Console.ReadKey();
                randomIndividual = chooseRandomIndividual(randomIndividual, numberOfBornCreatures, individualsArray, this.couplesArray, remainingIndividualsToChoose);
                this.couplesArray[r] = individualsOfCurrentGeneration[randomIndividual];
            }

            if (numberOfBornCreatures % 2 == 1)
            {
                this.numberOfCreaturesThatDiedWithoutProcriating = this.numberOfCreaturesThatDiedWithoutProcriating + 1;
            }


        }

        else  //Form the first couples with the seeds
        {
            int k;
            int coupleCounter = 2;
            for (int v = 0; v < numberOfSeeds; v++) //Fill the remainingSeedsToChoose
            {
                remainingSeedsToChoose[v] = v;
            }

            for (int i = 0; i < numberOfSeeds - (numberOfSeeds % 2); i++)
            {
                k = i + 1;
                Console.WriteLine("picking random seed" + i + " to form couples");
                Console.ReadKey();
                randomSeed1 = chooseRandomSeed1(randomSeed1, numberOfSeeds, individualsArray, this.couplesArray, remainingSeedsToChoose);
                remainingSeedsToChoose[randomSeed1] = null;
                this.couplesArray[i] = individualsArray[randomSeed1].geneticConfiguration;
                
                    if (i % 2 == 0)
                    {
                        Console.WriteLine("Getting Couple " + coupleCounter + " Parent1 =  " + randomSeed1);
                        Console.ReadKey();
                    }
                    else if (i % 2 == 1)
                    {
                        Console.WriteLine("Getting Couple " + coupleCounter + "Parent2 = " + randomSeed1);
                        coupleCounter = coupleCounter + 1;
                    }

                    else
                    {
                        Console.WriteLine("Error at FormCouples");
                    }
                
             
            }
    

            for(int h=0;h<this.couplesArray.Length;h++) /*/Put "one" at each creature's ninetieth position of genetic array, to be used in GenerateBirth method as a way
            to control which creature has already been chosen /*/ 
            {
                if(this.couplesArray[h] != null)
                {
                    this.couplesArray[h][90] = 1;
                }

                else if(this.couplesArray[h] == null)
                {
                    
                }
                else
                {
                    Console.WriteLine("Error at FormCouples method");
                    Console.ReadKey();
                }
            }

            if (numberOfSeeds % 2 == 1)
            {
                this.numberOfCreaturesThatDiedWithoutProcriating = this.numberOfCreaturesThatDiedWithoutProcriating + 1;
            }

            else
            {


            }
        }

        // reset remainingIndividualsToChoose and remainingIndividualsToChoose array and lock the other iteration

        for (int a = 0; a < remainingIndividualsToChoose.Length; a++)
        {
            remainingIndividualsToChoose[a] = null;
        }

        for (int b = 0; b < remainingSeedsToChoose.Length; b++)
        {
            remainingSeedsToChoose[b] = 0;
        }

        return this.couplesArray;
    }

    public int chooseRandomCouple(int parent1, int?[][] couplesArray)
    {
        parent1 = randomNumber.Next(0, couplesArray.Length);
        if (couplesArray[parent1] != null)
        {
            couplesArray[parent1] = null;
            couplesArray[parent1 + 1] = null;
        }
        else if (couplesArray[parent1][90] == null)
        {
            chooseRandomCouple(parent1, couplesArray);
        }
        else
        {
            Console.WriteLine("Error at chooseRandomCouple method");
            Console.ReadKey();
        }

        return parent1;
    }

    public int chooseRandomIndividual(int randomIndividual, int allBornCreatures, Individuals[] individualsArray, int?[][] couplesArray, int?[] remainingIndividualsToChoose)
    {
        int randomRemainingIndividual = 0;

        randomIndividual = randomNumber.Next(0, numberOfBornCreatures + 1);
        if (remainingIndividualsToChoose[randomRemainingIndividual] != null)
        {
            randomIndividual = remainingIndividualsToChoose[randomRemainingIndividual].Value;
            remainingIndividualsToChoose[randomRemainingIndividual] = null;
            remainingIndividualsToChoose[randomRemainingIndividual + 1] = null;
        }

        else
        {
            chooseRandomIndividual(randomIndividual, numberOfBornCreatures, individualsArray, this.couplesArray, remainingIndividualsToChoose);
        }

        return randomIndividual;

    }



    public int chooseRandomSeed1(int randomSeed1, int numberOfSeeds, Individuals[] individualsArray, int?[][] couplesArray, int?[] remainingSeedsToChoose)
    {
        int randomRemainingSeed = 0;
        randomRemainingSeed = this.randomNumber.Next(0, numberOfSeeds + 1);
        if (remainingSeedsToChoose.Contains(randomRemainingSeed))
        {
            randomSeed1 = randomRemainingSeed;
            remainingSeedsToChoose[randomRemainingSeed] = null;
        }

        else
        {
            chooseRandomSeed1(randomSeed1, numberOfSeeds, individualsArray, this.couplesArray, remainingSeedsToChoose);
        }

        return randomSeed1;
    }

 

    public int?[] buildNewIndividual(int?[] chosenParent1, int?[] chosenParent2, int numberOfCreaturesToReceiveGenes, Individuals[] individualsArray, int?[] newIndividual, int numberOfSeedsGenes) //Determines the genetic configuration of the creature
    {
        Random chooseRandomAllele = new Random();
        bool parent1AlleleToDonate = true;
        bool parent2AlleleToDonate = true;

        for (int h = 0; h < numberOfSeedsGenes; h++)
        {
            if (chosenParent1[h] == 0) //Choo
            {
                parent1AlleleToDonate = true;
            }
            else if (chosenParent1[h] == 1)
            {
                if (chooseRandomAllele.Next(0, 2) == 1)
                {
                    parent1AlleleToDonate = true;
                }
                else if (chooseRandomAllele.Next(0, 2) == 0)
                {
                    parent1AlleleToDonate = false;
                }
                else
                {
                    Console.WriteLine("Error at buildNewIndividual");
                    Console.ReadKey();
                }
            }
            else if (chosenParent1[h] == 2)
            {
                parent1AlleleToDonate = false;
            }
            else
            {
                Console.WriteLine("Error at buildNewIndividual");
                Console.ReadKey();
            }

            if (chosenParent2[h] == 0)
            {
                parent2AlleleToDonate = true;
            }

            else if (chosenParent2[h] == 1)
            {
                if (chooseRandomAllele.Next(0, 2) == 1)
                {
                    parent2AlleleToDonate = true;
                }
                else if (chooseRandomAllele.Next(0, 2) == 0)
                {
                    parent2AlleleToDonate = false;
                }
                else
                {
                    Console.WriteLine("Error at buildNewIndividual");
                    Console.ReadKey();
                }
            }
            else if (chosenParent2[h] == 2)
            {
                parent2AlleleToDonate = false;
            }
            else
            {
                Console.WriteLine("Error at buildNewIndividual");
                Console.ReadKey();
            }

            //Builds new individual gene

            if (parent1AlleleToDonate == true && parent2AlleleToDonate == true)
            {
                newIndividual[h] = 0;
            }

            else if (parent1AlleleToDonate == false && parent2AlleleToDonate == false)
            {
                newIndividual[h] = 2;
            }

            else if (parent1AlleleToDonate == true && parent2AlleleToDonate == false)
            {
                newIndividual[h] = 1;
            }

            else if (parent1AlleleToDonate == false && parent2AlleleToDonate == true)
            {
                newIndividual[h] = 1;
            }

            else
            {
                Console.WriteLine("Error at buildNewIndividual");
                Console.ReadKey();
            }

        }

        return newIndividual;
    }

    public int getNumberOfCouples(int?[][] couplesArray)
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

    public void resetCouplesArray(int?[][] couplesArray, int numberOfCouples)
    {
        for (int i = 0; i < this.couplesArray.Length; i++)
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


    public void startSimulation(int generations, int numberOfSeeds, Individuals[] individualsArray, int numberOfSeedsGenes) //receives individualsArray or individualsArray data
    {
        Random randNum = new Random();
        int id = numberOfSeeds;
        for (int i = 0; i < generations; i++)
        {
            actualGeneration = actualGeneration + 1;
            this.formCouples(this.couplesArray, individualsArray, numberOfSeeds, numberOfBornCreatures, individualsOfCurrentGeneration); //Form random couples
            this.numberOfBornCreatures = 0; //Reset the number of born creatures
            getNumberOfCouples(this.couplesArray); //Get the number of couples
            getNumberOfCreatures(individualsArray); //Get the total number of creatures
            Console.WriteLine("Generation = " + actualGeneration + "   Number of creatures = " + this.numberOfCreatures + "   Number of couples = " + this.numberOfCouples);
            Console.ReadKey();
            this.copulesAndBirths(this.numberOfCouples, this.couplesArray, individualsArray, numberOfBornCreatures, numberOfSeedsGenes);
            this.resetCouplesArray(this.couplesArray, this.numberOfCouples); //Reset the couples array
            getNumberOfCouples(this.couplesArray);
            Console.WriteLine("new generation? [Press any key]");
            Console.ReadKey();

        }

    }
}
