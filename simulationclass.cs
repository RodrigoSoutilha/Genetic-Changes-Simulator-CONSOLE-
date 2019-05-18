class Simulation
    {
        public void startSimulation()
        {
            int id1 = 1;
            int id2 = id1 + 1;
            int allBornCreatures = 0;
            int numberOfCouples = 1;
            int totalNumberOfCreatures = 0;
            int numberOfIndividualsThatDiedWithoutProcriating = 0;
            int totalNumberOfCouples = 0;
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
                        individualArrays[id1] = new Individual();
                    }

                    if (allBornCreatures % 2 == 0)
                    {
                        // check if the number of born creature is even or odd, to choose randomly them by pairs to mate

                        allBornCreatures = 0;

                    }

                }
            }
        }
        public 


    }
   
    
}
