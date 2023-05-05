using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO.Enumeration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TBNetBataille.Cartes;
using static System.Net.Mime.MediaTypeNames;

namespace TBNetBataille.Tools
{
    static class Log
    {
        const string FILENAME = "result.txt";

        static Log()
        {
            File.CreateText(FILENAME).Dispose();
        }

        public static void Display(Carte carteJ1, Carte carteJ2)
        {
            string text = $"{carteJ1} vs {carteJ2}\n";
            Console.Write(text);
            File.AppendAllText(FILENAME, text);
        }

        public static void Display(string message)
        {
            Console.WriteLine(message);
            File.AppendAllText(FILENAME, message + "\n");
        }
    }
}
