using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Diagnostics;

namespace SingleResponsibility
{
    public class Journal
    {
        public List<string> journal = new List<string>();
        int count = 0;

        public void AddEntry(string text)
        {
            journal.Add($"{++count}: {text}");
        }

        public void RemoveEntry(int index) { journal.RemoveAt(index); }

        public override string ToString()
        {
            return string.Join(Environment.NewLine, journal);
        }
    }

    public class Persistance
    {
        public void SaveToFile(string fileName, Journal journal, bool overwrite = false)
        {
            if (overwrite || File.Exists(fileName))
                File.WriteAllText(fileName, journal.ToString());
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Journal journal = new Journal();
            journal.AddEntry("Going Single Responsiblity principle");
            journal.AddEntry("Will go through Open Closed Principle");

            Console.WriteLine(journal.ToString());

            var p = new Persistance();
            string filename = @"c:\temp\journal.txt";
            p.SaveToFile(filename, journal, true);
        }
    }
}
