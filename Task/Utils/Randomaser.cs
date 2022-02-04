using System;
using System.Collections.Generic;
using System.Text;

namespace Task.Utils
{
    public static class Randomaser
    {
        public static string RandomString(int length = 10)
        {
            string randomString = string.Empty;
            Random rnd = new Random();
            List<char> listWithAlph = new List<char>();
            for (char i = 'A'; i <= 'Z'; i++)
            {
                listWithAlph.Add(i);
            }
            while (randomString.Length < length)
            {
                int rndInt = rnd.Next(0, 10);
                randomString += listWithAlph[rndInt];
            }
            return randomString;
        }

        public static int RandomInt(int maxValue)
        {
            return new Random().Next(0, maxValue);
        }
    }
}
