using System;
using System.IO;
 
namespace Lesson
{
    class Program
    {
        static void Main(string[] args)
        {
 
        }
    }

    interface  ILogger
    {
        public void WriteConsoleLog(string message)
        {
            Console.WriteLine(message);
        }
        public void WriteFileLog(string message)
        {
            File.WriteAllText("log.txt", message);
        }
    }

    class Pathfinder
    {
        private ILogger _iLogger;
        
        public void Find(string message)
        {
            _iLogger.WriteConsoleLog(message);
        }

        public void FindFile(string message)
        {
            _iLogger.WriteFileLog(message);
        }

        public bool isFriday()
        {
            return DateTime.Now.DayOfWeek == DayOfWeek.Friday;
        }

        public string GetMassage()
        {
            return Console.ReadLine();
        }
    }

    class FileLog : Pathfinder
    {
        private void CreateLog()
        {
            FindFile(GetMassage());
        }
    }

    class ConsoleLog : Pathfinder
    {
        private void CreateLog()
        {
           Find(GetMassage());
        }
    }

    class FileLogFriday : Pathfinder
    {
        private void CreateLog()
        {
            if (isFriday())
            {
                FindFile(GetMassage());
            }
        }
    }
    
    class ConsoleLogFriday : Pathfinder
    {
        private void CreateLog()
        {
            if (isFriday())
            {
                Find(GetMassage());
            }
        }
    }
    
    class ConsoleFileLogFriday : Pathfinder
    {
        public void CreateLog()
        {
            if (isFriday())
            {
                FindFile(GetMassage());
            }
            Find(GetMassage());
        }
    }
}