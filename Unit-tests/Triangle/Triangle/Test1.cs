using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Triangle
{   
    [TestFixture]
    class Test1
    {
        [TestCase]
        public void T01()
        {
            Triangle triangle = new Triangle();
            Assert.AreEqual(true, triangle.isTriangle(2, 2, 3));
        }
        [TestCase]
        public void T02()
        {
            Triangle triangle = new Triangle();
            Assert.AreEqual(false, triangle.isTriangle(1, 2, 3));
        }
        [TestCase]
        public void T03()
        {
            Triangle triangle = new Triangle();
            Assert.AreEqual(true, triangle.isTriangle(3, 3, 3));
        }
        [TestCase]
        public void T04()
        {
            Triangle triangle = new Triangle();
            Assert.AreEqual(false, triangle.isTriangle(0, 0, 0));
        }
        [TestCase]
        public void T05()
        {
            Triangle triangle = new Triangle();
            Assert.AreEqual(false, triangle.isTriangle(0, 1, 2));
        }
        [TestCase]
        public void T06()
        {
            Triangle triangle = new Triangle();
            Assert.AreEqual(false, triangle.isTriangle(0, 4, 0));
        }
        [TestCase]
        public void T07()
        {
            Triangle triangle = new Triangle();
            Assert.AreEqual(true, triangle.isTriangle(Double.MaxValue, Double.MaxValue, Double.MaxValue));
        }
        [TestCase]
        public void T08()
        {
            Triangle triangle = new Triangle();
            Assert.AreEqual(false, triangle.isTriangle(3, 0, -3));
        }
        [TestCase]
        public void T09()
        {
            Triangle triangle = new Triangle();
            Assert.AreEqual(false, triangle.isTriangle(-3, -1, -3));
        }
        [TestCase]
        public void T10()
        {
            Triangle triangle = new Triangle();
            Assert.AreEqual(false, triangle.isTriangle(2, -1, -3));
        }
    }
}
