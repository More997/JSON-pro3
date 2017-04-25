using System;
using System.Net;
using System.IO;

using Newtonsoft.Json.Linq;

namespace Ejer2
{
    class Program
    {
        static void Main(string[] args)
        {
            string pagina = "https://maps.googleapis.com/maps/api/geocode/json?address=";
            string ciudad = "";
            string dato = "";
            string pais = "";
            int i = -1;
            Console.WriteLine("Please, write a City");
        
            ciudad = Console.ReadLine();
            WebRequest req = WebRequest.Create(pagina + ciudad.ToLower());

            WebResponse respuesta = req.GetResponse();

            Stream stream = respuesta.GetResponseStream();

            StreamReader sr = new StreamReader(stream);
            JObject data = JObject.Parse(sr.ReadToEnd());
            while (dato != "country" && dato != "erroneo")
            {
                i++;
                try
                {
                   
                    dato = (string)data["results"][0]["address_components"][i]["types"][0]; 
                }
                catch (Exception Error)
                {
                    dato = "erroneo";
                }
            }
            if (dato != "erroneo")
            {
                pais = (string)data["results"][0]["address_components"][i]["long_name"];
                Console.WriteLine("That Belongs to " + pais);
            }
            else
            {
                Console.WriteLine("Oh oh I know, that belongs to Narnia!!!\n Haha no, we can't find it. \n Did you write it wrong? or Maybe there isn't internet!");
            }
            Console.ReadKey();
        }
        }

    }

