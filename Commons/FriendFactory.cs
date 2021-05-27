using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commons
{
    public class FriendFactory : AbstractFactory
    {
        public override FriendEntity GetFriend(string IsClose , FriendEntity data)
        {
            bool check = false;
            if(IsClose.Equals("close"))
            {
                check = true;
            }
            return new FriendEntity { IsClose = check , Username = data.Username };

        }
    }
}
