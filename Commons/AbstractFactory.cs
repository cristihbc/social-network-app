using Models;

namespace Commons
{
    /// <summary>
    /// Abstract class for building a factory design pattern
    /// </summary>
    public abstract class AbstractFactory
    {
        /// <summary>
        /// Returns a friend based on the close factor
        /// </summary>
        /// <param name="IsClose">"close" if he/she is close or "not close"</param>
        /// <param name="data">the FriendEntity object</param>
        /// <returns>a new FriendEntity with the close factor filled</returns>
        public abstract FriendEntity GetFriend(string IsClose , FriendEntity data);
    }

}
