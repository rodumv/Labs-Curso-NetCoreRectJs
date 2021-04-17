using System;
using Newtonsoft.Json;
namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
	    Console.WriteLine(JsonConvert.SerializeObject(args));
        }
    }
}
