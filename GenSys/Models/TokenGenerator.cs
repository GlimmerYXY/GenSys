using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspDotNetMVCBootstrapTable.Models
{
    public class TokenGenerator
    {
        public String GetFourRandom()
        {
            Random random = new Random();
            String fourRandom = random.Next(10000) + "";
            int randLength = fourRandom.Length;
            if (randLength < 4)
            {
                for (int i = 1; i <= 4 - randLength; i++)
                {
                    fourRandom = "0" + fourRandom;
                }

            }
            return fourRandom;
        }
        public String NewToken()
        {
            String token = null;
            token = GetFourRandom() + "-" + GetFourRandom() + "-" + GetFourRandom() + "-" + GetFourRandom()
                    + "-" + GetFourRandom() + "-" + GetFourRandom() + "-" + GetFourRandom() + "-" + GetFourRandom();
            return token;
        }
    }
}