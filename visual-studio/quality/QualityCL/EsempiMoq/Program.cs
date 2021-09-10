using Moq;
using QualityCL;
using System;
using System.Threading.Tasks;

namespace EsempiMoq
{
    class Program
    {
        static void Main(string[] args)
        {
            var p = new Program();
            p.UsiamoMoq();
        }

        async void UsiamoMoq()
        {
            var mock = new Mock<WebService>();
            var wsMock = mock.Object;
            var wsMock2 = mock.Object; // è la stessa reference

            // con argomento
            mock.Setup(m => m.FattoreA(1)).Returns(18);
            mock.Setup(m => m.FattoreA(2)).Returns(19);
            Console.WriteLine(wsMock.FattoreA(1));
            Console.WriteLine(wsMock.FattoreA(2));
            Console.WriteLine(wsMock.FattoreA(3)); // non specificato => ret il def value

            Console.WriteLine("....");
            // senza argomento
            mock.Setup(m => m.FattoreB()).Returns(10);
            Console.WriteLine(wsMock.FattoreB());

            Console.WriteLine("....");
            // matcher (It)
            //mock.Setup(m => m.FattoreC(It.Is<int>(i => i > 0))).Returns(25);
            //mock.Setup(m => m.FattoreC(It.Is<int>(i => i <= 0))).Returns(-25);
            mock.Setup(m => m.FattoreC(It.IsAny<int>())).Returns(-25);
            mock.Setup(m => m.FattoreC(It.IsInRange(0, 10, Moq.Range.Inclusive))).Returns(22);
            Console.WriteLine(wsMock.FattoreC(3));
            Console.WriteLine(wsMock.FattoreC(-10));
            mock.Setup(m => m.FattoreS(It.IsRegex("[a-d]+", System.Text.RegularExpressions.RegexOptions.IgnoreCase))).Returns("Ok");
            Console.WriteLine(wsMock.FattoreS("abcd"));
            Console.WriteLine(wsMock.FattoreS("efgh"));

            Console.WriteLine("....");
            // oggetti
            // mock.Setup(m => m.Classe()).Returns(new Classe { Prop1 = "test", Prop2 = 100 });
            var obj = new Classe { Prop1 = "Test classe", Prop2 = -10 };
            mock.Setup(m => m.Classe()).Returns(obj);
            Console.WriteLine($"prop1: {wsMock.Classe().Prop1}");

            Console.WriteLine("....");
            // properietà
            // mock.SetupProperty(p => p.TestProp); // tracking di una prop
            mock.SetupProperty(p => p.TestProp, "iniziale"); // tracking di una prop + set default
            wsMock.TestProp = "valore messo qui";
            Console.WriteLine($"prop1: {wsMock.TestProp}");


            Console.WriteLine("....");
            //mock.Setup(m => m.FattoreAsync().Result).Returns("ciao");
            //mock.Setup(m => m.FattoreAsync()).ReturnsAsync("buongiorno");
            mock.Setup(m => m.FattoreAsync()).Returns(async () => "buonanotte");
            Console.WriteLine(await wsMock.FattoreAsync());

            Console.WriteLine("....");
            // eccezioni e base
            try
            {
                mock.Setup(m => m.FattoreC(It.IsInRange(0, 10, Moq.Range.Inclusive))).Returns(22);
                mock.Setup(m => m.FattoreC(It.Is<int>(i => i > 10))).Throws(new Exception("troppo grande!!"));
                mock.Setup(m => m.FattoreC(It.Is<int>(i => i < 5))).CallBase();
                Console.WriteLine(wsMock.FattoreC(5));
                Console.WriteLine(wsMock.FattoreC(-5));
                Console.WriteLine(wsMock.FattoreC(3));
                Console.WriteLine(wsMock.FattoreC(16));
            }
            catch (Exception e)
            {
                Console.Write(e.Message);
            }

            Console.WriteLine("....");
            mock.SetupSequence(m => m.FattoreAsync())
                .Returns(async () => "buongiorno")
                .Returns(async () => "buon pomeriggio")
                .Returns(async () => "buona sera")
                .CallBase();
                //.Throws(new Exception("errore"));

            Console.WriteLine(await wsMock.FattoreAsync());
            Console.WriteLine(await wsMock.FattoreAsync());
            Console.WriteLine(await wsMock.FattoreAsync());
            Console.WriteLine(await wsMock.FattoreAsync());


            mock.Verify(m => m.FattoreB());

            mock.Verify(m => m.FattoreA(1));
            mock.Verify(m => m.FattoreA(5), Times.Never);
            mock.Verify(m => m.FattoreA(5), Times.Exactly(5));

            mock.VerifySet(p => p.TestProp);
        }
    }
}
