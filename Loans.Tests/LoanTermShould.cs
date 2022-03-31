using Loans.Domain.Applications;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loans.Tests
{
    [TestFixture]
    public class LoanTermShould
    {
        [Test]
        public void ReturnTermInMonths()
        {
            LoanTerm sut = new(1);
            Assert.That(sut.ToMonths(), Is.EqualTo(12), "Months should be 12 * number of years");// String message is available, but shouldn't be necessary in most cases.
        }

        [Test]
        public void StoreYears()
        {
            var sut = new LoanTerm(1);
            Assert.That(sut.Years, Is.EqualTo(1));
        }
        [Test]
        public void RespectValueEquality()
        {
            var a = 1;
            var b = 1;
            Assert.That(a, Is.EqualTo(b));// Value types equality
        }
        [Test]
        public void RespectValueEquality_WithConstructor()
        {
            var a = new LoanTerm(1);
            var b = new LoanTerm(1);//LoanTerm has a special overwrite of Equality, so this passes, even though a normal reference type would fail
            Assert.That(a, Is.EqualTo(b));// Reference types equality
        }
        [Test]
        public void RespectValueInEquality_WithConstructor()
        {
            var a = new LoanTerm(1);
            var b = new LoanTerm(2);//LoanTerm has a special overwrite of Equality, so this passes, even though a normal reference type would fail
            Assert.That(a, Is.Not.EqualTo(b));// Reference types equality
        }
        [Test]
        public void ReferenceEqualityExample()
        {
            var a = new LoanTerm(1);
            var b = a;
            var c = new LoanTerm(1);

            Assert.That(a, Is.SameAs(b));//Syntax to compare Reference types
            Assert.That(a, Is.Not.SameAs(c)); //Syntax to negative compare Reference types

            var x = new List<string> { "a", "b" };
            var y = x;
            var z = new List<string> { "a", "b" };

            Assert.That(x, Is.SameAs(y));
            Assert.That(z, Is.Not.SameAs(x)); //The Reference Type comparison only compares the place in memory

        }
        [Test]
        public void Double()
        {
            double a = 1.0 / 3.0;

            //Assert.That(a, Is.EqualTo(0.33)); Fails due to floating point number
            Assert.That(a, Is.EqualTo(0.33).Within(0.004));
            Assert.That(a, Is.EqualTo(0.33).Within(10).Percent);
        }

    }
}
