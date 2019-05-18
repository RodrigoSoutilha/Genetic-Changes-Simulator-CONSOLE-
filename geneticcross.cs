using System;

public class Program
{
    public static void Main()
    {
        Individuals setNewSimulation = new Individuals(0);
        setNewSimulation.setSeeds();

    }

}


public class Individuals
{
    public int[] geneticConfiguration { get; set; }
    public int[] chosenGenes { get; set; }
    public int numberOfChosenGenes;

    public Individuals(int numberOfSimulatedGenes)
    {
        this.numberOfChosenGenes = numberOfSimulatedGenes;
        this.geneticConfiguration = new int[numberOfChosenGenes];
        this.chosenGenes = new int[numberOfChosenGenes];
    }

    public int setSeeds() 
    {
        int i;
        int j;
        int k;
        int h;
        int g;
        int f;
        int choose_gene;
        Random randomNumber = new Random();
        Console.WriteLine("Number of seeds: ");
        int numberOfSeeds = int.Parse(Console.ReadLine());
        Console.Clear();
        Individuals[] individualsArray = new Individuals[numberOfSeeds];
        Console.WriteLine("Type the number of genes you wanna work with"); 
        int getnumberOfChosenGenes = int.Parse(Console.ReadLine());
        Console.Clear();
        this.numberOfChosenGenes = getnumberOfChosenGenes;
        Console.WriteLine(this.chosenGenes.Length.ToString());

        for (i = 0; i < numberOfSeeds; i++)
        {
            individualsArray[i] = new Individuals(getnumberOfChosenGenes);
        }
        Console.WriteLine("Choose genes");
        Console.WriteLine("[1] [2] [3] [4] [5] [6] [7] [8] [9] [10]");
        choose_gene = int.Parse(Console.ReadLine());
        for (g = 0; g < getnumberOfChosenGenes; g++)  
        {
            for (f = 0; f < numberOfSeeds; f++)
            {

                individualsArray[f].chosenGenes[g] = choose_gene;
            }
        }

        Console.WriteLine("How do you want the seeds's genetics?");
        Console.WriteLine("[1] Random");
        Console.WriteLine("[2] Custom");
        int choose = int.Parse(Console.ReadLine()); 
        if (choose == 1)
        {
            for (k = 0; k < numberOfChosenGenes; k++) 
            {
                individualsArray[k].geneticConfiguration[k] = randomNumber.Next(0, 4);
                Console.WriteLine(individualsArray[k].geneticConfiguration[k]);
            }
        }
        else
        {
            //custom
        }
        Console.WriteLine("skrr skrr skrr");
        Console.ReadLine();
        return 0;
    }
}
