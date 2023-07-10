
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace LINQ_in_Manhattan
{

    class Program
    {
        static void Main(string[] args)
        {
            string fileData = File.ReadAllText("../../../data.json");

            Root data = JsonConvert.DeserializeObject<Root>(fileData);

            neighborhoods(data);
            Console.WriteLine("***********************************************************************************************");
            notHaveNames(data);
            Console.WriteLine("***********************************************************************************************");
            duplicates(data);
            Console.WriteLine("***********************************************************************************************");
            singleQuery(data);
            Console.WriteLine("***********************************************************************************************");
            opposingMethod(data);
        }

        public class Feature
        {
            public string type { get; set; }
            public Geometry geometry { get; set; }
            public Properties properties { get; set; }
        }

        public class Geometry
        {
            public string type { get; set; }
            public List<double> coordinates { get; set; }
        }

        public class Properties
        {
            public string zip { get; set; }
            public string city { get; set; }
            public string state { get; set; }
            public string address { get; set; }
            public string borough { get; set; }
            public string neighborhood { get; set; }
            public string county { get; set; }
        }

        public class Root
        {
            public string type { get; set; }
            public List<Feature> features { get; set; }
        }

        static void neighborhoods(Root FromJson) //Output all of the neighborhoods in this data list(Final Total: 147 neighborhoods)

        {
            Console.WriteLine("1- Output all of the neighborhoods in this data list(Final Total: 147 neighborhoods)");
            int count = 1;
            var query1 = from Feature in FromJson.features select Feature.properties.neighborhood;

            foreach (string neighborhood in query1)
            {
                if (neighborhood != null)
                {
                    Console.WriteLine(count + " . " + neighborhood);
                    count++;
                }

            }
        }

        static void notHaveNames(Root FromJson) //Filter out all the neighborhoods that do not have any names (Final Total: 143)

        {
            Console.WriteLine("2- Filter out all the neighborhoods that do not have any names (Final Total: 143)");
            int count = 1;
            var query2 = from Feature in FromJson.features where Feature.properties.neighborhood != "" select Feature.properties.neighborhood;

            foreach (string data2 in query2)
            {
                if (data2 != null)
                {
                    Console.WriteLine(count + " . " + data2);
                    count++;
                }

            }

        }

            static void duplicates(Root FromJson) //Remove the duplicates (Final Total: 39 neighborhoods)

            {
                Console.WriteLine("3- Remove the duplicates (Final Total: 39 neighborhoods)");
                int count = 1;
                var query3 = from Feature in FromJson.features where Feature.properties.neighborhood != "" select Feature.properties.neighborhood;

                var query3NotDuplicates = query3.Distinct();

                foreach (string data3 in query3NotDuplicates)
                {
                    if (data3 != null)
                    {
                        Console.WriteLine(count + " . " + data3);
                        count++;
                    }

                }
            }
        
        static void singleQuery(Root FromJson) //Rewrite the queries from above and consolidate all into one single query.

        {
            Console.WriteLine("4- Rewrite the queries from above and consolidate all into one single query.)");
            int count = 1;
            var query4 = (from Feature in FromJson.features where Feature.properties.neighborhood != "" select Feature.properties.neighborhood).Distinct();



            foreach (string data4 in query4)
            {
                if (data4 != null)
                {
                    Console.WriteLine(count + " . " + data4);
                    count++;
                }

            }
        }
        
        static void opposingMethod(Root FromJson) //Rewrite at least one of these questions only using the opposing method.

        {
            Console.WriteLine("5- Rewrite questions 4 only using the opposing method.)");
            int count = 1;
            var query5 = FromJson.features.Where(feature => feature.properties.neighborhood != "")
                .Select(feature => feature.properties.neighborhood).Distinct();
            

            foreach (string data5 in query5)
            {
                if (data5 != null)
                {
                    Console.WriteLine(count + " . " + data5);
                    count++;
                }

            }
        }
    }

}



