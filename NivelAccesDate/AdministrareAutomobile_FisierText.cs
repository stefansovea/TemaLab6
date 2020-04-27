using LibrarieModele;
using System;
using System.Collections.Generic;
using System.IO;

namespace NivelAccesDate
{
    public class AdministrareAutomobile_FisierText: IStocareData
    {
        private const int PAS_ALOCARE = 10;
        string NumeFisier { get; set; }
        public AdministrareAutomobile_FisierText(string numeFisier)
        {
            this.NumeFisier = numeFisier;
            Stream sFisierText = File.Open(numeFisier, FileMode.OpenOrCreate);
            sFisierText.Close();
        }
        public void AddAutomobil(Automobile []s,int _numarmasini)
        {
            if (File.Exists(@"C:\Users\Stefan\source\repos\TemaLab5\Problema\Problema\bin\Debug\Automobile.txt"))
            {
                File.WriteAllText(@"C:\Users\Stefan\source\repos\TemaLab5\Problema\Problema\bin\Debug\Automobile.txt", String.Empty);
            }
            for (int i = 0; i < _numarmasini; i++)
            {
                try
                {
                    using (StreamWriter swFisierText = new StreamWriter(NumeFisier, true))
                    {
                        swFisierText.WriteLine(s[i].afisare());
                    }
                }
                catch (IOException eIO)
                {
                    throw new Exception("Eroare la deschiderea fisierului. Mesaj: " + eIO.Message);
                }
                catch (Exception eGen)
                {
                    throw new Exception("Eroare generica. Mesaj: " + eGen.Message);
                }
            }
        }

        public Automobile[] GetAutomobile(out int NumarMasini)
        {
            Automobile[] masini = new Automobile[PAS_ALOCARE];

            try
            {
                // instructiunea 'using' va apela sr.Close()
                using (StreamReader sr = new StreamReader(NumeFisier))
                {
                    string line;
                    NumarMasini = 0;

                    //citeste cate o linie si creaza un obiect de tip Student pe baza datelor din linia citita
                    while ((line = sr.ReadLine()) != null)
                    {
                        masini[NumarMasini] = new Automobile(line);
                        NumarMasini++;
                        if (NumarMasini == PAS_ALOCARE)
                        {
                            Array.Resize(ref masini, NumarMasini + PAS_ALOCARE);
                        }
                    }
                }
            }
            catch (IOException eIO)
            {
                throw new Exception("Eroare la deschiderea fisierului. Mesaj: " + eIO.Message);
            }
            catch (Exception eGen)
            {
                throw new Exception("Eroare generica. Mesaj: " + eGen.Message);
            }

            return masini;
        }
    }
}
