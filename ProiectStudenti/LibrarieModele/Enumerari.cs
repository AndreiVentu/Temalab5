using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarieModele
{ 
    public enum Facultati
    {
       Facultatea_de_Inginerie_Electrica_si_Stiinta_Calculatoarelor=1,
       Facultatea_de_Drep_si_Stiinte_Administrative,
       Facultatea_de_Educatie_Fizica_si_Sport,
       Facultatea_de_Inginerie_Alimentara,
       Facultatea_de_Istorie_si_Greografie,
       Facultatea_de_Litere_si_Stiinte_ale_Comunicarii
    }



    [Flags]
    public enum Optiuni
    {
        Bursa = 1,
        Restanta=2,
        Talent_copiat_la_examen=4,
        Mers_cu_masina_la_facultate=8,
        Mancat_in_pauza_de_masa_la_cantina=16,
        Microbist_a=32,
     
    }

}
