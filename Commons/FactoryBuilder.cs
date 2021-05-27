using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commons
{
   public class FactoryBuilder
    {
        public static AbstractFactory GetFactory(string type)
        {
            if (type.Equals("friend"))
                return new FriendFactory();
            return null;
        }
    }
}
