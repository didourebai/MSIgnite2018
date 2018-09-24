using System;

namespace TravelGuideTunisia.Business.Helpers
{
    public static class RandomCodeGeneration
    {
        //Function to get random number
        private static readonly Random getrandom = new Random();
        private static readonly object syncLock = new object();

        public static string RandomDigits(int length)
        {
            lock (syncLock)
            { // 
                string s = string.Empty;
                for (int i = 0; i < length; i++)
                    s = String.Concat(s, getrandom.Next(10).ToString());
                return s;
            }
        }

    }
}