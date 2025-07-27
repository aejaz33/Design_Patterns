namespace Interface_Segrigation_Principle
{
    /// <summary>
    /// This is to Demo interface segrigation principle where we break our interface into small interface to avoid unncessery implementaion of not requried methods.
    /// Example: Printer, which can Print, Scan, Fax the document. most of the might not need all of these functionalities hence we should break the interface.
    /// </summary>
    /// 

    public interface IPrinter
    {
        void Print();
    }

    public interface IScanner
    {
        void Scan();
    }

    public interface IFax
    {
        void Send();
    }

    public class Printer : IPrinter
    {
        public void Print()
        {
            Console.WriteLine("Printer is printing....");
        }
    }

    public class Fax : IScanner, IFax
    {
        public void Scan()
        {
            Console.WriteLine("Scanning the document....");
        }

        public void Send()
        {
            Console.WriteLine("Faxing the document....");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Fax fax = new Fax();
            fax.Scan();
            fax.Send();

            Printer printer = new Printer();
            printer.Print();
        }
    }
}
