namespace ShipGame;

public class BoardLocation
{
    public BoardLocation(Ship ship)
    {
        ShipNumber = ship.ShipNumber;
        IsLocationOccupied = true;
    }
    public BoardLocation()
    {
        ShipNumber = 0;
        IsLocationOccupied = false;
    }
    public int ShipNumber { get; private set; }
    public bool IsLocationOccupied { get; private set; }
    public bool IsLocationFiredUpon { get; set; }        
}
