namespace OOPLAB
/*Klase skirta failu valdymui, keliams nustatyti skaytyti ir rasyti i failus*/
{
    using System.IO;
    public class Filer
    {
        StreamWriter writer;
        StreamReader reader;
        string path = "Paskyros.txt";

        public void SetPathToRead(string path)
        {
            reader = new StreamReader(@path);
        }

        public void SetPathToWrite(string path)
        {
            if (File.Exists(path).Equals(true))
            {
                writer = File.AppendText(@path);
            }
            else
            {
                writer = new StreamWriter(@path);
            }

        }
        public void SetPathToWrite()
        {
            if (File.Exists(this.path).Equals(true))
            {
                writer = File.AppendText(this.path);
            }
            else
            {
                writer = new StreamWriter(this.path);
            }

        }
        public void FlushInFile()
        {
            writer.Flush();
        }

        public void WriterInFile(string text)
        {
            writer.WriteLine(text);
        }

        public void CloseWriter()
        {
            writer.Close();
        }
        public string ReadFromFile()
        {

            return reader.ReadLine();
        }
        public void InitialRead()
        {
            reader = new StreamReader(this.path);
        }
        public void CloseReader()
        {
            reader.Close();
        }

    }
}
