using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarieModele
{
    public class Student
    {
        public const int MINIM = 5;
        const int NM = 0;
        const int PR = 1;
        const int NT = 2;
        const int FC = 3;
        const int OP = 4;

        public const string GOOD = "admis";
        public const string BAD = "respins";
        public const int MARE = 1;
        public const int MIC = 0;

        public Facultati Facultate
        {
            get;
            set;
        }

        public Optiuni Optiune
        {
            get;
            set;
        }

        public static  int IDultim { get; set; }
        public string Nume { get; set; }
        public string Prenume { get; set; }
        public double Nota { get; set; }
        public string Status { get; set; }
        public string Numecomplet { get; set; }

        public Student()
        {
            Nota = 0;
            Nume = string.Empty;
            Prenume = string.Empty;
            Status = string.Empty;
            Numecomplet = Nume + ' ' + Prenume;
            IDultim++;
        }

        public Student(string nume_, string prenume_, double nota_)
        {
            Nota = nota_;
            Nume = nume_;
            Prenume = prenume_;
            Numecomplet = Nume + ' ' + Prenume;
            IDultim++;
        }

        public string ConversieLaSir()
        {
            //return string.Format("Elevul {0} de la {1}  are nota {2} si este admis si are optiunea {3}", numecomplet, Facultate, nota,Optiune);
            if (Status == GOOD)
                return string.Format("---------------------------\n" +
                                     "|()    ....     ....    ()|\n" +
                                     "|()    ( .)     (. )    ()|     NUME : {0}    \n" +
                                     "|()                     ()|     PRENUME : {1}    \n" +
                                     "|()   -             -   ()|     NOTA : {2}    \n" +
                                     "|()    -           -    ()|     STATUS : {3}    \n" +
                                     "|()      ---------      ()|     Facultatea : {4}\n" +
                                     "|()                     ()|     Optiuni : {5}\n" +
                                     "|()                     ()|\n" +
                                     "---------------------------", Nume,Prenume,Nota,Status,Facultate,Optiune);
            else
                return string.Format("---------------------------\n" +
                                     "|()   ......   ......   ()|\n" +
                                     "|()   (  .)     (.  )   ()|     NUME : {0}    \n" +
                                     "|()       ________      ()|     PRENUME : {1}    \n" +
                                     "|()      |_______|      ()|     NOTA : {2}    \n" +
                                     "|()                     ()|     STATUS : {3}    \n" +
                                     "|()          __         ()|     Facultatea : {4}\n" +
                                     "|()                     ()|     Optiuni : {5}\n" +
                                     "|()                     ()|\n" +
                                     "---------------------------", Nume, Prenume, Nota, Status, Facultate, Optiune);
        }
        public string ConversieLaSirRespins()
        {       
                return string.Format("---------------------------\n" +
                                     "|()   ......   ......   ()|\n" +
                                     "|()   (  .)     (.  )   ()|     NUME : {0}    \n" +
                                     "|()       ________      ()|     PRENUME : {1}    \n" +
                                     "|()      |_______|      ()|     NOTA : {2}    \n" +
                                     "|()                     ()|     STATUS : {3}    \n" +
                                     "|()          __         ()|     Facultatea : {4}\n" +
                                     "|()                     ()|     Optiuni : {5}\n" +
                                     "|()                     ()|\n" +
                                     "---------------------------", Nume, Prenume, Nota, Status, Facultate, Optiune);
        }

        public string ConversieLaSirFisier()
        {
            return string.Format("{0},{1},{2},{3},{4}", Nume, Prenume, Nota, Convert.ToInt32(Facultate), Convert.ToInt32(Optiune));
        }

        public string Afisareresp()
           {
            if (Status == BAD)
                return string.Format("{0} {1} : nota {2}", Nume, Prenume, Nota);
            else
                return string.Empty;
           }

        public string Afisareadmis()
        {
            if (Status == GOOD)
                return string.Format("{0} {1} : nota {2}", Nume, Prenume, Nota);
            else
                return string.Empty;
        }

        public Student(string text)
        {
            int k = 0;
            string[] cuvinte = text.Split(',');
            foreach (string cuv in cuvinte)
            {
                if (k == NM)
                    Nume = cuv;
                if (k == PR)
                    Prenume = cuv;
                if (k == NT)
                    Nota = Convert.ToDouble(cuv);
                if (k == FC)
                    Facultate = (Facultati)Convert.ToInt32(cuv);
                if (k >= OP)
                    Optiune = Optiune|(Optiuni)Convert.ToInt32(cuv);       
                k++;
            }
            if (Nota >= MINIM)
                Status = GOOD;
            else
                Status = BAD;
            Numecomplet = Nume + ' ' + Prenume;
            IDultim++;
        }

        public int Compare(Student el)
        {
            int ok = 0;
            if (this.Nota > el.Nota)
                ok = MARE;
            if (this.Nota == el.Nota)
                ok = String.Compare(this.Nume, el.Nume);
            if (this.Nota < el.Nota)
                ok = MIC;

            return ok;
        }

     
    }
}
