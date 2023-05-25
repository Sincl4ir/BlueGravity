namespace BlueGravity.Tapestry
{
    public class TapestryEventRegistry
    {

        #region Player
        /// <summary>
        /// Reports Player death
        /// </summary>
        //public static TapestryEvent<Entity> OnPlayerDeathTE;
        #endregion
      
        static TapestryEventRegistry()
        {
            CreateTapestryEvents();
        }

        private static void CreateTapestryEvents()
        {
            #region Player
            //OnPlayerDeathTE = new TapestryEvent<Entity>();
            #endregion

        }

        public static void OnDestroy()
        {
            // Creates new events to clear the old ones
            CreateTapestryEvents();
        }
    }
}
//EOF.