using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibrarieModele;

namespace NivelAccesDate
{
    public class AdministrareStudenti_FisierTXT: IStocareData
    {
        const int PASaloc = 10;
        string NumeFisier { get; set; }
        string NumeFisier1 { get; set; }

        public AdministrareStudenti_FisierTXT(string numefisier_,string numefisier1_)
        {
            NumeFisier = numefisier_;
            NumeFisier1 = numefisier1_;
            Stream FisierText = File.Open(numefisier_, FileMode.Create, FileAccess.ReadWrite);
            Stream FisierText2 = File.Open(numefisier1_, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            FisierText.Close();
            FisierText2.Close();

        }

        public void AddStudent(Student s)
        {
            try
            {             
                using (StreamWriter swFisierText = new StreamWriter(NumeFisier, true))
                {
                    swFisierText.WriteLine(s.ConversieLaSir());
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

        public Student[] GetStudenti(Student[] elev,out int nrStudenti,int nrstd)
        {
           //elev = new Student[PASaloc];
            
           try
           {
               // instructiunea 'using' va apela sr.Close()
               using (StreamReader sr = new StreamReader(NumeFisier1))
               {
                   string line;
                   nrStudenti = nrstd;

                   //citeste cate o linie si creaza un obiect de tip Student pe baza datelor din linia citita
                   while ((line = sr.ReadLine()) != null)
                   {
                       elev[nrStudenti++] = new Student(line);
                       /*if (nrStudenti == PASaloc)
                       {
                            Array.Resize(ref elev, nrStudenti + PASaloc);
                       }*/
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
           
            
            return null;
            
        }

        
    }
}
