using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DersYönetimSistemi.Utilities.Common
{
   public class RandomValueGenerator
    {

        public static string GetRandomValue(string uzanti)
        {
            return Guid.NewGuid().ToString().Replace("-", "").Substring(0, 12) +"_"+ DateTime.Now.Ticks+uzanti;
        }
    }
}
