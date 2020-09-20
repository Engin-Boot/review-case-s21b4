using Xunit;
using Sender;
using System.Collections.Generic;
using System.Linq;

namespace SenderTests
{
    public class StopWordToolTests
    {
        [Fact]
        public void TestExpectingStopWordsToBeRemovedFromASingleString()
        {
            string testSample = "all the stop words will be removed";
            Assert.Equal("stop words removed", StopWordsTool.RemoveStopWordsFromSingleString(testSample));

        }
        [Fact]
        public void TestExpectingTrueWhenAWordIsStopWordAndFalseWhenAWordIsNotStopWordWhenCalledWithAWordString()
        {
            string testSample = "is";
            Assert.True(StopWordsTool.IsStopWord(testSample));
            testSample = "isnot";
            Assert.False(StopWordsTool.IsStopWord(testSample));
        }
        [Fact]
        public void TestExpectingAllStopWordsToBeRemovedFromATwoDimensionalIEnumerable()
        {
            var stopWordsTool = new StopWordsTool();
            var testSample = new List<List<string>>()
            {
                new List<string>(){"contains a stopword","contains A stopWord Too" }
               
            };
            var expectedSample = new List<List<string>>()
            {
                new List<string>(){"contains stopword","contains stopword"}
            };
            Assert.Equal(expectedSample, stopWordsTool.RemoveStopWords(testSample));
        }
        [Fact]
        public void TestExpectingEmptyTwoDimensionalIEnumerableWhenCalledWithEmptyOrContainiingOnlyStopWordsTwoDimensionalIEnumerable()
        {
            var stopWordsTool = new StopWordsTool();
            var testSample = new List<List<string>>();
            testSample = (List<List<string>>)stopWordsTool.RemoveStopWords(testSample);
            Assert.False(testSample.Any());
        }
    }
}
