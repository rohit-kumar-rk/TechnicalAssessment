using Newtonsoft.Json;
using System;
using System.Text;

namespace GeneralKnowledge.Test.App.Tests
{
    /// <summary>
    /// Basic data retrieval from JSON test
    /// </summary>
    public class JsonReadingTest : ITest
    {

        public class Rootobject
        {
            public Sample[] samples { get; set; }
        }

        public class Sample
        {
            public DateTime date { get; set; }
            public float temperature { get; set; }
            public int pH { get; set; }
            public int phosphate { get; set; }
            public int chloride { get; set; }
            public int nitrate { get; set; }
        }

        public string Name { get { return "JSON Reading Test"; } }

        public void Run()
        {
            var jsonData = Resources.SamplePoints;

            // TODO: 
            // Determine for each parameter stored in the variable below, the average value, lowest and highest number.
            // Example output
            // parameter   LOW AVG MAX
            // temperature   x   y   z
            // pH            x   y   z
            // Chloride      x   y   z
            // Phosphate     x   y   z
            // Nitrate       x   y   z

            PrintOverview(jsonData);
        }

        private void PrintOverview(byte[] data)
        {
            var jsonData = JsonConvert.DeserializeObject<Rootobject>(Encoding.UTF8.GetString(data));
            float minTemp = 0;
            float maxTemp = 0;
            int minPh = 0; int minChloride = 0; int minPhosphate = 0; int minNitrate = 0;
            int maxPh = 0; int maxChloride = 0; int maxPhosphate = 0; int maxNitrate = 0;
            for (int i = 0; i < jsonData.samples.Length; i++)
            {
                minPh = maxPh = jsonData.samples[0].pH;
                minTemp = maxTemp = jsonData.samples[0].temperature;
                minPhosphate = maxPhosphate = jsonData.samples[0].phosphate;
                minChloride = maxChloride = jsonData.samples[0].chloride;
                minNitrate = maxNitrate = jsonData.samples[0].nitrate;

                if (minTemp > jsonData.samples[i].temperature)
                {
                    minTemp = jsonData.samples[i].temperature;
                }
                else if (jsonData.samples[i].temperature > maxTemp)
                {
                    maxTemp = jsonData.samples[i].temperature;
                }

                if (minPh > jsonData.samples[i].pH)
                {
                    minPh = jsonData.samples[i].pH;
                }
                else if (jsonData.samples[i].pH > maxPh)
                {
                    maxPh = jsonData.samples[i].pH;
                }

                if (minPhosphate > jsonData.samples[i].phosphate)
                {
                    minPhosphate = jsonData.samples[i].phosphate;
                }
                else if (jsonData.samples[i].phosphate > maxPhosphate)
                {
                    maxPhosphate = jsonData.samples[i].phosphate;
                }

                if (minChloride > jsonData.samples[i].chloride)
                {
                    minChloride = jsonData.samples[i].chloride;
                }
                else if (jsonData.samples[i].chloride > maxChloride)
                {
                    maxChloride = jsonData.samples[i].chloride;
                }

                if (minNitrate > jsonData.samples[i].nitrate)
                {
                    minNitrate = jsonData.samples[i].nitrate;
                }
                else if (jsonData.samples[i].nitrate > maxNitrate)
                {
                    maxNitrate = jsonData.samples[i].nitrate;
                }
            }
            Console.WriteLine("-------------------------------------------");
            Console.WriteLine(Name);
            Console.WriteLine("\nParameter    LOW        AVG          MAX");
            Console.WriteLine("===========================================");
            Console.WriteLine($"Temperature  {minTemp}        {(minTemp + maxTemp) / 2}          {maxTemp}");
            Console.WriteLine($"pH           {minPh}          {(minPh + maxPh) / 2}             {maxPh}");
            Console.WriteLine($"Chloride     {minChloride}          {(minChloride + maxChloride) / 2}             {maxChloride}");
            Console.WriteLine($"Phosphate    {minPhosphate}          {(minPhosphate + maxPhosphate) / 2}             {maxPhosphate}");
            Console.WriteLine($"Nitrate      {minNitrate}         {(minNitrate + maxNitrate) / 2}            {maxNitrate}");
        }
    }
}