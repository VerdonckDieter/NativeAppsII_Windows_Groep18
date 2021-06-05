namespace Travel_list_API.Models
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

        /// <summary>
        /// Creates a new chore.
        /// </summary>
        /// <param name="name">The chore's name</param>
        /// <param name="completed">Wether the chore is completed</param>
        public Chore(string name, bool completed)
        {
            Name = name;
            Completed = completed;
        } 
        #endregion
    }
}
