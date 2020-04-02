using LibrarieModele;
using System;
using System.Collections.Generic;

namespace NivelAccesDate
{
    //clasa AdministrareStudenti_FisierBinar implementeaza interfata IStocareData
    public class AdministrareStudenti_FisierBIN : IStocareData
    {
        string NumeFisier { get; set; }
        public AdministrareStudenti_FisierBIN(string numeFisiser)
        {
            this.NumeFisier = NumeFisier;
        }

        public void AddStudent(Student s)
        {
            throw new Exception("Optiunea AddStudent nu este implementata");
        }

        public Student[] GetStudenti(Student[] elev,out int nrStudenti,int nrstd)
        {
            throw new Exception("Optiunea GetStudenti nu este implementata");
        }
    }
}
