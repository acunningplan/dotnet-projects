using System;
using Xunit;

namespace TravelBugTests
{
  public class RandomNumberGeneratorTests
  {
    private readonly RandomNumberGenerator _rng = new RandomNumberGenerator();

    [Fact]
    public void ShouldConvertStringToArrayOfNums()
    {
      // Arrange (want to generate 3 random numbers)
      var stringWithThreeNums = _rng.Generate(3);
      var arrayOfNums = stringWithThreeNums.Split(",");
      foreach (var numString in arrayOfNums)
      {
        int number;
        bool success = Int32.TryParse(numString, out number);
        // Assert
        Assert.Equal(true, success);
        Assert.Equal(true, number <= 100);
        Assert.Equal(true, number >= 1);
      };
    }

    [Theory]
    [InlineData(3)]
    [InlineData(4)]
    public void ShouldGenerateStringWithSpecificLength(int numOfNums)
    {
      // Arrange (want to generate 3 random numbers)
      var stringWithThreeNums = _rng.Generate(numOfNums);
      var arrayOfNums = stringWithThreeNums.Split(",");
      Assert.Equal(numOfNums, arrayOfNums.Length);
    }
  }
}