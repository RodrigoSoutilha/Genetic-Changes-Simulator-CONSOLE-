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
    public int[] chosenGenes;
    public int numberOfChosenGenes;

    public Individuals(int numberOfSimulatedGenes)
    {
        geneticConfiguration = new int[numberOfChosenGenes];
        chosenGenes = new int[numberOfChosenGenes];
    }
    public int setSeeds() ///////////////////////////////////AQUI////////////////////////////////////////
    {
        int i;
        int j;
        int k;
	int h;
	int g;
	int choose_gene;
	Random randomNumber = new Random();
        Console.WriteLine("Number of seeds: "); // Number of generations
        int numberOfSeeds = int.Parse(Console.ReadLine()); ;
        Console.Clear();
        Individuals[] individualsArray = new Individuals[numberOfSeeds];
        Console.WriteLine("Type the number of genes you wanna work with"); // int numberOfSimulatedGenes
        int getnumberOfChosenGenes = int.Parse(Console.ReadLine());
        Console.Clear();
        this.numberOfChosenGenes = getnumberOfChosenGenes;

        for (i = 0; i < numberOfSeeds; i++)
        {
        	individualsArray[i] = new Individuals(getnumberOfChosenGenes);
	}
        for (h = 0; h < numberOfChosenGenes;h++) //get genes the user will simulate and store in the individuals inside individuals array
	{
		Console.WriteLine("Choose genes");
		choose_gene = int.Parse(Console.ReadLine());
		for(g = 0;g<numberOfSeeds;g++)
		{
			individualsArray[g].chosenGenes[h] = choose_gene;
		}
	}		
	Console.WriteLine("How do you want the seeds's genetics?");
        Console.WriteLine("[1] Random");
        Console.WriteLine("[2] Custom");
        int choose = int.Parse(Console.ReadLine()); //aqui também
        if (choose == 1)
        {
		for(k=0;k<numberOfChosenGenes;k++)
	{
          	individualsArray[k].geneticConfiguration[k] = randomNumber.Next(0,4);
		Console.WriteLine(individualsArray[k].geneticConfiguration[k]);
	}  
}
        else 
	{
	//custom
	}
        Console.WriteLine("skrr skrr skrr"); //cola num compilador online pra vc testar
        Console.ReadLine();
        return 0;
    }
}
