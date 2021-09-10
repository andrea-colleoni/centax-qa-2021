using Microsoft.Extensions.DependencyInjection;
using QualityCL;
using System;
using Xunit;

namespace QualityTest
{
    public class OperazioniTest: IDisposable
    {
        IServiceProvider Services;
        // setUp
        public OperazioniTest()
        {
            var cts = new ConfigureTestServices();
            this.Services = cts.Services;
        }
        // tearDown
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        [Fact]
        public void SommaConAddendiCorrettiTest()
        {
            //var srv = Services.GetRequiredService<Tipo>();
            int a = 10;
            int b = 20;
            int expected = 30;
            var op = new Operazioni();
            int actual = op.Somma(a, b);

            Assert.Equal(expected, actual);

            a = -5;
            b = 5;
            expected = 0;
            actual = op.Somma(a, b);

            Assert.Equal(expected, actual);

            a = 100;
            b = -100;
            expected = 0;
            actual = op.Somma(a, b);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void SommaConAddendiFuoriLimiteTest()
        {
            int a = 101;
            int b = 10;

            var op = new Operazioni();
            Assert.Throws<Exception>(() => op.Somma(a, b));

            a = -101;
            b = -101;
            Assert.Throws<Exception>(() => op.Somma(a, b));
        }

        [Fact]
        public void ProdottoConFattoreCorretto()
        {
            var op = new Operazioni();
            int f = 20;
            int expected = 400;

            Assert.Equal(expected, op.Prodotto(f));
            Assert.True(expected == op.Prodotto(f));

            Assert.NotEqual(20, op.Prodotto(f));
        }


    }
}
