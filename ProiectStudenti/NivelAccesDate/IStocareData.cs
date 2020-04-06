using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibrarieModele;

namespace NivelAccesDate
{
    public interface IStocareData
    {
        void AddStudent(Student s);
        Student[] GetStudenti(Student[] elev ,out int nrStudenti,int nrstd);
        void StergeFisier();
    }
}
