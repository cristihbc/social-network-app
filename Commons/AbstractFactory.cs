using System;
using System.Collections.Generic;
using System.Text;
using Models;
namespace Commons
{
    public abstract class AbstractFactory
    {
        public abstract FriendEntity GetFriend(string IsClose , FriendEntity data);
    }

}
