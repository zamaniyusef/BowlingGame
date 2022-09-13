namespace BowlingGameTest;

public class BowlingGameTests
{
    private Game _game;

    [SetUp]
    public void Setup()
    {
        _game = new Game();
    }

    [Test]
    public void TestGutterGame()
    {
        RollMany(20, 0);
        Assert.That(_game.Score().Equals(0), "Score in all zero has a problem");
    }

    [Test]
    public void TestAllOnes()
    {
        RollMany(20, 1);
        Assert.That(_game.Score().Equals(20), "Score in all one has a problem");
    }

    [Test]
    public void TestOneSpare()
    {
        RollSpare();
        _game.Roll(3);
        RollMany(17, 0);
        Assert.That(_game.Score().Equals(16), "Score in spare has a problem");
    }

    [Test]
    public void TestOneStrike()
    {
        RollStrike();
        _game.Roll(3);
        _game.Roll(4);
        RollMany(17, 0);
        Assert.That(_game.Score().Equals(24), "Score in strike has a problem");
    }
    
    [Test]
    public void TestPerfectGame()
    {
        RollMany(12, 10);
        Assert.That(_game.Score().Equals(300), "Score in perfect game has a problem");
    }

    #region PrivateMethod

    private void RollMany(int n, int pin)
    {
        for (var i = 0; i < n; i++)
        {
            _game.Roll(pin);
        }
    }

    private void RollSpare()
    {
        _game.Roll(5);
        _game.Roll(5);
    }

    private void RollStrike()
    {
        _game.Roll(10);
    }

    #endregion
}