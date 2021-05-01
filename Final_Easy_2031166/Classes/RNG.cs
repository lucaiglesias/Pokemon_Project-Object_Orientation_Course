using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Easy_2031166.Classes
{
    //Singleton Design Pattern
    public class RNG : Random
    {
        private static RNG instance = null;
        private RNG() : base() { }

        public static RNG GetInstance()
        {
            if (instance == null)
            {
                instance = new RNG();
            }
            return instance;
        }
    }
}
