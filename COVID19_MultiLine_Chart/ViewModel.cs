using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;

namespace COVID19_MultiLine_Chart
{
    public class ViewModel
    {
        private List<JoblessCategory> unemployedData = new List<JoblessCategory>();
        private JoblessCategory? model;

        public List<JoblessCategory> UnemploymentData { get; set; }
        public ViewModel()
        {
            UnemploymentData = new List<JoblessCategory>(ReadCSV("COVID19_MultiLine_Chart.bls_table.csv"));
        }

        public IEnumerable<JoblessCategory> ReadCSV(string fileName)
        {
            Assembly executingAssembly = typeof(App).GetTypeInfo().Assembly;
            Stream inputStream = executingAssembly.GetManifestResourceStream(fileName);
            if (inputStream != null)
            {

                string line;
                List<string> lines = new List<string>();
                StreamReader reader = new StreamReader(inputStream);
                while ((line = reader.ReadLine()) != null)
                {
                    lines.Add(line);
                }

                lines.RemoveAt(0);

                for (int i = 0; i < lines.Count; i++)
                {
                    string input = lines[i];
                    if (input.EndsWith(","))
                        input = input.TrimEnd(',');

                    // Split by comma, excluding the ones inside quotes
                    string[] data = input.Split(new[] { "\",\"" }, StringSplitOptions.None);

                    // Remove leading and trailing quotes from each part
                    for (int j = 0; j < data.Length; j++)
                    {
                        data[j] = data[j].Trim('\"');
                    }

                    DateTime resultDate = DateTime.ParseExact(data[0], "MMM yyyy", CultureInfo.InvariantCulture);
                    model = new JoblessCategory(resultDate, Convert.ToDouble(data[1]), Convert.ToDouble(data[2]), Convert.ToDouble(data[3]), Convert.ToDouble(data[4]), Convert.ToDouble(data[5]), Convert.ToDouble(data[6]));
                    unemployedData.Add(model);
                }
            }

            return unemployedData;
        }
    }
}
