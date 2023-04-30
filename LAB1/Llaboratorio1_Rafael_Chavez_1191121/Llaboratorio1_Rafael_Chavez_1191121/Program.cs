using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;

namespace InmueblesGT
{
    class Program
    {
        static void Main(string[] args)
        {
            // Leer el archivo .jsonl en la carpeta del proyecto

            string _path = @"D:\Universidad Rafael Landìvar\6to Ciclo 2023\Estructura de Datos I\LABORATORIO 1\labED_1\input_challenge.jsonl";
            string inputString;
            using (var reader = new StreamReader(_path))
            {
                inputString = reader.ReadToEnd();
            }

            string[] inputObjects = inputString.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string obj in inputObjects)
            {
                dynamic data = JsonConvert.DeserializeObject(obj);

                List<Dictionary<string, bool>> map = data.input1.ToObject<List<Dictionary<string, bool>>>();
                List<string> requirements = data.input2.ToObject<List<string>>();

                List<int> recommendations = GetApartmentRecommendations(map, requirements);

                Console.WriteLine(JsonConvert.SerializeObject(recommendations));
            }

            Console.WriteLine("Presione cualquier tecla para salir...");
            Console.ReadKey();
        }

        static List<int> GetApartmentRecommendations(List<Dictionary<string, bool>> map, List<string> requirements)
        {
            List<int> recommendations = new List<int>();
            List<int> distances = new List<int>();

     for (int i = 0; i < map.Count; i++)
            {
                Dictionary<string, bool> apartment = map[i];
                bool meetsRequirements = true;

                foreach (string requirement in requirements)
                {
                    if (!apartment.ContainsKey(requirement) || !apartment[requirement])
                    {
                        meetsRequirements = false;
                        break;
                    }
                }

                if (meetsRequirements)
                {
                    int distance = i; // Distancia es igual al índice del apartamento
                    distances.Add(distance);
                }
            }

           distances.Sort();
            foreach (int distance in distances)
            {
                recommendations.Add(distance);
            }

            return recommendations;
        }
    }
}


