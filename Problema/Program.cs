using System;
using LibrarieModele;

namespace Problema
{
    class Problema
    {
        
        public const int MAX = 100;
        static void Main()
        {
            NivelAccesDate.IStocareData adminAutomobile = StocareFactory.GetAdministratorStocare();
            int x;
            int NumarMasini = 0;
            int nrmasini;
            long buget, b1;
            string m1, c1;
            Automobile[] masini = new Automobile[MAX];
            /*masini[0] = new Automobile("audi", "rosu", 50000, 1); NumarMasini++;
             masini[1] = new Automobile("bmw", "albastru", 70000, 1); NumarMasini++;
             masini[2] = new Automobile("toyota", "alb", 20000, 2); NumarMasini++;
             masini[3] = new Automobile("dacia,verde,10000,3"); NumarMasini++;
             masini[0].Opt = (Optiuni)1 | (Optiuni)2;
             masini[1].Opt = (Optiuni)4 | (Optiuni)8;
             masini[2].Opt = (Optiuni)1 | (Optiuni)16;
             masini[3].Opt = (Optiuni)2 | (Optiuni)4 | (Optiuni)8;
             */
            masini = adminAutomobile.GetAutomobile(out nrmasini);
            NumarMasini = nrmasini;
            do
            {
                Console.Clear();
                Console.WriteLine("     MENIU    ");
                Console.WriteLine("A: Afisati modelele disponibile:");
                Console.WriteLine("Z: Adaugati o masina citita ca string");
                Console.WriteLine("Y: Adaugati o masina citita de la tastatura");
                Console.WriteLine("P: Verificare masina in functie de preferinte");
                Console.WriteLine("C: Optiuni in functie de Culoare  ");
                Console.WriteLine("M: Optiuni in functie de Marca ");
                Console.WriteLine("B: Optiuni in functie de Buget");
                Console.WriteLine("N: Arata masina cea mai ieftina");
                Console.WriteLine("V: Compara pretul a doua optiuni");
                Console.WriteLine("K: Cauta si modifica masina");
                Console.WriteLine("J: Adauga automobile in fisier txt");
                Console.WriteLine("I: Info autor ");
                Console.WriteLine("X: Iesire ");
                x = Console.ReadKey().KeyChar;
                Console.WriteLine();
                switch (x)
                {
                    case 'i':
                        Console.WriteLine("Sovea Stefan, grupa 3121A");
                        Console.ReadKey();
                        break;
                    case 'x':
                        Environment.Exit(1);
                        break;
                    case 'a':
                        Console.WriteLine("Optiuni disponibile:");
                        Console.WriteLine();
                        for (int i = 0; i < NumarMasini; i++)
                        {
                            string c = masini[i].afisareconsola();
                            Console.WriteLine("Optiunea {0}: {1}", i + 1, c);
                        }
                        Console.ReadKey();
                        break;
                    case 'p':
                        Console.WriteLine("Marca dorita:");
                        string optiune = Console.ReadLine();
                        Console.WriteLine("Culoarea dorita:");
                        string opcul = Console.ReadLine();
                        Console.WriteLine("Introduceti bugetul dumneavoastra:");
                        buget = Convert.ToInt64(Console.ReadLine());
                        int ok = 0;
                        for (int i = 0; i < NumarMasini; i++)
                        {
                            ok = masini[i].Preferinte(optiune, opcul, buget);
                            if (ok == 1)
                            {
                                Console.WriteLine("Optiunea exista si va permiteti sa o achizitionati");
                                break;
                            }
                            if (ok == 2)
                            {
                                Console.WriteLine("Optiunea exista, dar nu va permiteti sa o achizitionati");
                                break;
                            }
                        }
                        if (ok == 0)
                            Console.WriteLine("Optiunea nu exista ");
                        Console.ReadKey();
                        break;
                     case 'c':
                        Console.WriteLine("Introduceti culoarea cautata:");
                        string cul = Console.ReadLine();
                         ok = 0;
                        for (int i = 0; i < NumarMasini; i++)
                        { 
                            if (masini[i].Culoare.Equals(cul))
                            {
                                Console.WriteLine(masini[i].afisare());
                                ok = 1;
                            }
                        }
                        if ( ok == 0)
                            Console.WriteLine("Nu sunt optiuni disponibile");
                        Console.ReadKey();
                        break; 
                    case 'm':
                        Console.WriteLine("Introduceti marca cautata:");
                        string mar = Console.ReadLine();
                        ok = 0;
                        for (int i = 0; i < NumarMasini; i++)
                        {                           
                            if (masini[i].Marca.Equals(mar))
                            {
                                Console.WriteLine(masini[i].afisare());
                                ok = 1;
                            }
                        }
                        if (ok == 0)
                            Console.WriteLine("Nu sunt optiuni disponibile");
                        Console.ReadKey();
                        break;
                    case 'b':
                        Console.WriteLine("Introduceti bugetul de care dispuneti:");
                        long bug = Convert.ToInt64(Console.ReadLine());
                        ok = 0;
                        for (int t = 0; t < NumarMasini; t++)
                        {
                            if (masini[t].Pret < bug)
                            {
                                Console.WriteLine(masini[t].afisare());
                                ok = 1;
                            }
                        }
                        if (ok == 0)
                            Console.WriteLine("Nu sunt optiuni disponibile");
                        Console.ReadKey();
                        break;
                    case 'n':
                        long BugetRef = masini[1].Pret;
                        int j = 0;
                        for (int i = 0; i < NumarMasini; i++)
                        {
                            if (masini[i].Pret < BugetRef)
                            {
                                BugetRef = masini[i].Pret;
                                j = i;
                            }
                        }
                        Console.WriteLine(masini[j].afisare());
                        Console.ReadKey();
                        break;

                    case 'v':
                        Console.WriteLine("       COMPARATOR     ");
                        Console.WriteLine("Introduceti numarul primei optiuni de comparat:");
                        int comp1 = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Introduceti numarul celei de-a doua optiuni de comparat:");
                        int comp2 = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine(masini[comp2 - 1].Compara(masini[comp1 - 1].Pret));
                        Console.ReadKey();
                        break;

                    case 'k':
                        Console.WriteLine("Introduceti marca masinii cautate:");
                        string marc = Console.ReadLine();
                        Console.WriteLine("Introduceti noua marca:");
                        string newmarc = Console.ReadLine();
                        Console.WriteLine("Introduceti noua culoare:");
                        string newcul = Console.ReadLine();
                        Console.WriteLine("Introduceti noul pret");
                        long newpret = Convert.ToInt64(Console.ReadLine());
                        Console.WriteLine("Introduceti noua clasa de buget:");
                        ClasaBuget newbug = (ClasaBuget)Convert.ToInt32(Console.ReadLine());
                        ok = 0;
                        for (int i=0;i<NumarMasini;i++)
                        {
                            if(masini[i].Marca.Equals(marc))
                            {
                                masini[i].Marca = newmarc;
                                masini[i].Culoare = newcul;
                                masini[i].Pret = newpret;
                                masini[i].BugetClass = newbug;
                                ok = 1;
                                Console.WriteLine("Modificare facuta cu succes!");
                            }
                        }
                        if (ok == 0)
                            Console.WriteLine("Nu a fost gasita masina");
                        Console.ReadKey();
                        break;
                    case 'z':
                        Console.WriteLine("Creare inregistrare masina (string)");
                        Console.WriteLine("Introduceti marca,culoarea,pretul,Clasa de Buget (1-High, 2-Mid, 3- Low), optiunile alese, separate prin virgula");
                        Console.WriteLine("Optiuni: AerConditionat=1, CutieAutomata = 2, Decapotabila = 4,Navigatie = 8, SonorizareBOSE = 16");
                        masini[NumarMasini] = new Automobile(Console.ReadLine());
                        Random rnd = new Random();
                        for(int i=0;i<rnd.Next(1,5);i++)
                        {                           
                            masini[NumarMasini].Opt = masini[NumarMasini].Opt | (Optiuni)Convert.ToInt32(rnd.Next(1,16));
                        }
                        NumarMasini++;
                        Console.ReadKey();
                        break;
                    case 'y':
                        Console.WriteLine("Creare inregistrare citire rand cu rand de la tastatura");
                        Console.WriteLine("Marca:");
                        m1 = Console.ReadLine();
                        Console.WriteLine("Culoare:");
                        c1 = Console.ReadLine();
                        Console.WriteLine("Pret:");
                        b1 = Convert.ToInt64(Console.ReadLine());
                        Console.WriteLine("Clasa de Buget(1-High, 2-Mid, 3- Low):");
                        int cl1 = Convert.ToInt32(Console.ReadLine());
                        masini[NumarMasini] = new Automobile(m1, c1, b1, cl1);
                        Random rand = new Random();
                        for (int i = 0; i < rand.Next(1, 5); i++)
                        {
                            masini[NumarMasini].Opt = masini[NumarMasini].Opt | (Optiuni)Convert.ToInt32(rand.Next(1, 16));
                        }
                        NumarMasini++;
                        Console.ReadKey();
                        break;
                    case 'j':
                        adminAutomobile.AddAutomobil(masini, NumarMasini);
                        Console.WriteLine("Scriere cu succes!");
                        Console.ReadKey();
                        break;
                }

            } while (1 != 0);
            Console.ReadKey();
        }
    }
}