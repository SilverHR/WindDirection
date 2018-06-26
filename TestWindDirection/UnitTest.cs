using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WindDirection;

namespace TestWindDirection
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void TestAvgDirection010()
        {
            var measureList = new List<Measure>();
            measureList.Add(new Measure { Speed = 1, Direction = 5 });
            measureList.Add(new Measure { Speed = 1, Direction = 15 });

            var result = WindDirectionCalculator.CalculateAvgDirection(measureList);
            var expectedResult = 10;

            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void TestAvgDirection090()
        {
            var measureList = new List<Measure>();
            measureList.Add(new Measure { Speed = 1, Direction = 80 });
            measureList.Add(new Measure { Speed = 1, Direction = 100 });

            var result = WindDirectionCalculator.CalculateAvgDirection(measureList);
            var expectedResult = 90;

            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void TestAvgDirection180()
        {
            var measureList = new List<Measure>();
            measureList.Add(new Measure { Speed = 1, Direction = 170 });
            measureList.Add(new Measure { Speed = 1, Direction = 190 });

            var result = WindDirectionCalculator.CalculateAvgDirection(measureList);
            var expectedResult = 180;

            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void TestAvgDirection270()
        {
            var measureList = new List<Measure>();
            measureList.Add(new Measure { Speed = 1, Direction = 260 });
            measureList.Add(new Measure { Speed = 1, Direction = 280 });

            var result = WindDirectionCalculator.CalculateAvgDirection(measureList);
            var expectedResult = 270;

            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void TestAvgDirection000()
        {
            var measureList = new List<Measure>();
            measureList.Add(new Measure { Speed = 1, Direction = 350 });
            measureList.Add(new Measure { Speed = 1, Direction = 10 });

            var result = WindDirectionCalculator.CalculateAvgDirection(measureList);
            var expectedResult = 0;

            Assert.AreEqual(expectedResult, result);
        }


        [TestMethod]
        public void TestAvgDirectionzero()
        {
            var measureList = new List<Measure>();
            measureList.Add(new Measure { Speed = 1, Direction = 0 });
            measureList.Add(new Measure { Speed = 1, Direction = 90 });
            measureList.Add(new Measure { Speed = 1, Direction = 180 });
            measureList.Add(new Measure { Speed = 1, Direction = 270 });

            var result = WindDirectionCalculator.CalculateAvgDirection(measureList);
            var expectedResult = 0;

            Assert.AreEqual(expectedResult, result);
        }


        [TestMethod]
        public void TestAvgDirection014_Multiple()
        {
            var measureList = new List<Measure>();
            measureList.Add(new Measure { Speed = 1, Direction = 0 });
            measureList.Add(new Measure { Speed = 1, Direction = 0 });
            measureList.Add(new Measure { Speed = 1, Direction = 0 });
            measureList.Add(new Measure { Speed = 1, Direction = 0 });
            measureList.Add(new Measure { Speed = 1, Direction = 90 });

            var result = WindDirectionCalculator.CalculateAvgDirection(measureList);
            var expectedResult = 14;

            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void TestAvgDirection014_Scale()
        {
            var measureList = new List<Measure>();
            measureList.Add(new Measure { Speed = 4, Direction = 0 });
            measureList.Add(new Measure { Speed = 1, Direction = 90 });

            var result = WindDirectionCalculator.CalculateAvgDirection(measureList);
            var expectedResult = 14;

            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void TestAvgDirection270_090()
        {
            var measureList = new List<Measure>();
            for (var i = 270; i < 360; i++) { measureList.Add(new Measure { Speed = 1, Direction = i }); }
            for (var i = 0; i <= 90; i++) { measureList.Add(new Measure { Speed = 1, Direction = i }); }

            var result = WindDirectionCalculator.CalculateAvgDirection(measureList);
            var expectedResult = 0;

            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void TestAvgDirection270_090_Scale()
        {
            var measureList = new List<Measure>();
            for (var i = 270; i < 360; i++) { measureList.Add(new Measure { Speed = 1, Direction = i }); }
            for (var i = 0; i <= 90; i++) { measureList.Add(new Measure { Speed = i, Direction = i }); }

            var result = WindDirectionCalculator.CalculateAvgDirection(measureList);
            var expectedResult = 59;

            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void TestCompas_N()
        {
            Assert.AreEqual("N", WindDirectionCalculator.AngleToCompass(0));
            Assert.AreEqual("N", WindDirectionCalculator.AngleToCompass(10));
            Assert.AreEqual("N", WindDirectionCalculator.AngleToCompass(350));

            Assert.AreNotEqual("N", WindDirectionCalculator.AngleToCompass(30));
            Assert.AreNotEqual("N", WindDirectionCalculator.AngleToCompass(360-30));

            Assert.AreEqual("N", WindDirectionCalculator.AngleToCompass(11));
            Assert.AreNotEqual("N", WindDirectionCalculator.AngleToCompass(12));

            Assert.AreEqual("N", WindDirectionCalculator.AngleToCompass(360-11));
            Assert.AreNotEqual("N", WindDirectionCalculator.AngleToCompass(360-12));
        }

        [TestMethod]
        public void TestCompas_ALL()
        {
            for (var a = 0.0; a<360; a += 22.5)
            {
                Assert.AreEqual(WindDirectionCalculator.AngleToCompass((a + 11) % 360), WindDirectionCalculator.AngleToCompass(a));
                Assert.AreNotEqual(WindDirectionCalculator.AngleToCompass((a + 12) % 360), WindDirectionCalculator.AngleToCompass(a));
            }
        }
    }
}
