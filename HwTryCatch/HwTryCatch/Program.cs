﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace HwTryCatch
{
    class Program
    {
        static void Main(string[] args)
        {
            /*1.	Перехватить исключение запроса к несуществующему веб ресурсу
              и вывести сообщение о том, что произошла ошибка. 
              Программа должна завершиться без ошибок.*/

            try
            {
                string url = "http:\\pustota1.com";
                string temp = Get(url);
            }
            catch (Exception)
            {
                Console.WriteLine("404 Ресурс не обнаружен!!!");
            }
            Console.ReadLine();
        }

        public static string Get(string uri)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                return reader.ReadToEnd();
            }
        }
    }
}