namespace NativeAppsII_Windows_Groep18.Model
{
    /// <summary>
    /// Represents a chore.
    /// </summary>
    public class Chore
    {
        #region Properties
        /// <summary>
        /// Gets or sets the chore's id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the chore's name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets a value indicating wether the chore is completed.
        /// </summary>
        public bool Completed { get; set; }
        #endregion

        #region Constructors
        /// <summary>
        /// Creates a new chore.
        /// </summary>
        public Chore() { }
        #endregion
    }
}
