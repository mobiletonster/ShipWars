namespace ShipGame;

public class Board
{
    private BoardLocation[,] _board;
    public Board(int rows = 10, int columns = 10)
    {
        Rows = rows;
        Columns = columns;
        _board = new BoardLocation[rows, columns];
        InitializeBoard();
    }
    public int Rows { get; private set; }
    public int Columns { get; private set; }
    public List<Ship> Ships { get; set; } = new List<Ship>();
    
    private void InitializeBoard()
    {
        for (int i = 0; i < Rows; i++)
        {
            for (int j = 0; j < Columns; j++)
            {
                _board[i, j] = new BoardLocation();
            }
        }
    }

    public void AddShip(Ship ship, int startRow, int startColumn, bool isVertical)
    {
        if (ShipWillFit(ship, startRow, startColumn, isVertical))
        {
            Ships.Add(ship);
            for (int i = 0; i < ship.Size; i++)
            {
                if (isVertical)
                {
                    _board[startRow + i, startColumn] = new BoardLocation(ship);
                }
                else
                {
                    _board[startRow, startColumn + i] = new BoardLocation(ship);
                }
            }
        }
        else
        {
            throw new Exception("Ship will not fit on the board at that location.");
        }
    }

    public bool ShipWillFit(Ship ship, int startRow, int startColumn, bool isVertical)
    {
        if (isVertical)
        {
            if (startRow + ship.Size > Rows)
                return false;
        }
        else
        {
            if (startColumn + ship.Size > Columns)
                return false;
        }
        
        for (int i = 0; i < ship.Size; i++)
        {
            if (isVertical)
            {
                if (_board[startRow + i, startColumn].IsLocationOccupied)
                    return false;
            } else
            {
                if (_board[startRow, startColumn + i].IsLocationOccupied)
                    return false;
            }
        }
        return true;
    }

    public (bool IsHit, bool IsSunk) CheckHit(int row, int column)
    {
        var location = _board[row, column];
        if (location.IsLocationFiredUpon)
        {
            // the location was previously struck. Choose another location.
        }
        else
        {
            location.IsLocationFiredUpon = true;
            if (location.IsLocationOccupied)
            {
                var ship = Ships.Where(s => s.ShipNumber == location.ShipNumber).FirstOrDefault();
                if (ship != null)
                {
                    ship.DecrementHealth();
                    return (true, ship.IsSunk);
                };
            }
        }
        return (false,false);
    }
}
