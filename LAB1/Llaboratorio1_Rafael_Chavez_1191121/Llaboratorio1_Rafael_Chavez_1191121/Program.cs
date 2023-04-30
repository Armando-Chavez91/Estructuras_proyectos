using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;
using System.Security.Cryptography.X509Certificates;

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
                // List<int> recommendations = GetApartmentRecommendations(map, requirements);

                // Imprimir las recomendaciones en la consola
                // Console.WriteLine(JsonConvert.SerializeObject(recommendations));
            }

            // Esperar a que el usuario presione cualquier tecla antes de salir
            Console.WriteLine("Presione cualquier tecla para salir...");
            Console.ReadKey();
        }
    }
}