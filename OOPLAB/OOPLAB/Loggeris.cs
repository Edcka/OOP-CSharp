using System;

namespace OOPLAB
/*Klase skirta log metodams sukurti ir naudoti programoje
 * taip pat yra parent klase Filer klasei
 kad turetu tiesiogine prieeiga prie Filer naudojamu metodu
 susijusiu su file keliais, ju skaitymu ir rasymu*/
{
    class Loggeris : Filer
    {

        Filer log = new Filer();
        //Default Path
        private string path = "Logs.txt";



        public void SetLogPath()
        {
            log.SetPathToWrite(this.path);
        }


        public void SetLogPath(string path)
        {
            log.SetPathToWrite(path);
            this.path = path;

        }

        public void WriteLog(string text)
        {
            string timer = DateTime.Now.ToString("[yyyy HH: mm:ss] :");
            string temp = string.Format("{0} {1}", timer, text);
            log.WriterInFile(temp);
            log.FlushInFile();
        }



    }
}
