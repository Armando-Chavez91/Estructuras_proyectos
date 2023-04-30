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

            // Dividir el archivo por cada objeto JSON
            string[] inputObjects = inputString.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            // Procesar cada objeto JSON
            foreach (string obj in inputObjects)
            {
                // Deserializar el objeto JSON
                dynamic data = JsonConvert.DeserializeObject(obj);

                // Obtener los valores de input1 e input2
                List<Dictionary<string, bool>> map = data.input1.ToObject<List<Dictionary<string, bool>>>();
                List<string> requirements = data.input2.ToObject<List<string>>();

                // Procesar la información y obtener las recomendaciones de apartamentos
                List<int> recommendations = GetApartmentRecommendations(map, requirements);

                // Imprimir las recomendaciones en la consola
                Console.WriteLine(JsonConvert.SerializeObject(recommendations));
            }

            // Esperar a que el usuario presione cualquier tecla antes de salir
            Console.WriteLine("Presione cualquier tecla para salir...");
            Console.ReadKey();
        }

        // Función que obtiene las recomendaciones de apartamentos de acuerdo con los requerimientos del cliente
        static List<int> GetApartmentRecommendations(List<Dictionary<string, bool>> map, List<string> requirements)
        {
            List<int> recommendations = new List<int>();
            List<int> distances = new List<int>();

            // Recorre cada apartamento en el mapa
            for (int i = 0; i < map.Count; i++)
            {
                Dictionary<string, bool> apartment = map[i];
                bool meetsRequirements = true;

                // Verifica si el apartamento cumple con los requerimientos del cliente
                foreach (string requirement in requirements)
                {
                    if (!apartment.ContainsKey(requirement) || !apartment[requirement])
                    {
                        meetsRequirements = false;
                        break;
                    }
                }

                // Si el apartamento cumple con los requerimientos, se calcula la distancia
                // y se agrega a la lista de recomendaciones
                if (meetsRequirements)
                {
                    int distance = i; // Distancia es igual al índice del apartamento
                    distances.Add(distance);
                }
            }

            // Ordena la lista de recomendaciones por distancia y las agrega a la lista de recomendaciones
            distances.Sort();
            foreach (int distance in distances)
            {
                recommendations.Add(distance);
            }

            return recommendations;
        }
    }
}


