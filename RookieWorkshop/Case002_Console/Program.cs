using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;
using System.Net;
using ConsoleApp.Model;
using System.Collections.Generic;
using System.IO;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Write("input: ");
                string input = Console.ReadLine();

                if (input == "0") break;

                string result = CallGetDataApi(input);
                Console.WriteLine($"output: {result}\n");
            }
        }
        public static IEnumerable<User> CallUserApi()
        {
            WebRequest request = WebRequest.Create("https://localhost:5001/api/user");
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            StreamReader reader = new StreamReader(response.GetResponseStream());
            string data = reader.ReadToEnd();

            return JsonSerializer.Deserialize<IEnumerable<User>>(data);
        }
        public static void PrintUser(IEnumerable<User> userList)
        {
            foreach (var user in userList)
            {
                Console.WriteLine($"Id:{user.Id}, Name:{user.Name}, Age:{user.Age}");
            }
        }
        public static string CallGetDataApi(string input)
        {
            WebRequest request = WebRequest.Create("https://localhost:5001/api/getDataAndSave/" + input);

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            StreamReader reader = new StreamReader(response.GetResponseStream());
            string data = reader.ReadToEnd();

            return data;
        }
    }
}
