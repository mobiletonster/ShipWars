namespace ShipGame;

public class Ship
{
    public Ship(int size, int shipNumber)
    {
        Size = size;
        ShipNumber = shipNumber;
    }
    public int Size { get; private set; }
    public int ShipNumber { get; private set; }
    public int Damage { get; set; }
    public bool IsSunk { get { return Damage == Size; } }

    public void IncrementDamage()
    {
        if (Damage < Size)
        {
            Damage++;
        }        
    }
}
