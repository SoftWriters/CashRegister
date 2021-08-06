using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace CashRegister
{
    public class WriteService : IWriteService
    {
        private static string FileName { get; } = "output.txt";
        private static readonly string WorkingDirectory = Directory.GetParent(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName).Parent.FullName;

        private readonly string FilePath = Path.Combine(WorkingDirectory, FileName);

        public void WriteFile(List<Change> changeList)
        {
            try
            {
                using(StreamWriter streamWriter = new StreamWriter(FilePath, true))
                {
                    foreach(Change change in changeList)
                    {
                        string message = CreateChangeMessage(change);
                        streamWriter.WriteLine(message);
                    }
                    
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private string CreateChangeMessage(Change change)
        {
            string message = "";
            if(change.Dollar > 0)
            {
                message += change.Dollar + " dollar";
                if(change.Dollar != 1)
                {
                    message += "s";
                }
            }

            if(change.Quarter > 0)
            {
                if (message.Length != 0)
                {
                    message += ", ";
                }
                message += change.Quarter + " quarter";
                if(change.Quarter != 1)
                {
                    message += "s";
                }
            }

            if(change.Dime > 0)
            {
                if (message.Length != 0)
                {
                    message += ", ";
                }
                message += change.Dime + " dime";

                if(change.Dime != 1)
                {
                    message += "s";
                }
            }

            if(change.Nickel > 0)
            {
                if (message.Length != 0)
                {
                    message += ", ";
                }
                message += change.Nickel + " nickel";

                if (change.Nickel != 1)
                {
                    message += "s";
                }
            }

            if(change.Penny > 0)
            {
                if (message.Length != 0)
                {
                    message += ", ";
                }
                message += change.Penny + " penn";
                if(change.Penny != 1)
                {
                    message += "ies";
                } else
                {
                    message += "y";
                }
            }

            return message;
        }
    }

    
}
