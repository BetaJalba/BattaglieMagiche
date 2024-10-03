using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattaglieMagiche
{
    public class CGiocatore
    {
        static List<string> nomiMaghi = new List<string> { "Ubaldo", "Gerry", "Cobra", "Tate", "Nasa", "Rennala", "Ranni", "Ren", "Seluvis", "Radahn", "Kaiba", "Yugi", "Nero", "Ragazza nera", "Mago gagagaga", "Artistamico Mago Volante", "Giaguaro tandem macchina da guerra", "Drago Rosa Nera", "Sergio", "Samurai Superpesante" };
        static List<string> nomiGuerrieri = new List<string> { "Pippo, Ippopotamo III", "Alexander", "Alexander suo figlio", "Malenia", "Sir. Gideon Ofnir", "NonSoComeScriverlo Loux", "Godfrey the other Grafted", "Soldier of God, Rick", "Meteorick Beast", "Fioritura della cenere", "Maxx. C", "Endritch Abomination", "Skystalker", "Chutalla", "Chewbacca", "Mini Pekka", "Bambi", "Gandalf", "Enrico Vasaio" };
        static List<string> nomiArcieri = new List<string> { "Regina arcieri", "Arciere magico", "Levi", "Mikasa", "Eren", "Armin", "Adolfo", "Rudolfo", "Benito", "Giuseppe", "Robin O'block", "Non lo so", "Arcimbaldo", "Opium Prime", "Gorlock the Destroyer", "Alberto", "Sir. Gideon Ofnir II", "Fred", "Phineas", "Ferb" };

        public CPersonaggio[] mazzo { get; private set; }
        string nome;

        public CGiocatore(string nome) 
        {
            this.nome = nome;
            mazzo = new CPersonaggio[10];
            GeneraMazzo(mazzo);
        }

        public void GeneraMazzo(CPersonaggio[] mazzo)
        {
            Random random = new Random();
            int scelta; //scelta nome

            for (int i = 0; i < mazzo.Length; i++)
            {
                switch (random.Next(3))
                {
                    case 0:
                        scelta = random.Next(nomiGuerrieri.Count);
                        mazzo[i] = new CGuerriero(nomiGuerrieri[scelta]);
                        nomiGuerrieri.RemoveAt(scelta);
                        break;
                    case 1:
                        scelta = random.Next(nomiMaghi.Count);
                        mazzo[i] = new CMago(nomiMaghi[scelta]);
                        nomiMaghi.RemoveAt(scelta);
                        break;
                    case 2:
                        scelta = random.Next(nomiArcieri.Count);
                        mazzo[i] = new CArciere(nomiArcieri[scelta]);
                        nomiArcieri.RemoveAt(scelta);
                        break;
                    default:
                        scelta = random.Next(nomiMaghi.Count);
                        mazzo[i] = new CMago(nomiMaghi[scelta]);
                        nomiMaghi.RemoveAt(scelta);
                        break;
                }
            }
        }

        public string[] DisplayMazzo() 
        {
            string r1 = $"Mazzo di {nome}:\n";
            string r2 = string.Empty;
            string[] r = new string[2] { r1, r2};

            for (int i = 0; i < mazzo.Length; i++)
            {
                if (mazzo[i].e_vivo()) 
                {
                    r1 += $"\t[{i}] {mazzo[i].Print()}\n";
                    r2 += i.ToString();
                }
            }

            return r;
        }

        public void ResetMazzo() 
        {
            for (int i = 0; i < mazzo.Length; i++)
            {
                if (mazzo[i] is CGuerriero)
                    mazzo[i] = new CGuerriero(mazzo[i].GetNome());
                else if (mazzo[i] is CMago)
                    mazzo[i] = new CMago(mazzo[i].GetNome());
                else if (mazzo[i] is CArciere)
                    mazzo[i] = new CArciere(mazzo[i].GetNome());
                else
                    throw new Exception("Personaggio non trovato!");
            }
        }

        public int ScegliAttaccante(int n) 
        {
            return mazzo[n].attacca();
        }

        public void ScegliDifensore(int n, int danno) 
        {
            mazzo[n].ricevi_danno(danno);
        }

        public int GetMostDMG() //restituisce il danno più alto (per CPU)
        {
            int maggiore = 0;
            foreach (CPersonaggio personaggio in mazzo) 
            {
                int danno = personaggio.attacca();
                if (danno > maggiore)
                    maggiore = danno;
            }
        }
        public int GetMostHP() //restituisce l'indice della carta con  più vita
        {

        }
    }
}
