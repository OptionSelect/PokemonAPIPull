using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;

namespace PokemonAPIPull
{
    class Program
    {
        static void Main(string[] args)
        {
            var url = "http://pokeapi.co/api/v2/pokemon-form/58/";
            var request = WebRequest.Create(url);
            var response = request.GetResponse();
            var rawResponse = String.Empty;

            using (var reader = new StreamReader(response.GetResponseStream()))
            {
                rawResponse = reader.ReadToEnd();
            }

            var growlithe = JsonConvert.DeserializeObject<pokemon>(rawResponse);

            Console.WriteLine(growlithe.name);
            Console.WriteLine(growlithe.id);
            Console.WriteLine(growlithe.base_experience);
            Console.WriteLine(growlithe.height);
        }
    }
}
