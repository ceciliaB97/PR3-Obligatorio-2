using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Auxiliar
{
    public static class CSVHelper
    {
        //protected static string csv = string.Empty;
        //protected static string separator = ",";

        public static List<string[]> ParseCSV(string csv, char separator = ',')
        {
            List<string[]> result = new List<string[]>();

            
            //Regex.Split(csv, System.Environment.NewLine).ToList().Where(s => !string.IsNullOrEmpty(s))
            foreach (string line in csv.Split(new char[] { '\r','\n'},StringSplitOptions.RemoveEmptyEntries))
            {
                string[] values = line.Split(new char[] { separator });
                    //Regex.Split(line, separator);

                for (int i = 0; i < values.Length; i++)
                {
                    //Trim values
                    values[i] = values[i].Trim('\"');
                }

                result.Add(values);
            }

            return result;
        }
    }
}
