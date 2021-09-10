using Moq;
using QualityCL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualityTest
{
    public class TestMoq
    {
        public void esempiMoq()
        {
            var mock = new Mock<WebService>();

            var wsMock = mock.Object;

            Console.WriteLine(wsMock.FattoreB());
        }
    }
}
