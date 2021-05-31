using Models;

namespace Commons
{
    /// <summary>
    /// Implementation class for building a factory design pattern
    /// </summary>
    public class FriendFactory : AbstractFactory
    {
        /// <summary>
        /// Returns a friend based on the close factor
        /// </summary>
        /// <param name="IsClose">"close" if he/she is close or "not close"</param>
        /// <param name="data">the FriendEntity object</param>
        /// <returns>a new FriendEntity with the close factor filled</returns>
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
