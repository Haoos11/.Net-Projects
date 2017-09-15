using ChessModel;
using ChessValidator;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace ChessTest
{
    [TestClass]
    public class ChessTester
    {

        private IChessEngine CreateTarget()
        {
            var engine = new SBoard();
            return engine;
        }


        //Toate piesele albe si un nebun negru la c7


        [TestMethod]
        public void TestMethod1()
        {
            var target = CreateTarget();

            target.Initialize("Kg1,Qc2,Rc1,Rd1,Bh5,Be3,Ne4,Pb3,Pd4,Pf2,Pg2,Ph2", "Kg6,Qe7,Ra8,Rf8,Bg7,Bc8,Nd7,Nb6,Pa5,Pb7,Pc6,Pe6,Ph6");

            //incerc sa mut un pion alb inapoi, peste rege, fals

            var sePoateMuta = target.CanMove("g6-h7");
            Assert.AreEqual(sePoateMuta, true);

            sePoateMuta = target.CanMove("a8-b8");
            Assert.AreEqual(sePoateMuta, false);

            sePoateMuta = target.CanMove("g6-h5");
            Assert.AreEqual(sePoateMuta, true);

            sePoateMuta = target.CanMove("g6-f5");
            Assert.AreEqual(sePoateMuta, true);

            sePoateMuta = target.CanMove("g6-f7");
            Assert.AreEqual(sePoateMuta, false);

            sePoateMuta = target.CanMove("g6-f6");
            Assert.AreEqual(sePoateMuta, false);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var target = CreateTarget();

            target.Initialize("Kg1,Qc2,Rc1,Rd1,Be2,Be3,Ne4,Pb3,Pd4,Pf2,Pg2,Ph2", "Kg6,Qe7,Ra8,Rf8,Bg7,Bc8,Nd7,Nb6,Pa5,Pb7,Pc6,Pe6,Ph6");

            //mut nebunul negru peste pionul din fata turei de la h, true

            var sePoateMuta = target.CanMove("f7-f2");
            Assert.AreEqual(sePoateMuta, false);

            sePoateMuta = target.CanMove("g1-f1");
            Assert.AreEqual(sePoateMuta, true);

            sePoateMuta = target.CanMove("g1-h1");
            Assert.AreEqual(sePoateMuta, true);

            sePoateMuta = target.CanMove("g1-f2");
            Assert.AreEqual(sePoateMuta, false);

            sePoateMuta = target.CanMove("g1-g2");
            Assert.AreEqual(sePoateMuta, false);

            sePoateMuta = target.CanMove("g1-h2");
            Assert.AreEqual(sePoateMuta, false);

            sePoateMuta = target.CanMove("d1-d2");
            Assert.AreEqual(sePoateMuta, true);

            sePoateMuta = target.CanMove("d1-e1");
            Assert.AreEqual(sePoateMuta, true);

            sePoateMuta = target.CanMove("d1-c1");
            Assert.AreEqual(sePoateMuta, false);

            sePoateMuta = target.CanMove("c2-c6");
            Assert.AreEqual(sePoateMuta, true);

            sePoateMuta = target.CanMove("c2-c7");
            Assert.AreEqual(sePoateMuta, false);

            sePoateMuta = target.CanMove("e3-h6");
            Assert.AreEqual(sePoateMuta, true);

            sePoateMuta = target.CanMove("g7-d4");
            Assert.AreEqual(sePoateMuta, true);

            sePoateMuta = target.CanMove("f8-f2");
            Assert.AreEqual(sePoateMuta, true);

        }
    }
}