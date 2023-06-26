namespace MinotaurLabyrinth
{
    /// <summary>
    /// Represents the player in the game.
    /// </summary>
    public class Hero
    {
        private const int MaxHealth = 100;

        /// <summary>
        /// Creates a new player that starts at the given location.
        /// </summary>
        /// <param name="start">The starting location of the player.</param>
        public Hero(Location start)
        {
            Location = start;
            Health = MaxHealth;
        }

        /// <summary>
        /// Contains all the commands that a player can access.
        /// </summary>
        public CommandList CommandList { get; } = new CommandList();

        /// <summary>
        /// Represents the distance the player can sense danger.
        /// Diagonally adjacent squares have a range of 2 from the player.
        /// </summary>
        public int SenseRange { get; } = 1;

        /// <summary>
        /// The player's current location.
        /// </summary>
        public Location Location { get; set; }

        /// <summary>
        /// Indicates whether the player is alive or not.
        /// </summary>
        public bool IsAlive { get; private set; } = true;

        /// <summary>
        /// Indicates whether the player has won the game or not.
        /// </summary>
        public bool IsVictorious { get; set; }

        /// <summary>
        /// Indicates whether the player currently has the catacomb map.
        /// </summary>
        public bool HasMap { get; set; } = true;

        /// <summary>
        /// Indicates whether the player currently has the sword.
        /// </summary>
        public bool HasSword { get; set; }

        /// <summary>
        /// Explains why a player died.
        /// </summary>
        public string CauseOfDeath { get; private set; } = "";

        /// <summary>
        /// The current health of the player.
        /// </summary>
        public int Health { get; private set; }

        /// <summary>
        /// Adds the specified amount of health to the player.
        /// </summary>
        /// <param name="amount">The amount of health to add.</param>
        public void AddHealth(int amount)
        {
            Health += amount;
            if (Health > MaxHealth)
            {
                Health = MaxHealth;
            }
        }

        /// <summary>
        /// Removes the specified amount of health from the player.
        /// </summary>
        /// <param name="amount">The amount of health to remove.</param>
        public void RemoveHealth(int amount)
        {
            Health -= amount;
            if (Health <= 0)
            {
                Health = 0;
                Kill("Health depleted");
            }
        }

        /// <summary>
        /// Retrieves the current health of the player.
        /// </summary>
        /// <returns>The current health of the player.</returns>
        public int GetHealth()
        {
            return Health;
        }

        /// <summary>
        /// Kills the player with the specified cause of death.
        /// </summary>
        /// <param name="cause">The cause of death.</param>
        public void Kill(string cause)
        {
            IsAlive = false;
            CauseOfDeath = cause;
        }
    }
}
