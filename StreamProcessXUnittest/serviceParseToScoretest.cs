using CFA.OA.StreamProcessServices;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;


namespace StreamProcessXUnittest
{
    public class serviceParseToScoretest
    {
        private IParseService _mockService;

        // Since I' am nor touching any database or do I have any repository
        // to mock I m just calling the methods
        // In real world I can use MOQ or any other mocking libraray and inject mock objects with test data.
        [Fact]
        public void TestValidInputGroup()
        {
            _mockService = new ParseService();

            Assert.Equal(1, _mockService.ParseToScore("{}"));
            Assert.Equal(6, _mockService.ParseToScore("{{{}}}"));
            Assert.Equal(16, _mockService.ParseToScore("{{{},{},{{}}}}"));
            Assert.Equal(5, _mockService.ParseToScore("{{},{}}"));
            
        }
        [Fact]
        public void TestValidInputGroupwithGarbge()
        {
            _mockService = new ParseService();

            Assert.Equal(1, _mockService.ParseToScore("{<{},{},{{}}>}"));
            Assert.Equal(1, _mockService.ParseToScore("{<a>,<a>,<a>,<a>}"));
            Assert.Equal(9, _mockService.ParseToScore("{{<ab>},{<ab>},{<ab>},{<ab>}}"));
     
        }
        [Fact]
        public void TestValidInputGroupwithExclamation()
        {
            _mockService = new ParseService();

            Assert.Equal(1, _mockService.ParseToScore("{<{},{},{{}}>}"));
            Assert.Equal(9, _mockService.ParseToScore("{{<!!>},{<!!>},{<!!>},{<!!>}}"));
            Assert.Equal(3, _mockService.ParseToScore("{{<a!>},{<a!>},{<a!>},{<ab>}}"));

        }
        [Fact]
        public void TestInvalidInput()
        {
            _mockService = new ParseService();
            Exception ex = Assert.Throws<Exception>(() =>_mockService.ParseToScore("{<{},{},{{}}><}"));
            Exception ex2 = Assert.Throws<Exception>(() => _mockService.ParseToScore("{<{},{},{{}}!>}"));
            Assert.Equal("Invalid Input", ex.Message);
            Assert.Equal("Invalid Input", ex2.Message);


        }
    }
}
