//using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAb02
{
    class Test
    {

        private static string _path = @"D:\Universidad Rafael Landìvar\6to Ciclo 2023\Estructura de Datos I\LAb3\input_auctions_example_lab_3.json";
        private static string _path2 = @"D:\Universidad Rafael Landìvar\6to Ciclo 2023\Estructura de Datos I\LAb3\input_customer_example_lab_3.json";

        public static string GetUsuarios()
        {

            string usu;
            using (var reader = new StreamReader(_path))
            {
                usu = reader.ReadToEnd();

            }

            return usu;
        }

        public static string GetUsuarios2()
        {

            string usu;
            using (var reader = new StreamReader(_path2))
            {
                usu = reader.ReadToEnd();

            }

            return usu;
        }
        static void Main(string[] args)
        {
            int contador = 0;
            int con = 0;
            int i = 0;

            string[] arreglo = new string[1000];
            string[] arreglo2 = new string[1000];
            int conT = 0;
            int conP = 1;
            Console.Title = "LAB 3 MÓNICA ORTÍZ";

            string[] informacion1 = { };
            string[] informacionP3 = { };
            string[] informacionP2 = { };
            string[] separI22 = { };
            string[] Cadena2 = new string[1000];
            var saveCadena = "";
            int[] ndata = new int[1000];
            int dataf = 0;
            int max = ndata[0];
            var dpi = "";
            var gdpi = "";
            var Sdpi = "";
            string key = "";

            Console.WriteLine("----------------------------------------------------------------------");
            if (GetUsuarios() != null && contador == con)
            {
                try
                {
                    string allFileData = File.ReadAllText(_path);
                    foreach (string lineaActual in allFileData.Split('\n'))
                    {
                        if (!string.IsNullOrEmpty(lineaActual) && contador == con)
                        {
                            conT = 0;
                            string[] informacion = lineaActual.Split("customers");
                            var u = (informacion[1]);
                            informacion1 = u.Split('{');
                            var comp1 = informacion1[1];
                        }
                    }
                }
                catch (Exception ex)
                {

                    Console.WriteLine("Error" + ex);
                }
            }
            if (GetUsuarios2() != null && contador == con)
            {
                try
                {
                    string allFileData = File.ReadAllText(_path2);
                    foreach (string lineaActual in allFileData.Split('\n'))
                    {
                        if (!string.IsNullOrEmpty(lineaActual) && contador == con)
                        {
                            conT = 0;
                            string[] informacion = lineaActual.Split("{");
                            if (informacion[1].Contains(Sdpi.ToString()))
                            {
                                Random signature = new Random();
                                for (int r = 0; r < 10; r++)
                                {
                                    int n = signature.Next(0, 10);
                                    key += n.ToString();
                                }
                                Console.WriteLine("Usuario: " + informacion[1]);
                                Console.WriteLine("Signature: " + key);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error" + ex);
                }
            }
        }
    } } 
