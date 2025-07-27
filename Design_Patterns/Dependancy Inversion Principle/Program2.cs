using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dependancy_Inversion_Principle
{
    /// <summary>
    /// This is the Demo for Dependancy Inversion Principle which says high level class must not depend on low level class
    /// Example: ILogger has different flavors of implementation it can have more flavors and DatabaseLogger does not changes becuase of change different loggings.
    /// </summary>
    public interface ILogger
    {
        void Log(string message);
    }

    public class FileLogger : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine($"Log: Saved {message} in the file...");
        }
    }

    public class DatabaseLogger : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine($"Log: Saved {message} in the database...");
        }
    }
    internal class DataBaseLayer
    {
        private ILogger logger;
        public DataBaseLayer(ILogger logger)
        {
            this.logger = logger;
        }

        public void AddStudent(string name)
        {
            Console.WriteLine($"Saved {name} in the database");
            logger.Log(name);
        }
    }
    public class Program1
    {
        public static void Main(string[] args)
        {
            ILogger logger1 = new FileLogger();
            ILogger logger2 = new DatabaseLogger();

            var dac1 = new DataBaseLayer(logger1);
            var dac2 = new DataBaseLayer(logger2);

            dac1.AddStudent("Student1");
            dac2.AddStudent("Student2");
        }
    }
}
