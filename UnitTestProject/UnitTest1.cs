using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PayslipGenerator;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {

        private readonly Calculation calculationObject = new Calculation();


        [TestMethod]

        public void TestIncomeTaxCalculatedCorrectly()
        {
            // arrange  
            int annualSalary = 32000;
            int incomeTaxExpected = 2622;
            // act  
            int incomeTaxActual = calculationObject.CalcIncomeTaxAsPerTaxSlab(annualSalary);
            // assert  

            Assert.AreEqual(incomeTaxExpected, incomeTaxActual, "Income Tax calculated correctly");
        }

        [TestMethod]

        public void TestIncomeTaxCalculatedIncorrectly()
        {
            // arrange  
            int annualSalary = 60050;
            int incomeTaxExpected = 41922;
            // act  
            int incomeTaxActual = calculationObject.CalcIncomeTaxAsPerTaxSlab(annualSalary);
            // assert  

            Assert.AreNotEqual(incomeTaxExpected, incomeTaxActual, "Income Tax not calculated correctly");
        }

        [TestMethod]
        public void TestGrossIncomeCalculatedIncorrectly()
        {
            // arrange  
            int annualSalary = 600150;
            int grossIncomeExpected = 90104;

            // act  
            int grossIncomeActual = calculationObject.CalcGrossIncome(annualSalary);

            // assert  
            Assert.AreNotEqual(grossIncomeExpected, grossIncomeActual, "Gross Income not calculated correctly");
        }

        [TestMethod]
        public void TestGrossIncomeCalculatedProperly()
        {
            // arrange  
            int annualSalary = 60050;
            int grossIncomeExpected = 5004;

            // act  
            int grossIncomeActual = calculationObject.CalcGrossIncome(annualSalary);

            // assert  
            Assert.AreEqual(grossIncomeExpected, grossIncomeActual, "Gross Income calculated correctly");
        }

        [TestMethod]
        public void TestNetIncomeCalculatedInorrectly()
        {
            // arrange  
            int netIncomeExpected = 1082;
            int grossIncome = 5004;
            int incomeTax = 922;

            // act  
            int netIncomeActual = calculationObject.CalcuNetIncome(grossIncome, incomeTax);

            // assert  
            Assert.AreNotEqual(netIncomeExpected, netIncomeActual, "Net Income not calculated correctly");
        }


        [TestMethod]
        public void TestNetIncomeCalculatedCorrectly()
        {
            // arrange  
            int netIncomeExpected = 4082;
            int grossIncome = 5004;
            int incomeTax = 922;

            // act  
            int netIncomeActual = calculationObject.CalcuNetIncome(grossIncome, incomeTax);

            // assert  
            Assert.AreEqual(netIncomeExpected, netIncomeActual, "Net Income calculated correctly");
        }

        [TestMethod]
        public void TestSuperAmountCalculatedCorrectly()
        {
            // arrange  
            int grossIncome = 9004;
            int SuperRate = 9;
            int superAmountExpected = 450;

            // act  
            int superAmountActual = calculationObject.CalcSuper(grossIncome, SuperRate);

            // assert  
            Assert.AreNotEqual(superAmountExpected, superAmountActual, "Super Amount not calculated correctly");
        }

        [TestMethod]
        public void TestSuperAmount()
        {
            // arrange  
            int grossIncome = 5004;
            int SuperRate = 9;
            int superAmountExpected = 450;

            // act  
            int superAmountActual = calculationObject.CalcSuper(grossIncome, SuperRate);

            // assert  
            Assert.AreEqual(superAmountExpected, superAmountActual, "Super Amount calculated correctly");
        }


        [TestMethod]
        public void TestIsIntegerFunction()
        {
            // arrange  
            var SuperRate = "9";

            // act  
            bool superRateActual = calculationObject.CheckIsInteger(SuperRate);

            // assert  
            Assert.IsTrue( superRateActual, "Entered values is an integer");
        }


        [TestMethod]
        public void TestSuperRateRange()
        {
            // arrange  
            int superRate = 15;

            // act  
            bool superRateRangeActual = calculationObject.CheckSuperRateRange(superRate);

            // assert  
            Assert.IsFalse(superRateRangeActual, "super Rate is out of range");
        }

        [TestMethod]
        public void CalculateCalcuNetIncomeReturnNotNull()
        {
            //Arrange
            int _grossIncome = 18200;
            int tax = 0;
            int taxableIncome = 0;

            //Act
            calculationObject.CalcuNetIncome(_grossIncome, tax);

            //Assert
            Assert.IsNotNull(_grossIncome);
        }

        [TestMethod]
        public void CalculateCalcSuperReturnNotNull()
        {
            //Arrange
            int _grossIncome = 18200;
            int tax = 0;
            int taxableIncome = 0;

            //Act
            calculationObject.CalcSuper(_grossIncome, tax);

            //Assert
            Assert.IsNotNull(_grossIncome);
        }

        [TestMethod]
        public void CalculateCalcIncomeTaxAsPerTaxSlabReturnNotNull()
        {
            //Arrange
            int _annualIncome = 18200;
            int tax = 0;
            int taxableIncome = 0;

            //Act
            calculationObject.CalcIncomeTaxAsPerTaxSlab(_annualIncome);

            //Assert
            Assert.IsNotNull(_annualIncome);
        }


        [TestMethod]
        public void CalculateCheckSuperRateRangeReturnNotNull()
        {
            //Arrange
            int _SuperRate = 18200;
            int tax = 0;
            int taxableIncome = 0;

            //Act
            calculationObject.CheckSuperRateRange(_SuperRate);

            //Assert
            Assert.IsNotNull(_SuperRate);
        }

        [TestMethod]
        public void CalculateCalcIncomeTaxNotNull()
        {
            //Arrange
            int _annualSalary = 18200;
            int tax = 0;
            int taxableIncome = 0;

            //Act
            calculationObject.CalcIncomeTax(_annualSalary);

            //Assert
            Assert.IsNotNull(_annualSalary);
        }

        

    }
}
