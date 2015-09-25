using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace HashChecker
{
    class LogEntry
    {
        public DateTime Date { get; private set; }
        public string Hash { get; private set; }
        public string Tag { get; private set; }
        public string Nick { get; private set; }
        public IPAddress IPAddress { get; private set; }

        public override bool Equals(Object obj)
        {
            if (obj == null)
                return false;

            LogEntry other = obj as LogEntry;

            if (other == null)
                return false;

            return this.Nick.Equals(other.Nick) && this.Hash.Equals(other.Hash);
        }
        public override int GetHashCode()
        {
            return this.Hash.GetHashCode();
        }



        //[<date|yyyy-MM-dd> <hour|HH:mm:ss>] <string> <string|optional> <string> <ip>
        public static LogEntry parse(string line)
        {
            LogEntry logEntry = new LogEntry();
            string[] tokens = line.Split(' ');
            tokens[0] += ' ' + tokens[1];

            logEntry.Date = DateTime.ParseExact(tokens[0], "[yyyy-MM-dd HH:mm:ss]", CultureInfo.InvariantCulture);

            int field = 2;
            logEntry.Hash = tokens[field++];

            if (tokens.Length == 6)
            {
                logEntry.Tag = tokens[field++];
            }

            logEntry.Nick = tokens[field++];

            logEntry.IPAddress = IPAddress.Parse(tokens[field++]);

            return logEntry;
        }



    }
}
