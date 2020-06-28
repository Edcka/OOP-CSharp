using System;
using System.IO;
namespace OOPLAB
{
    class Program
    {
        static void Main(string[] args)
        {
            //Inicilizacija
            Paskyra paskyra = new Paskyra();
            Loggeris logs = new Loggeris();
            Filer failai = new Filer();
            logs.SetLogPath();
            failai.InitialRead();
            paskyra.IkeltiPaskyras(failai);
            failai.CloseReader();
            failai.SetPathToWrite();


            logs.WriteLog("Programa Ijunkta");
            string choice = "0";
            //intro
            Console.WriteLine("Atliko : Edvardas Tambakevicius ISKS9;");
            Console.WriteLine("Programa skirta uzkoduoti slaptaiodzius i file");
            Console.WriteLine("Default path slaptazodziu ir log failui yra ten kur paleidziama programa ");

            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();
            Console.Clear();


            //meniu
            while (choice != "99")
            {
                Console.WriteLine();
                Console.WriteLine("1. Pasirinkti Failu Path.");
                Console.WriteLine("2. Prideti Nauja Paskyra.");
                Console.WriteLine("3. Patikrinti ar Teisingas Vartotojo Slaptazodis ");
                Console.WriteLine("4. Desifruoti Slaptazodzius.");
                Console.WriteLine("5. Desifruoti Pasirinkto Vartotojo Slaptazodi");
                Console.WriteLine("99.Uzdaryti Programa.");

                Console.Write("\n Pasirinkimas : ");
                choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        string temp = "0";
                        logs.WriteLog("Path Meniu");
                        Console.WriteLine("Pranesima: jei Path jau egzistuoja, informacija bus " +
                            "automatiskai nuskaityta, o nauja irasoma i tapati faila");
                        Console.WriteLine("1. Pasirinkti Password Faila.");
                        Console.WriteLine("2. Pasirinkti Log Faila.");
                        Console.WriteLine("3. Atgal.");
                        Console.Write("Pasirinkimas : ");
                        temp = Console.ReadLine();

                        switch (temp)
                        {
                            case "1":
                                Console.WriteLine("Iveskite password file path...");
                                string kelias = Console.ReadLine();

                                if (File.Exists(kelias).Equals(true))
                                {
                                    failai.SetPathToRead(kelias);
                                    paskyra.IkeltiPaskyras(failai);
                                    logs.WriteLog("Paskyros nuskaitytos is " + kelias);
                                    failai.CloseReader();
                                    failai.SetPathToWrite(kelias);
                                }
                                else
                                {
                                    logs.WriteLog("Sukurtas naujas paskyru failas @ " + kelias);
                                    failai.SetPathToWrite(kelias);
                                }
                                break;
                            case "2":
                                Console.WriteLine("Iveskite Log file path...");
                                string keliasL = Console.ReadLine();
                                logs.WriteLog("Keiciamas Log path @ " + keliasL);
                                logs.SetLogPath(keliasL);
                                break;
                            case "3":
                                break;

                        }


                        break;

                    case "2":
                        Console.Write("Iveskite nauja username : ");
                        string username = Console.ReadLine();
                        Console.Write("Iveskite password : ");
                        string password = Console.ReadLine();
                        failai.WriterInFile(paskyra.NaujaPaskyra(username, password));
                        logs.WriteLog("Sukurta nauja paskyra : " + username + " " + password);
                        failai.FlushInFile();


                        break;

                    case "3":
                        Console.WriteLine("Iveskite username : ");
                        string tempUser = Console.ReadLine();
                        Console.WriteLine("Iveskite password : ");
                        string tempPass = Console.ReadLine();
                        logs.WriteLog("Tikrinamas slaptazodis @ " + tempUser);
                        Console.WriteLine(paskyra.PatikrintiSlaptazodi(tempUser, tempPass))
                            ;
                        break;
                    case "4":
                        paskyra.DesifruotiVisusSlaptazodzius();
                        logs.WriteLog("Desifruoti visi slaptazodziai");
                        break;
                    case "5":
                        Console.Write("Iveskite vartotoja kurio slaptazodi norite atkoduoti : ");
                        string vartotojas = Console.ReadLine();
                        paskyra.DesifruotiVartotojoSlaptazodi(vartotojas);
                        logs.WriteLog("Desitruotas vartotojo slaptazodis @ " + vartotojas);
                        break;

                    case "99":

                        break;
                }

            }

            logs.WriteLog("Uzdaroma programa");
            Console.WriteLine("Press any key to exit...");
            Console.ReadLine();
        }
    }
}
