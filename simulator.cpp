#include <iostream>
#include <thread>
#include <vector>
#include <string>
#include <conio.h>
#include <stdlib.h>

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
        cin>>choose;
        if (choose == "Y")
        {

        }
        else if(choose == "y")
        {

        }
        else if (choose == "N")
        {
            system("CLS");
            //return to calling function
        }
        else if (choose == "n")
        {
            system("CLS");
            //return to calling function
        }
        else
        {
            system("CLS");
            cout<<"You must enter a valid value..."<<endl;
            confirmationScreen();
        }

    }

    int setNumberOfSeeds()
    {
        cout<<"Number of seeds:  ";
        try
        {
            cin>>this->numberOfSeeds;
        }
        catch(const std::exception& e)
        {
            system("CLS");
            cout<<"The number of seeds must be an integer..."<<endl;
            this->setNumberOfSeeds();
        }
        if (this->numberOfSeeds == 0)
        {
            system("CLS");
            cout<<"The number of seeds cannot be zero..."<<endl;
            this->setNumberOfSeeds();
        }
        else if (this->numberOfSeeds < 0)
        {
            system("CLS");
            cout<<"The number of seeds cannot be minor than zero..."<<endl;
            this->setNumberOfSeeds();
        }
        else
        {
        this->confirmationScreen();
        }
        return this->numberOfSeeds;
    }

    int setNumberOfSeedsGenes()
    {
        cout<<"Number of genes in the seeds genome: "<<endl;
        try
        {
            cin>>this->numberOfSeedsGenes;
        }
        catch(const std::exception& e)
        {
            system("CLS");
            cout<<"The number of genes must be an integer..."<<endl;
            this->setNumberOfSeedsGenes();
        }
        
        if(numberOfSeeds == 0)
        {
            system("CLS");
            cout<<"The genome cannot have zero genes"<<endl;
            this->setNumberOfSeedsGenes();
        }
        else if(numberOfSeeds < 0)
        {
            system("CLS");
            cout<<"The genome cannot be minor than zero"<<endl;
            this->setNumberOfSeedsGenes();
        }
        else
        {
            confirmationScreen();
        }
        return this->numberOfSeeds;
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
    system("CLS");
    system("color 1F");
    //Thread displaying the seeds info being chosen by the user
    Settings settings;
    Individuals individuals;
    Simulation simulation;
    settings.setNumberOfSeeds();
    settings.setNumberOfSeedsGenes();
    settings.setChosenGenes(settings.numberOfSeedsGenes);
    settings.seedsGeneticConfiguration(settings.numberOfSeedsGenes);
    settings.seedsConfirmation(settings.numberOfSeedsGenes, settings.numberOfSeeds, settings.geneticConfiguration);
    settings.setGenerations();
}
