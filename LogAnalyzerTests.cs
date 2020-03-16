using System;
using Xunit;

namespace the_art_of_unit_test
{
    public class LogAnalyzerTests
    {
        [Fact]
        public void IsValidFileName_WhenCalled_ChangesWasLastFileNameValid(){
            LogAnalyzer la = MakeAnalyzer();

            la.IsValidLogFileName("badname.foo");

            Assert.False(la.WasLastFileNameValid);
        }
//74
        [Fact]
        public void IsValidFileName_EmptyFileName_Throws(){
            LogAnalyzer la = MakeAnalyzer();

            var ex = Assert.Throws<ArgumentException>(() => la.IsValidLogFileName(""));

            Assert.Equal("filename has to be provided", ex.Message);
        }

        [Fact]
        public void IsValidFileName_ValidFileLowerCased_ReturnsTrue(){
            LogAnalyzer la = MakeAnalyzer();

            la.IsValidLogFileName("whatever.slf");

            Assert.True(la.WasLastFileNameValid);
        }

        [Fact]
        public void IsValidFileName_ValidFileUpperCased_ReturnsTrue(){
            LogAnalyzer la = MakeAnalyzer();

            la.IsValidLogFileName("whatever.SLF");

            Assert.True(la.WasLastFileNameValid);
        }

        private LogAnalyzer MakeAnalyzer()
        {
            return new LogAnalyzer();
        }
    }
}