using System;
using System.Net;
using System.IO;

using Newtonsoft.Json.Linq;

namespace Ejercicio1
{
    class Program
    {
        static void Main(string[] args)
        {
            string pagina = "http://www.omdbapi.com/?t=";
            string pelicula = "";
            Console.WriteLine("Please, Write the title of a Movie");
            pelicula = Console.ReadLine();
            try
            {
                WebRequest req = WebRequest.Create(pagina + pelicula.ToLower());

                WebResponse respuesta = req.GetResponse();

                Stream stream = respuesta.GetResponseStream();

                StreamReader sr = new StreamReader(stream);
                JObject data = JObject.Parse(sr.ReadToEnd());
           
                 if (pelicula != "")
                {
                    Console.WriteLine("The movie was out in: ");
                    string anio = (string)data["Year"];
                    Console.WriteLine(anio);
                    Console.ReadKey();
                }
            }
            catch (WebException mistake)
            {
                Console.WriteLine("THERE IS NO INTERNET AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAH WE CAN'T WORK IN THAT MODE!!!");
                Console.ReadKey();
            }
        }

    }
}
