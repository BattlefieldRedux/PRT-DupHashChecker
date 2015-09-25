using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace HashChecker
{
    class Program
    {
        static void Main(string[] args)
        {


            if (args.Length != 2)
            {
                Console.WriteLine("Wrong usage...");
                Console.WriteLine(" >HashChecker.exe <server.log> <global.log>");
                Console.WriteLine(" <server.log> is the path to the file with the hashes that we want to verify");
                Console.WriteLine(" <global.log> is the path to the file with every hash");
                return;
            }

            Dictionary<string, List<LogEntry>> logDups = new Dictionary<string, List<LogEntry>>();

            for (int arg = 0; arg < args.Length; arg++)
            {

                try
                {   // Open the text file using a stream reader.
                    using (StreamReader sr = new StreamReader(args[arg]))
                    {
                        String line;

                        while (!String.IsNullOrEmpty(line = sr.ReadLine()))
                        {
                            LogEntry entry = LogEntry.parse(line);

                            //Only the second file will be used to compare the duplicates
                            if (arg == 1 && logDups.ContainsKey(entry.Hash))
                            {
                                bool diff = true;
                                foreach (LogEntry regEntry in logDups[entry.Hash])
                                {
                                    diff = regEntry.Equals(entry) ? false : diff;
                                }

                                if (diff)
                                    logDups[entry.Hash].Add(entry);
                            }
                            //Only the first file will be used to populate the database
                            else if (arg == 0)
                            {
                                List<LogEntry> list = new List<LogEntry>();
                                list.Add(entry);
                                logDups.Add(entry.Hash, list);
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("The file could not be read:");
                    Console.WriteLine(e.Message);
                }
            }//End For

            foreach (KeyValuePair<string, List<LogEntry>> pair in logDups)
            {

                if (pair.Value.Count > 1)
                {
                    Console.WriteLine("======= HASH: " + pair.Key);
                    foreach (LogEntry entry in pair.Value)
                    {
                        Console.WriteLine(String.Format(">{0} from {1}", entry.Nick, entry.IPAddress));
                    }

                }
            }//End ForEach
        }
    }
}
