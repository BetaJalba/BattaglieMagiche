// See https://aka.ms/new-console-template for more information
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using BattaglieMagiche;

CGiocatore giocatore1;
CGiocatore giocatore2;
bool turnoP1;


Console.WriteLine("Inserisci nome giocatore 1: ");
giocatore1 = new CGiocatore(Console.ReadLine());
giocatore2 = new CGiocatore("CPU");

//gioco
Gioco();

//risultati
Console.WriteLine("\nVincitore:\n\t" + mazzo[ControllaVincitore(mazzo)].Print() + "\n");

Console.WriteLine("Tutto il mazzo: ");
for (int i = 0; i < mazzo.Length; i++)
    Console.WriteLine("\t" + mazzo[i].Print());

void Gioco() 
{
    int scelta;
    string[] mazzo;

    while (ControllaVincita()) 
    {
        if (turnoP1)
        {
            //scelta attaccante
            do
            {
                mazzo = giocatore1.DisplayMazzo();
                Console.WriteLine("Scegli attaccante: \n");
                Console.WriteLine(mazzo[0]);
                Console.WriteLine("\nScelta: ");
            } while (!int.TryParse(Console.ReadLine(), out scelta) || !mazzo[1].Contains(scelta.ToString()));

            //scelta bersaglio
            do
            {
                mazzo = giocatore2.DisplayMazzo();
                Console.WriteLine("Scegli bersaglio: \n");
                Console.WriteLine(mazzo[0]);
                Console.WriteLine("\nScelta: ");
            } while (!int.TryParse(Console.ReadLine(), out scelta) || !mazzo[1].Contains(scelta.ToString()));

            //attacco
            AttaccaDifensore(giocatore2, scelta, ScegliAttaccante(giocatore1, scelta));
            turnoP1 = false;
        }
        else
        {
            ScegliAttaccanteCPU();
            ScegliDifensoreCPU();
            turnoP1 = true;
        }
    }
}

int ScegliAttaccante(CGiocatore player, int scelta) 
{
    if (player.mazzo[scelta].e_vivo())
        return player.ScegliAttaccante(scelta);
    return -1;
}

void AttaccaDifensore(CGiocatore player, int scelta, int danno) 
{
    player.ScegliDifensore(scelta, danno);
}
int ScegliAttaccanteCPU(CGiocatore player) 
{

}

void ScegliDifensoreCPU(CGiocatore playerToDamage) 
{

}

string DisplayMazzo(CGiocatore player) 
{

}

bool ControllaVincita(CPersonaggio[] mazzo) 
{
    int numeroMorti = 0;

    for (int i = 0; i < mazzo.Length; i++) 
    {
        if (!mazzo[i].e_vivo())
            numeroMorti++;
    }

    if (numeroMorti >= 9)
        return true;
    return false;
}

void Combatti(CPersonaggio[] mazzo, int[] combattenti) 
{
    mazzo[combattenti[1]].ricevi_danno(mazzo[combattenti[0]].attacca());
}

int ControllaVincitore(CGiocatore p1, CGiocatore p2) 
{
    for (int i = 0; i < mazzo.Length; i++)
    {
        if (mazzo[i].e_vivo())
            return i;
    }
    return -1;
}
