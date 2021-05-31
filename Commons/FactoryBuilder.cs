namespace Commons
{
    /// <summary>
    /// Class that returns a factory based on the argument provided
    /// </summary>
   public class FactoryBuilder
    {
        /// <summary>
        /// Method that returns a factory
        /// </summary>
        /// <param name="type">the factory's type</param>
        /// <returns>A FriendFactory or null</returns>
        public static AbstractFactory GetFactory(string type)
        {
            if (type.Equals("friend"))
                return new FriendFactory();
            return null;
        }
    }
}
