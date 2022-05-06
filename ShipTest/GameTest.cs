using NUnit.Framework;
using ShipGame; 

namespace ShipTest;

public class GameTest
{
    Game _game;
    
    [SetUp]
    public void Setup()
    {
        var player1 = new Player("Player 1");
        player1.Board = new Board();
        var player2 = new Player("Player 2");
        player2.Board = new Board();
        _game = new Game();
        _game.AddPlayer(player1);
        _game.AddPlayer(player2);
    }

    [Test]
    public void TestIfTwoPlayers()
    {
        Assert.AreEqual(2, _game.Players.Count);
    }

    [Test]    
    public void TestAddShipOnBoard()
    {
        var ship = new Ship(5,1);
        _game.Players[0].Board.AddShip(ship,0,0,true);
        Assert.AreEqual(1, _game.Players[0].Board.Ships.Count);
        _game.Players[1].Board.AddShip(ship, 2, 3, true);
        Assert.AreEqual(1, _game.Players[1].Board.Ships.Count);
    }

    [Test]
    public void TestAddShipFails()
    {
        var ship = new Ship(5, 1);
        Assert.Catch(() => _game.Players[0].Board.AddShip(ship, 6, 6, false));        
        Assert.AreEqual(0, _game.Players[0].Board.Ships.Count);
    }

    [Test]
    public void TestAddShipLocationCollisionFails()
    {
        var ship = new Ship(5, 1);
        var ship2 = new Ship(3, 2);
        _game.Players[0].Board.AddShip(ship, 2, 3, false);
        Assert.Catch(() => _game.Players[0].Board.AddShip(ship2, 1, 4, true));
        Assert.AreEqual(1, _game.Players[0].Board.Ships.Count);
    }

    [Test]
    public void TestFirePlayer1OnPlayer2()
    {
        TestAddShipOnBoard();
        var (isHit,isSunk) = _game.FireOnLocation(_game.Players[0], 3, 3);
        Assert.AreEqual(true, isHit);
        Assert.AreNotEqual(true, isSunk);
    }


}