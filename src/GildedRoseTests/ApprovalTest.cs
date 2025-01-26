using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using GildedRose;
using NUnit.Framework;
using VerifyNUnit;

namespace GildedRoseTests
{
    public class ApprovalTest
    {
        [Test]
        public Task ThirtyDays()
        {
            var fakeoutput = new StringBuilder();
            Console.SetOut(new StringWriter(fakeoutput));
            Console.SetIn(new StringReader("a\n"));

            Program.Main(new string[] { "30" });
            var output = fakeoutput.ToString();

            return Verifier.Verify(output);
        }
    }
}
