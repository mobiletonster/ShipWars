namespace ShipGame;

public class Game
{
    public List<Player> Players { get; set; } = new List<Player>();
    public Game()
    {

    }

    public void AddPlayer(Player player)
    {
        if (Players.Count < 2)
        {
            Players.Add(player);
        }
        else
        {
            throw new Exception("Game is already full");
        }
    }

    public (bool IsHit, bool IsSunk) FireOnLocation(Player player, int x, int y)
    {
        var self = new List<Player>();
        self.Add(player);

        var opponentBoard = Players.Except(self).First().Board; // should throw exception if there is no opponent
        return opponentBoard.CheckHit(x, y);
    }
}
