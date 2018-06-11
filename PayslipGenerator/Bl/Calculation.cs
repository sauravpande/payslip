using PayslipGenerator.Common;
using PayslipGenerator.Interface;
using System;

namespace PayslipGenerator
{
    public  class Calculation : ICalculation
    {

        public Calculation calculationInstance;
      
        public Calculation() { }

        public  Calculation CalculationInstance
        {
            get
            {
                if (calculationInstance == null)
                {
                    calculationInstance = new Calculation();
                }
                return calculationInstance;
            }
        }

        public string CalcuPayperiod(string startMonth)
        {
            string paymentPeriod = "";

            return paymentPeriod;
        }
        public int CalcGrossIncome(int annualSalary)
        {
            return common.Instance.RoundoffValue(annualSalary / 12);
        }

        public virtual int CalcIncomeTax(double anunualSalary)
        {
            int incomeTax = 0;
            return incomeTax;
        }
        public int CalcuNetIncome(int grossSalary, int incomeTax)
        {
            return common.Instance.RoundoffValue(grossSalary - incomeTax);
        }

        public int CalcSuper(int grossSalary, int superRate)
        {
            return common.Instance.RoundoffValue(grossSalary * superRate /100);
        }

        /// <summary>
        /// Calculate Income tax as per tax slab rate
        /// </summary>
        /// <param name="annualSalary"></param>
        /// <returns></returns>
        public int CalcIncomeTaxAsPerTaxSlab(int annualSalary)
        {
            //•	income-tax 
            int incomeTax = 0;

            if (annualSalary <= 18200)
                incomeTax = TaxSlab1.Instance.CalcIncomeTax(annualSalary);
            if (annualSalary > 18200 && annualSalary <= 37000)
                incomeTax = TaxSlab2.Instance.CalcIncomeTax(annualSalary);
            else if (annualSalary > 37000 && annualSalary <= 87000)
                incomeTax = TaxSlab3.Instance.CalcIncomeTax(annualSalary);
            else if (annualSalary > 87000 && annualSalary <= 180000)
                incomeTax = TaxSlab4.Instance.CalcIncomeTax(annualSalary);
            else if (annualSalary > 180000)
                incomeTax = TaxSlab5.Instance.CalcIncomeTax(annualSalary);

            //Calculate monthly incometax
            incomeTax = incomeTax / 12;

            return incomeTax;
        }

        public bool CheckIsInteger(string userInput)
        {
            return  common.Instance.IsInteger(userInput);
        }

        public bool CheckSuperRateRange(int value)
        {
            return common.Instance.CheckSuperRateRange(value);
        }
    }


    //Tax slab Classes

    /// <summary>
    ///   //    0 – $18,200	Nil
    /// </summary>
    class TaxSlab1 : Calculation
    {

        private static TaxSlab1 instance;

        private TaxSlab1() { }

        public static TaxSlab1 Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new TaxSlab1();
                }
                return instance;
            }
        }

        public override int CalcIncomeTax(double annualSalary)
        {
            int incomeTax = 0;
            return common.Instance.RoundoffValue(incomeTax);
        }
    }

    /// <summary>
    ///  //$18,201 – $37,000	19c for each $1 over $18,200
    /// </summary>
    class TaxSlab2 : Calculation
    {
        private static TaxSlab2 instance;

        private TaxSlab2() { }

        public static TaxSlab2 Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new TaxSlab2();
                }
                return instance;
            }
        }

        public override int CalcIncomeTax(double annualSalary)
        {
            double incomeTax = ((annualSalary - 18200) * 19  )/100;

            return common.Instance.RoundoffValue(incomeTax);
        }
    }

    /// <summary>
    ///  //$37,001 – $87,000	$3,572 plus 32.5c for each $1 over $37,000
    /// </summary>
    class TaxSlab3 : Calculation
    {
        private static TaxSlab3 instance;

        private TaxSlab3() { }

        public static TaxSlab3 Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new TaxSlab3();
                }
                return instance;
            }
        }

        public override int CalcIncomeTax(double annualSalary)
        {
            double incomeTax = ( ((annualSalary - 37000) * 32.5) / 100 ) + 3572;
            return Convert.ToInt32(common.Instance.RoundoffValue(incomeTax));
        }
    }

    /// <summary>
    ///  //$87,001 – $180,000	$19,822 plus 37c for each $1 over $87,000
    /// </summary>
    class TaxSlab4 : Calculation
    {
        private static TaxSlab4 instance;

        private TaxSlab4() { }

        public static TaxSlab4 Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new TaxSlab4();
                }
                return instance;
            }
        }

        public override int CalcIncomeTax(double annualSalary)
        {
            double incomeTax = (((annualSalary - 87000 ) * 37) / 100) + 19822;
            return common.Instance.RoundoffValue(incomeTax);
        }
    }

    /// <summary>
    ///  //$180,001 and over   $54,232 plus 45c for each $1 over $180,000
    /// </summary>
    class TaxSlab5 : Calculation
    {
        private static TaxSlab5 instance;

        private TaxSlab5() { }

        public static TaxSlab5 Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new TaxSlab5();
                }
                return instance;
            }
        }
        public override int CalcIncomeTax(double annualSalary)
        {
            double incomeTax = (((annualSalary - 180000) * 45) / 100) + 54232;
            return common.Instance.RoundoffValue(incomeTax); 
        }
    }
}


//•	pay period = per calendar month
//•	gross-income = annual-salary / 12 months
//•	income-tax = based on the tax table provided below
//•	net-income = gross-income - income-tax
//•	super = gross-income x super-rate
