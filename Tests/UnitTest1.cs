using RDP;

namespace Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void RdpParser()
        {
            string input = "(id+id)*id";
            Rdp parser = new();
            parser.Parse(input);
        }

        [TestMethod]
        public void RdpParserFailure()
        {
            string input = "(id-id)/id";
            Rdp parser = new();
            parser.Parse(input);
        }

        [TestMethod]
        public void ThreePointOneA()
        {
            string input = "abcd";
            RdpForThreePointOne parser = new();
            parser.Parse(input);
        }

        [TestMethod]
        public void ThreePointOneB()
        {
            string input = "acccbcc";
            RdpForThreePointOne parser = new();
            parser.Parse(input);
        }

        [TestMethod]
        public void ThreePointOneC()
        {
            string input = "aaabbbc";
            RdpForThreePointOne parser = new();
            parser.Parse(input);
        }
    }
}