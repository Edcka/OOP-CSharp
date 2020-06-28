using System;
using System.Collections.Generic;
namespace OOPLAB
{
    /*Skirta sukurti paskyrai, taip pat yra
     parent klase HashDehash klasei, kad turetu
     tiesiogini priejima prie hashing funkciju*/
    public class Paskyra
    {

        public string username, hashedPassword;

        public List<Paskyra> paskyros = new List<Paskyra>();


        public string NaujaPaskyra(string username, string password)
        {
            Paskyra temp = new Paskyra();
            temp.username = username;
            temp.hashedPassword = HashDehash.Encrypt(password, "manodieve");
            string tempstring = (string.Format("{0}\n{1}", temp.username, temp.hashedPassword));

            paskyros.Add(temp);

            return tempstring;
        }


        public void IkeltiPaskyras(Filer file)
        {
            string line;

            while ((line = file.ReadFromFile()) != null)
            {
                Paskyra temp = new Paskyra();
                temp.username = line;
                temp.hashedPassword = file.ReadFromFile();
                paskyros.Add(temp);
            }

        }

        public int listdydis()
        {
            return paskyros.Count;
        }

        public string PatikrintiSlaptazodi(string username, string password)
        {
            foreach (Paskyra current in paskyros)
            {
                if (current.username.Equals(username))
                {
                    string unhashedPassword = HashDehash.Decrypt(current.hashedPassword, "manodieve");
                    if (unhashedPassword.Equals(password))
                    {
                        return "Teisingas";
                    }
                    else return "Neteisingas";
                }

            }
            return "Toks username nerastas";
        }

        public string DesifruotiVartotojoSlaptazodi(string username)
        {
            foreach (Paskyra current in paskyros)
            {
                if (current.username.Equals(username))
                {
                    string tempstring = (string.Format("{0} {1}", current.username, HashDehash.Decrypt(current.hashedPassword, "manodieve")));
                    return tempstring;
                }
            }
            return "Toks username nerastas";
        }

        public void VisiVartotojai()
        {
            foreach (Paskyra current in paskyros)
            {
                string tempstring = (string.Format("{0} {1}", current.username, current.hashedPassword));
                Console.WriteLine(tempstring);
            }
        }

        public void DesifruotiVisusSlaptazodzius()
        {
            foreach (Paskyra current in paskyros)
            {
                current.hashedPassword = HashDehash.Decrypt(current.hashedPassword, "manodieve");

            }
            VisiVartotojai();
        }

    }
}