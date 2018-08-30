using Calculator;
using Calculator.Data;
using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;

namespace UnitTestCalculatorEngine
{
    [TestFixture]
    public class CalculatorTest
    {
        [TestCase(1,2,ExpectedResult=3)]
        [TestCase(997679, 2889, ExpectedResult=1000568)]
        [TestCase(5.00654, 3.987, ExpectedResult=8.99354)]
        [TestCase(9998.625474, 324781236.12412, ExpectedResult = 324791234.749594)]
        public double AddTwoNumbers(double num1, double num2)
        {
            Console.WriteLine("Adding " + num1 + " and " + num2);
            var expectedResult = num1 + num2;
            var calculator = new MyCalculator();
            var actualResult = calculator.Calculate(num1, num2, EOperations.Add);
            Console.WriteLine("Expected Result: " + expectedResult);
            Console.WriteLine("Actual Result: " + actualResult);
            return actualResult;
        }

        [TestCase(2,1,ExpectedResult = 1)]
        [TestCase(2, 20,ExpectedResult = -18)]
        [TestCase(-2, -3,ExpectedResult = 1)]
        [TestCase(-2, 3,ExpectedResult = -5)]
        [TestCase(32452213.0129, 21234.27162, ExpectedResult = 32430978.74128)]
        public double SubtractTwoNumbers(double num1, double num2)
        {
            Console.WriteLine("Subtracting " + num1 + " and " + num2);
            var expectedResult = num1 - num2;
            var calculator = new MyCalculator();
            var actualResult =  calculator.Calculate(num1, num2, EOperations.Subtract);
            Console.WriteLine("Expected Result: " + expectedResult);
            Console.WriteLine("Actual Result: " + actualResult);
            return actualResult;
        }

        [TestCase(1, 0, ExpectedResult = 0)]
        [TestCase(0, 0, ExpectedResult = 0)]
        [TestCase(0, 1, ExpectedResult = 0)]
        [TestCase(-1, 1, ExpectedResult = -1)]
        [TestCase(-1, -1, ExpectedResult = 1)]
        [TestCase(999987.254, 154.03, ExpectedResult = 154028036.73362)]
        public double MultiplyTwoNumbers(double num1, double num2)
        {
            Console.WriteLine("Multiplying " + num1 + " and " + num2);
            var expectedResult = num1 * num2;
            var calculator = new MyCalculator();
            var actualResult = calculator.Calculate(num1, num2, EOperations.Multiply);
            Console.WriteLine("Expected Result: " + expectedResult);
            Console.WriteLine("Actual Result: " + actualResult);
            return actualResult;
        }
        [TestCase(4, 2, ExpectedResult = 2)]
        [TestCase(32452213.0129, 21234.27162, ExpectedResult = 1528.294146069702)]
        public double DivideTwoNumbers(double num1, double num2)
        {
            Console.WriteLine("Dividing " + num1 + " and " + num2);
            var expectedResult = num1 / num2;
            var calculator = new MyCalculator();
            var actualResult = calculator.Calculate(num1, num2, EOperations.Divide);
            Console.WriteLine("Expected Result: " + expectedResult);
            Console.WriteLine("Actual Result: " + actualResult);
            return actualResult;
        }

        [TestCase]
        public void UnnecessaryMethod()
        {
            double num1 = 12312.92137;
            double num2 = 39723.123;
            Console.WriteLine("Extra Method " + num1 + " and " + num2);
            var possibleExpectedValues = new Dictionary<string,double>();
            var add = num1 + num2;
            var subtract = num1 - num2;
            var divide = num1 / num2;
            var multiply = num1 * num2;
            possibleExpectedValues.Add("Add", add);
            possibleExpectedValues.Add("Subtract", subtract);
            possibleExpectedValues.Add("Multiply", multiply);
            possibleExpectedValues.Add("Divide", divide);
            var calculator = new MyCalculator();
            var actualResult = calculator.Calculate(num1, num2, EOperations.Unknown);
            bool match = false;
            foreach(var item in possibleExpectedValues)
            {
                Console.WriteLine("If " + item.Key + " then " + item.Value);
                if (actualResult.Equals(item.Value))
                {
                    match = true;
                    Console.WriteLine("Unknown operation matched method: " + item.Key);
                }
            }
            Console.WriteLine("Actual result: " + actualResult);
            if (match==false)
            {
                Console.WriteLine("No operation matched result");
                Assert.True(match);
            }
        }
    }
}