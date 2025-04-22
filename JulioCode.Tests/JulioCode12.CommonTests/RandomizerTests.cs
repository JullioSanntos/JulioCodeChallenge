using JulioCode12.Common;

namespace JulioCode99.Tests.JulioCode12.CommonTests;

[TestClass]
public class RandomizerTests
{
    [TestMethod]
    public void InstantiationTest()
    {
        var sut = new Randomizer();
        Assert.IsNotNull(sut);
    }

    [TestMethod]
    public void SyllablesTest()
    {
        var sut = new Randomizer();
        for (int i = 0; i < 20; i++)
        {
            var syllable = sut.Syllable;
            Assert.IsTrue(syllable.Length is >= 2 and <= 3);
        }
    }

    [TestMethod]
    public void WordTest()
    {
        var sut = new Randomizer();
        for (int i = 0; i < 100; i++)
        {
            var word = sut.Word;
            var length = word.Length;
            Assert.IsTrue(length is >= 1 and <= 12);
        }
    }

    [TestMethod]
    public void GetWordTest() {
        var sut = new Randomizer();
        for (int i = 0; i < 100; i++) {
            var word = sut.GetWord(2,8);
            var length = word.Length;
            Assert.IsTrue(length is >= 2 and <= 8);
        }
    }

    [TestMethod]
    public void ParagraphTest()
    {
        var sut = new Randomizer();
        for (int i = 0; i < 100; i++)
        {
            var paragraph = sut.Paragraph;
            var count = paragraph.Split(' ').Length;
            Assert.IsTrue(count is >= 5 and <= 30);
        }
    }
}
