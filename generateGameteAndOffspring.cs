using System;

public class Program
{
	public static void Main()
	{
	int i;
	int j;
	int chosenCreature1;
	int chosenCreature2;
	int[] chosenCreaturesToCopulate = new int[2];
	Random randNum = new Random();
	Console.WriteLine("num of born creatures");
	int allBornCreatures = int.Parse(Console.ReadLine());
	 if (allBornCreatures % 2 == 0)  // check if the number of born creature is even or odd, to choose randomly them by pairs to mate
     {
		 
		 for(j=0;j<allBornCreatures;j++)
		 {
		 	chosenCreature1 = randNum.Next(1,allBornCreatures + 1);
			chosenCreature2 = randNum.Next(1,allBornCreatures + 1);
			chosenCreaturesToCopulate[i] = chosenCreature1;
			chosenCreaturesToCopulate[i] = chosenCreature2;
		 	 for(i=0;i<5;i++)
			 {
			 /*/later I must fix it, to assure the values cannot repeat, 
			 the value cannot repeat in none of these two fors, Take out the chosen creature each iteration, until there's no one (final iteration)/*/
			 Console.WriteLine(chosenCreaturesToCopulate[i]);
			 }
		 }
			
	  }
	  else 
	  {
		 
	  }
		  
		 
	
	
}
}
