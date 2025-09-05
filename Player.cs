namespace MafiaGame
{
    public class Player
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty; // запобігає попередженню CS8618
        public string Role { get; set; }
        public bool State { get; set; }
    }
}
