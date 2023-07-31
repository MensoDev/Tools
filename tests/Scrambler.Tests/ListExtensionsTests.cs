namespace Menso.Tools.Scrambler.Tests;

public class ListExtensionsTests
{
    [Fact]
    public void Shuffle_WithSeed_ShouldShuffleListAlwaysTheSameWay()
    {
        // Arrange
        var list = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        const int seed = 123;

        // Act
        list.Shuffle(seed);

        // Assert
        list.Should().BeEquivalentTo(new List<int> { 2, 3, 7, 1, 4, 5, 6, 8, 9 });
    }
    [Fact]
    public void Shuffle_WithSeed_ShouldThrowExceptionWhenListIsNull()
    {
        // Arrange
        var list = (List<int>)null!;
        const int seed = 123;
        
        // Act
        var execution = () => list.Shuffle(seed);

        // Assert
        execution.Should().Throw<ArgumentNullException>();
    }
    
    
    [Fact]
    public void Shuffle_WithoutSeed_ShouldShuffleListRandomly()
    {
        // Arrange
        var list = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

        // Act
        list.Shuffle();

        // Assert
        list.Should().NotContainInConsecutiveOrder();
    }
    
    [Fact]
    public void Shuffle_WithoutSeed_ShouldThrowExceptionWhenListIsNull()
    {
        // Arrange
        var list = (List<int>)null!;

        // Act
        var execution = () => list.Shuffle();

        // Assert
        execution.Should().Throw<ArgumentNullException>();
    }
    
    [Fact]
    public void CryptoStrongShuffle_ShouldShuffleListRandomly()
    {
        // Arrange
        var list = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

        // Act
        list.CryptoStrongShuffle();

        // Assert
        list.Should().NotContainInConsecutiveOrder();
    }

    [Fact]
    public void CryptoStrongShuffle_ShouldThrowExceptionWhenListIsNull()
    {
        // Arrange
        var list = (List<int>)null!;

        // Act
        var execution = () => list.CryptoStrongShuffle();

        // Assert
        execution.Should().Throw<ArgumentNullException>();
    }
    
}