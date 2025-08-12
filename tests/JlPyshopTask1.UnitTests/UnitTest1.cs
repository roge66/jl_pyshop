using Task1;

namespace JlPyshopTask1.UnitTests;

public class UnitTest1
{
    private Game CreateTestGame(params (int offset, int home, int away)[] data)
    {
        GameStamp[] stamps = new GameStamp[data.Length];
        for (int i = 0; i < data.Length; i++)
        {
            var (offset, home, have) = data[i];
            stamps[i] = new GameStamp(offset, home, have);
        }
        return new Game(stamps);
    }
    
    
    [Fact]
    public void ShouldReturnZeroScore_WhenGameStampsIsEmpty()
    {
        // Arrange
        var game = new Game();
        int offset = 100;
        
        // Act
        var score = game.getScore(offset);
        
        // Assert
        Assert.Equal(0, score.home);
        Assert.Equal(0, score.away);
    }

    [Fact]
    public void ShouldReturnCorrectScore_WhenExactOffsetMatch()
    {
        // Arrange
        var game = CreateTestGame(
            (0, 0, 0),
            (5, 1, 0),
            (10, 1, 1)
        );
        int offset = 5;
        
        // Act
        var score = game.getScore(offset);
        
        // Assert
        Assert.Equal(1, score.home);
        Assert.Equal(0, score.away);
    }

    [Fact]
    public void ShouldReturnCorrectScore_WhenOffsetBetweenStamps()
    {
        // Arrange
        var game = CreateTestGame(
            (0, 0, 0),
            (5, 1, 0),
            (10, 1, 1)
        );
        int offset = 8;
        
        // Act
        var score = game.getScore(offset);
        
        // Assert
        Assert.Equal(1, score.home);
        Assert.Equal(0, score.away);
    }

    [Fact]
    public void ShouldReturnCorrectScore_WhenOffsetBeforeFirstStamp()
    {
        // Arrange
        var game = CreateTestGame(
            (0, 0, 0),
            (5, 1, 0),
            (10, 1, 1)
        );
        int offset = 2;
        
        // Act
        var score = game.getScore(offset);
        
        // Assert
        Assert.Equal(0, score.home);
        Assert.Equal(0, score.away);
    }

    [Fact]
    public void ShouldReturnLastScore_WhenOffsetAfterLastStamp()
    {
        // Arrange
        var game = CreateTestGame(
            (0, 0, 0),
            (5, 1, 0),
            (10, 1, 1)
        );
        int offset = 50;
        
        // Act
        var score = game.getScore(offset);
        
        // Assert
        Assert.Equal(1, score.home);
        Assert.Equal(1, score.away);
    }

    [Fact]
    public void ShouldReturnThatScoreForAnyOffset_WhenSingleElementInArray()
    {
        // Arrange
        var game = CreateTestGame((0, 1, 1));
        int offset = 50;
        
        // Act
        var score = game.getScore(offset);
        
        // Arrange
        Assert.Equal(1, score.home);
        Assert.Equal(1, score.away);
    }

    [Fact]
    public void ShouldReturnZeroScore_WhenOffsetIsNegative()
    {
        // Arrange
        var game = CreateTestGame(
            (0, 0, 0),
            (5, 1, 0),
            (10, 1, 1)
        );
        int offset = -10;
        
        // Act
        var score = game.getScore(offset);
        
        // Assert
        Assert.Equal(0, score.home);
        Assert.Equal(0, score.away);
    }

    [Fact]
    public void ShouldReturnInitialScore_WhenOffsetWithNoScoreChange()
    {
        // Arrange
        var game = CreateTestGame(
            (0, 0, 0),
            (5, 0, 0),
            (10, 0, 0)
        );
        int offset = 7;
        
        // Act
        var score = game.getScore(offset);
        
        // Assert
        Assert.Equal(0, score.home);
        Assert.Equal(0, score.away);
    }

    [Fact]
    public void ShouldReturnCorrectScore_WhenConsecutiveOffsetsWithSameScore()
    {
        // Arrange
        var game = CreateTestGame(
            (0, 0, 0),
            (5, 1, 0),
            (7, 1, 0),
            (10, 1, 1)
        );
        int offset = 7;
        
        // Act
        var score = game.getScore(offset);
        
        // Assert
        Assert.Equal(1, score.home);
        Assert.Equal(0, score.away);
    }
}