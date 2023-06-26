using System;

namespace MinotaurLabyrinth
{
    /// <summary>
    /// Represents a trouble room, which poses various challenges and obstacles for the hero.
    /// </summary>
    public class Trouble : Room
    {
        static Trouble()
        {
            RoomFactory.Instance.Register(RoomType.Trouble, () => new Trouble());
        }

        /// <inheritdoc/>
        public override RoomType Type { get; } = RoomType.Trouble;

        /// <inheritdoc/>
        public override bool IsActive { get; protected set; } = true;

        /// <summary>
        /// Activates the trouble room, presenting challenges to the hero.
        /// </summary>
        public override void Activate(Hero hero, Map map)
        {
            if (IsActive)
            {
                ConsoleHelper.WriteLine("As you enter the room, the door slams shut behind you, locking you inside.", ConsoleColor.Red);
                ConsoleHelper.WriteLine("Suddenly, a swarm of flying bats appears, obscuring your vision.", ConsoleColor.DarkGray);
                ConsoleHelper.WriteLine("You can hear their wings flapping and their screeches echoing in the room.", ConsoleColor.DarkGray);

                ConsoleHelper.WriteLine("Are you afraid? (yes/no): ", ConsoleColor.Red);
                string answer = Console.ReadLine()?.ToLower();

                if (answer == "yes")
                {
                    ConsoleHelper.WriteLine("Your fear overwhelms you, and you collapse to the ground.", ConsoleColor.DarkRed);
                    hero.Kill("You have died from fear.");
                }
                else
                {
                    ConsoleHelper.WriteLine("You steel yourself against fear and push forward with determination.", ConsoleColor.Green);

                    // Implement your own set of challenges or obstacles for the player here

                    IsActive = false; // Room is no longer active after the challenges are resolved
                }
            }
        }

        /// <inheritdoc/>
        public override DisplayDetails Display()
        {
            return IsActive ? new DisplayDetails($"[{Type.ToString()[0]}]", ConsoleColor.Red)
                            : base.Display();
        }

        /// <summary>
        /// Displays sensory information about the trouble room, based on the hero's distance from it.
        /// </summary>
        /// <param name="hero">The hero sensing the trouble room.</param>
        /// <param name="heroDistance">The distance between the hero and the trouble room.</param>
        /// <returns>Returns true if a message was displayed; otherwise, false.</returns>
        public override bool DisplaySense(Hero hero, int heroDistance)
        {
            if (!IsActive)
            {
                if (base.DisplaySense(hero, heroDistance))
                {
                    return true;
                }
                if (heroDistance == 0)
                {
                    ConsoleHelper.WriteLine("You recall the room filled with bats and the challenges you faced there.", ConsoleColor.DarkGray);
                    return true;
                }
            }
            else if (heroDistance == 1 || heroDistance == 2)
            {
                ConsoleHelper.WriteLine(heroDistance == 1 ? "You hear faint screeches. There might be trouble in a nearby room!" : "Your intuition warns you of imminent danger nearby.", ConsoleColor.DarkGray);
                return true;
            }
            return false;
        }
    }
}
