#include <iostream>
#include <thread>
#include <vector>
#include <string>
#include <conio.h>

using namespace std;


struct Settings 
{
    public:
    int numberOfChosenGenes;
    int geneticConfiguration[999] = { };
    int chosenGenes[999] = { };
    int numberOfSeeds;
    int numberOfSeedsGenes;
    string choose;
    int generations;

    string confirmationScreen()
    {
        cout<<"Confirm? [Y/N]";
    }

    int setNumberOfSeeds()
    {
        cout<<"Number of seeds: ";
        try
        {
            cin>>choose;
        }
        catch(const std::exception& e)
        {
            std::cerr << e.what() << '\n';
        }

    }
};

struct Individuals 
{
    int geneticConfiguration[9999] = { };
    int chosenGenes[9999] = { };
    int numberOfChosenGenes;
    int numberOfSeeds;
    int numberOfSeedsGenes;
    int index;
};

struct Simulation
{
    int actualGeneration = 0;
    int generations;
    int id;
    int id2;
    int numberOfBornCreatures;
    int numberOfCouples;
    int numberOfCreatures;
    int individualsOfCurrentGeneration[99999] = { };
    int individualsToReceiveGenes[99999] = { };
    int newCreatures = 0;
    int couplesArray[99999] = { };
    int numberOfCreaturesThatDiedWithoutProcriating = 0;
    bool seedsCouplesFormed = false;
};

int main() 
{

}
