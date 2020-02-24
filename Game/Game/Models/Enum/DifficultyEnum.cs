namespace Game.Models
{
    /// <summary>
    /// The Types of Difficultys
    /// Used by Item to specify what it modifies.
    /// </summary>
    public enum DifficultyEnum
    {
        // Not specified
        Unknown = 0,    

        // Easier than mostThe speed of the character, impacts movement, and initiative
        Easy = 10,

        // Average
        Average = 12,

        // Hard
        Hard = 14,

        // Harder than Hard
        Difficult = 16,

        // The highest value
        Impossible= 18,
    }

    /// <summary>
    /// Friendly strings for the Enum Class
    /// </summary>
    public static class DifficultyEnumExtensions
    {
        /// <summary>
        /// Display a String for the Enums
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToMessage(this DifficultyEnum value)
        {
            // Default String
            var Message = "Unknown";

            switch (value)
            {
                case DifficultyEnum.Easy:
                    Message = "Easy";
                    break;

                case DifficultyEnum.Average:
                    Message = "Average";
                    break;

                case DifficultyEnum.Hard:
                    Message = "Hard";
                    break;

                case DifficultyEnum.Difficult:
                    Message = "Harder than Hard";
                    break;

                case DifficultyEnum.Impossible:
                    Message = "Impossible";
                    break;

                case DifficultyEnum.Unknown:
                default:
                    break;
            }

            return Message;
        }
    }
}