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
        public string nume { get; set; }
        public string prenume { get; set; }
        public double nota { get; set; }
        public string status { get; set; }
        public string numecomplet { get; set; }

        public Student()
        {
            nota = 0;
            nume = string.Empty;
            prenume = string.Empty;
            status = string.Empty;
            numecomplet = nume + ' ' + prenume;
            IDultim++;
        }

        public Student(string nume_, string prenume_, double nota_)
        {
            nota = nota_;
            nume = nume_;
            prenume = prenume_;
            numecomplet = nume + ' ' + prenume;
            IDultim++;
        }

        public string ConversieLaSir()
        {
            //return string.Format("Elevul {0} de la {1}  are nota {2} si este admis si are optiunea {3}", numecomplet, Facultate, nota,Optiune);
            if (status == GOOD)
                return string.Format("---------------------------\n" +
                                     "|()    ....     ....    ()|\n" +
                                     "|()    ( .)     (. )    ()|     NUME : {0}    \n" +
                                     "|()                     ()|     PRENUME : {1}    \n" +
                                     "|()   -             -   ()|     NOTA : {2}    \n" +
                                     "|()    -           -    ()|     STATUS : {3}    \n" +
                                     "|()      ---------      ()|     Facultatea : {4}\n" +
                                     "|()                     ()|     Optiuni : {5}\n" +
                                     "|()                     ()|\n" +
                                     "---------------------------", nume,prenume,nota,status,Facultate,Optiune);
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
                                     "---------------------------", nume, prenume, nota, status, Facultate, Optiune);
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
                                     "---------------------------", nume, prenume, nota, status, Facultate, Optiune);
        }

        public string Afisareresp()
           {
            if (status == BAD)
                return string.Format("{0} {1} : nota {2}", nume, prenume, nota);
            else
                return string.Empty;
           }

        public string Afisareadmis()
        {
            if (status == GOOD)
                return string.Format("{0} {1} : nota {2}", nume, prenume, nota);
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
                    nume = cuv;
                if (k == PR)
                    prenume = cuv;
                if (k == NT)
                    nota = Convert.ToDouble(cuv);
                if (k == FC)
                    Facultate = (Facultati)Convert.ToInt32(cuv);
                if (k == OP)
                    Optiune = (Optiuni)Convert.ToInt32(cuv);       
                k++;
            }
            if (nota >= MINIM)
                status = GOOD;
            else
                status = BAD;
            numecomplet = nume + ' ' + prenume;
            IDultim++;
        }

        public int Compare(Student el)
        {
            int ok = 0;
            if (this.nota > el.nota)
                ok = MARE;
            if (this.nota == el.nota)
                ok = String.Compare(this.nume, el.nume);
            if (this.nota < el.nota)
                ok = MIC;

            return ok;
        }

     
    }
}
