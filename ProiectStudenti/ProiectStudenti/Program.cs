//Tema1 PIU Andrei Ventuneac 3121A Calculatoare
//Realizare meniu
//Optiune de reexaminare
//Optiune de creste nota
//Optiuni afisare

using System;
using LibrarieModele;
using NivelAccesDate;


namespace Teema1
{
    
    class Program
    {
        static int nrstud = 0;

        public static int Cautare(Student[] stude, string _nume, string _prenume)
        {
            for (int i = 0; i <= nrstud; i++)
            {
                if (stude[i].Nume == _nume && stude[i].Prenume == _prenume)
                {
                    return i;
                }
            }
            return -1;
        }

        static void Main(string[] args)
        {
            int totaltime = 0;
            string Start = "PROIECT PIU\nANDREI VENTUNEAC\n3121A CALCULATOARE\nSUCEAVA 2020    ";
            while (true)
            {
                int waittime = 37;
                int i = 0;
                do
                {
                    Console.Write(Start[i]);
                    Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop);
                    System.Threading.Thread.Sleep(waittime);
                    totaltime = totaltime + waittime;
                    i++;
                } while (totaltime < 2300);
                break;
           }
                         

            IStocareData adminStudenti = StocareFactory.GetAdministratorStocare();

            Student s = new Student();          
            string intrebare_;
            string[] intrebare = new string[] { "Ce functie este utilizata pentru a afisa un text pe o line de consola?", "Ce functie este utilizata pentru a citi o linie de pe consola?", "O clasa poate avea membrii publici?" };
            string[] raspunss = new string[] { "Console.WriteLine()", "Console.ReadLine()", "DA" };
            Student elev = new Student("Andrei,Tudor,10,1,2");
            elev.Status = "admis";
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nLISTA ELEVI + NOTE + situatie: \n");
            Console.ForegroundColor = ConsoleColor.White;
            //Console.WriteLine(elev.ConversieLaSir());

            //sir de obiecte + functie random
            string[] nume = new string[] { "Popescu", "Maradona", "Georgescu", "Scutescu" };
            string[] prenume = new string[] { "Andrei", "Alexandru", "Mircea", "Stefan" };
       
            Student[] elevi = new Student[200];

            int nrStudenti1;
            adminStudenti.GetStudenti(elevi, out nrStudenti1, nrstud);
            Student.IDultim = nrStudenti1;
            nrstud = nrStudenti1 - 1;

            for(int i = 0; i<=nrstud; i++)
            {
                Console.Write(elevi[i].ConversieLaSir());
                Console.WriteLine();
            }
           
            Random rnd = new Random();
            /*
            for (int i = 0; i <= nrstud; i++)
            {
                string nume_ = nume[rnd.Next(0, nume.Length)];
                string prenume_ = prenume[rnd.Next(0, prenume.Length)];
                double nota_ = rnd.Next(1, 10);
                int IdEnum = rnd.Next(1, 6);
                elevi[i] = new Student(nume_, prenume_, nota_);
                elevi[i].Facultate = (Facultati)IdEnum;

                for (int j = 0; j < rnd.Next(1, 6); j++)
                {
                    var op = (Optiuni)rnd.Next(1, 32);
                    elevi[i].Optiune = elevi[i].Optiune | op;
                }

                if (elevi[i].Nota >= Student.MINIM)
                    elevi[i].Status = Student.GOOD;
                else
                    elevi[i].Status = Student.BAD;

                
                Console.Write(elevi[i].ConversieLaSir());                            
                Console.WriteLine();
            }         
            */

            while (true)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;                
                    Console.WriteLine("\nR: Reexaminare elevi");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("C: Crestere nota elevi admisi");
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine("A: Afisare lista elevi");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("F: Afisare lista elevi respinsi");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine("O: Comparare doi elevi");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("M: Cautare si modifcare date elev");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("D : Adaugare studenti fisier");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("K : Citire studenti fisier");
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine("S: Adaugare elev random");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("X: Exit");
                    Console.ForegroundColor = ConsoleColor.White;

                    Console.Write("\nALEGERE OPTIUNE: ");
                    string c = Console.ReadLine();
                    switch (c)
                    {
                        case "S":
                        nrstud++;
                        string _nume_ = nume[rnd.Next(0, nume.Length)];
                        string _prenume_ = prenume[rnd.Next(0, prenume.Length)];
                        double _nota_ = rnd.Next(1, 10);
                        int IdEnum = rnd.Next(1, 6);
                        elevi[nrstud] = new Student(_nume_, _prenume_, _nota_);
                        elevi[nrstud].Facultate = (Facultati)IdEnum;

                        for (int j = 0; j < rnd.Next(1, 6); j++)
                        {
                            var op = (Optiuni)rnd.Next(1, 32);
                            elevi[nrstud].Optiune = elevi[nrstud].Optiune | op;
                        }

                        if (elevi[nrstud].Nota >= Student.MINIM)
                            elevi[nrstud].Status = Student.GOOD;
                        else
                            elevi[nrstud].Status = Student.BAD;

                        adminStudenti.AddStudent(elevi[nrstud]);
                        Console.WriteLine("ADAUGARE FINALIZATA!");
                        Console.ReadKey();
                        Console.Clear();
                        break;

                    case "R":
                            Console.WriteLine("\nDoriti o reexaminare a elevilor? (DA/NU)\n");
                            string raspuns;
                            raspuns = Console.ReadLine();
                            int admis = 0;

                            if (raspuns == "DA")
                            {
                                for (int i = 0; i <= nrstud; i++)
                                {
                                    if (elevi[i].Status.Equals("respins"))
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("\n\n---------------------------------------------------------------------------------------------------------------");
                                        Console.WriteLine("|                                                                                                              |");
                                        Console.ForegroundColor = ConsoleColor.White;
                                        Console.Write("|   " + string.Format(elevi[i].Numecomplet + " cu intrebarea:  "));
                                        intrebare_ = intrebare[rnd.Next(0, intrebare.Length)];
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.Write(" " + intrebare_ + "\n");
                                        Console.WriteLine("|                                                                                                              |");
                                        Console.WriteLine("---------------------------------------------------------------------------------------------------------------");
                                        Console.Write("\nRASPUNS : ");
                                        Console.ForegroundColor = ConsoleColor.White;
                                        string raspuns_ = Console.ReadLine();

                                        for (int j = 0; j <= 2; j++)
                                        {
                                            if (intrebare_.Equals(intrebare[j]))
                                            {
                                                if (raspuns_.Equals(raspunss[j]))
                                                {
                                                    admis = 1;
                                                }
                                                else
                                                {
                                                    admis = 0;
                                                }
                                            }
                                        }

                                        if (admis == 1)
                                        {
                                            Console.WriteLine("Felicitari sunteti admis cu nota 5!\n");
                                            elevi[i].Nota = 5;
                                            elevi[i].Status = Student.GOOD;
                                        }
                                        else
                                        {
                                            Console.WriteLine("Ati picat iar testul!");
                                        }

                                    }
                                }
                            }

                            //reexaminare - raspunde la o intrebare pentru a trece sau ramai picat!
                            //reafisare elevi respinsi
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("\nElevii respinsi dupa reactualizare:");
                            Console.ForegroundColor = ConsoleColor.White;
                            for (int i = 0; i <= nrstud; i++)
                            {
                                if (elevi[i].Status.Equals("respins") && elevi[i].Afisareresp() != string.Empty)
                                {
                                    Console.WriteLine(elevi[i].Afisareresp());
                                }
                            }
                            Console.ReadKey();
                            Console.Clear();
                            break;

                        case "C":
                            Console.WriteLine("\nDoriti marirea notelor elevilor admisi? (DA/NU)\n");
                            string raspuns1;
                            raspuns1 = Console.ReadLine();
                            int admis1 = 0;
                            if (raspuns1 == "DA")
                            {
                                for (int i = 0; i <= nrstud; i++)
                                {
                                    if (elevi[i].Status.Equals("admis") && elevi[i].Nota < 10)
                                    {
                                        Console.ForegroundColor = ConsoleColor.Green;
                                        Console.WriteLine("\n\n---------------------------------------------------------------------------------------------------------------");
                                        Console.WriteLine("|                                                                                                              |");
                                        Console.ForegroundColor = ConsoleColor.White;
                                        Console.Write("|   " + string.Format(elevi[i].Numecomplet + " cu intrebarea:  "));
                                        intrebare_ = intrebare[rnd.Next(0, intrebare.Length)];
                                        Console.ForegroundColor = ConsoleColor.Green;
                                        Console.Write(" " + intrebare_ + "\n");
                                        Console.WriteLine("|                                                                                                              |");
                                        Console.WriteLine("---------------------------------------------------------------------------------------------------------------");
                                        Console.Write("\nRASPUNS : ");
                                        Console.ForegroundColor = ConsoleColor.White;
                                        string raspuns_ = Console.ReadLine();

                                        for (int j = 0; j <= 2; j++)
                                        {
                                            if (intrebare_.Equals(intrebare[j]))
                                            {
                                                if (raspuns_.Equals(raspunss[j]))
                                                {
                                                    admis1 = 1;
                                                }
                                                else
                                                {
                                                    admis1 = 0;
                                                }
                                            }
                                        }

                                        if (admis1 == 1)
                                        {
                                            Console.WriteLine("Felicitari ti-ai marit nota cu un punct!\n");
                                            elevi[i].Nota += 1;

                                        }
                                        else
                                        {
                                            Console.WriteLine("Raspuns gresit!");
                                        }

                                    }
                                }
                            }


                            //reafisare elevi admisi
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("\nNotele elevilor admisi dupa reactualizare: ");
                            Console.ForegroundColor = ConsoleColor.White;
                            for (int i = 0; i <= nrstud; i++)
                            {
                                if (elevi[i].Status.Equals("admis") && elevi[i].Afisareadmis() != string.Empty)
                                {
                                    Console.WriteLine(elevi[i].Afisareadmis());
                                }
                            }
                            Console.ReadKey();
                            Console.Clear();
                            break;

                        case "A":
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("\nAFISARE LISTA ELEVI");
                            Console.ForegroundColor = ConsoleColor.White;
                            for (int i = 0; i <= nrstud; i++)
                            {
                                Console.WriteLine(elevi[i].ConversieLaSir());
                            }
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        case "F":
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("\nElevii respinsi");
                            Console.ForegroundColor = ConsoleColor.White;
                            for (int i = 0; i <= nrstud; i++)
                            {
                                if (elevi[i].Status.Equals("respins"))
                                {
                                    Console.WriteLine(elevi[i].ConversieLaSirRespins());
                                }
                            }
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        case "O":
                            Console.Write("\nCITIRE NUMAR SUDENT1: ");
                            int nrstud1 = Convert.ToInt32(Console.ReadLine());
                            Console.Write("CITIRE NUMAR SUDENT2: ");
                            int nrstud2 = Convert.ToInt32(Console.ReadLine());
                        if (nrstud1 <= nrstud && nrstud2 <= nrstud)
                        {

                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("\nAti ales studentii :");
                            Console.WriteLine(elevi[nrstud1].ConversieLaSir());
                            Console.WriteLine(elevi[nrstud2].ConversieLaSir());
                            Console.WriteLine();
                            Console.ForegroundColor = ConsoleColor.White;
                            int ok;
                            ok = elevi[nrstud1].Compare(elevi[nrstud2]);

                            if (ok == Student.MARE)
                            {
                                Console.WriteLine("ELEVUL " + elevi[nrstud1].Numecomplet + " > ELEVUL " + elevi[nrstud2].Numecomplet);
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Aveam asteptari mai mari pentru tine domnule " + elevi[nrstud2].Numecomplet);
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                            else
                            {
                                Console.WriteLine("ELEVUL " + elevi[nrstud1].Numecomplet + " < ELEVUL " + elevi[nrstud2].Numecomplet);
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Aveam asteptari mai mari de la tine domnule " + elevi[nrstud1].Numecomplet);
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                        }
                        else
                        {
                            Console.WriteLine("PROBLEMA CAUTARE ELEV!!!");
                        }
                            Console.WriteLine();
                            Console.ReadKey();
                            Console.Clear();
                            break;

                        case "M":
                            Console.WriteLine("Introdu numele elevului: ");
                            string nume_ = Console.ReadLine();
                            Console.WriteLine("Introdu prenumele elevului: ");
                            string prenume_ = Console.ReadLine();
                            int okk = Cautare(elevi, nume_, prenume_);

                            if (okk >= 0)
                            {
                                Console.WriteLine("ELEVUL A FOST GASIT!!!!!\n");
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("A.Modificare numecomplet");
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.WriteLine("B.Modificare nota");
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("C.Modificare completa");
                                Console.ForegroundColor = ConsoleColor.Magenta;
                                Console.WriteLine("Introduceti optiunea: ");
                                Console.ForegroundColor = ConsoleColor.White;
                                string caz = Console.ReadLine();

                                if (caz == "A")
                                {
                                    Console.WriteLine("Introdu numele nou: ");
                                    string numeNou_ = Console.ReadLine();
                                    Console.WriteLine("Introdu prenumele nou: ");
                                    string prenumeNou_ = Console.ReadLine();
                                    elevi[okk].Nume = numeNou_;
                                    elevi[okk].Prenume = prenumeNou_;
                                    Console.ReadKey();
                                }
                                if (caz == "B")
                                {

                                    Console.WriteLine("Introdu nota noua: ");
                                    int notaNoua_ = Convert.ToInt32(Console.ReadLine());
                                    elevi[okk].Nota = notaNoua_;
                                    if (notaNoua_ >= Student.MINIM)
                                        elevi[okk].Status = Student.GOOD;
                                    else
                                        elevi[okk].Status = Student.BAD;
                                Console.ReadKey();
                                }

                                if (caz == "C")
                                {
                                    Console.WriteLine("Introdu numele nou: ");
                                    string numeNou1_ = Console.ReadLine();
                                    Console.WriteLine("Introdu prenumele nou: ");
                                    string prenumeNou1_ = Console.ReadLine();
                                    elevi[okk].Nume = numeNou1_;
                                    elevi[okk].Prenume = prenumeNou1_;


                                    Console.WriteLine("Introdu nota noua: ");
                                    int notaNoua1_ = Convert.ToInt32(Console.ReadLine());
                                    elevi[okk].Nota = notaNoua1_;
                                    if (notaNoua1_ >= Student.MINIM)
                                    elevi[okk].Status = Student.GOOD;
                                    else
                                    elevi[okk].Status = Student.BAD;
                                Console.ReadKey();
                                }

                            }
                            else
                            {
                                Console.WriteLine("NU A FOST GASIT ELEVUL RESPECTIV!");
                                Console.ReadKey();
                            }

                            adminStudenti.StergeFisier();
                            for (int i = 0; i <= nrstud; i++)
                             {
                                adminStudenti.AddStudent(elevi[i]);
                             }

                        Console.Clear();
                            break;

                        case "D":
                             
                            adminStudenti.StergeFisier();
                            for (int i = 0; i <= nrstud; i++)
                            {
                                adminStudenti.AddStudent(elevi[i]);
                            }
                            Console.WriteLine("ADAUGARE FINALIZATA!");
                            
                            Console.ReadKey();
                            Console.Clear();
                            break;

                        case "K":
                            int nrStudenti;
                            adminStudenti.GetStudenti(elevi, out nrStudenti,nrstud);
                            Student.IDultim = nrStudenti;
                            nrstud = nrStudenti-1;
                            //Console.WriteLine(nrStudenti);
                            Console.ReadKey();
                            Console.Clear();
                            break;

                        case "X":
                            Environment.Exit(0);
                            break;

                        default:
                            Console.ReadKey();
                            Console.Clear();
                            break;
                    }


                }
            

        }
    }
}
