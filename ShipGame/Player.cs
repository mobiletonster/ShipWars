namespace ShipGame;

public class Player
{
    public Player(string name)
    {
        Name = name;
    }
    public string Name { get; private set; }
    public Board Board { get; set; } = new Board();

}
