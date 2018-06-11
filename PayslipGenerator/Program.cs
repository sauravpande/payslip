using System;

namespace PayslipGenerator
{
    class Program
    {
            
        static void Main(string[] args)
        {
            bool flag = false;
            while (flag == false)
            {
                Calculation calculationInstance = new Calculation();

                //Get input from user
                GetUserInputs(calculationInstance);

                //Calculate the component of the salary slip
                CalculatePaymentComponents(calculationInstance);

                //Display Salary Slip Components
                DisplaySalarySlip();

                Console.WriteLine("****** Press q to quit *******");
                if (Console.ReadLine() == "q")
                    flag = true;
            }

        }

        private static void DisplaySalarySlip()
        {
            Console.WriteLine();
            Console.WriteLine("****** Below Is the salary slip *******");
            Console.WriteLine();
            Console.WriteLine("Name: {0} {1}", PaymentComponents.Instance.Fname, PaymentComponents.Instance.Lname);
            Console.WriteLine("Pay Period: {0} ", PaymentComponents.Instance.PayPeriod);
            Console.WriteLine("Gross income: {0} ", PaymentComponents.Instance.GrossIncome);
            Console.WriteLine("Income Tax: {0} ", PaymentComponents.Instance.IncomeTax);
            Console.WriteLine("Net Income: {0}", PaymentComponents.Instance.NetIncome);
            Console.WriteLine("Super Amount: {0}", PaymentComponents.Instance.SuperAmount);

            
        }

        /// <summary>
        /// Populate all the salary component
        /// </summary>
        /// <param name="calculationInstance"></param>
        public static void CalculatePaymentComponents(Calculation calculationInstance)
        {
            //PaymentMonth
            PaymentComponents.Instance.PayPeriod = PaymentComponents.Instance.PaymentMonth; //calculate

            //GrossIncome
            PaymentComponents.Instance.GrossIncome = calculationInstance.CalcGrossIncome(PaymentComponents.Instance.AnnualSalary);

            // AnnualSalary 
            var annualSalary = PaymentComponents.Instance.AnnualSalary;

            PaymentComponents.Instance.IncomeTax = calculationInstance.CalcIncomeTaxAsPerTaxSlab(annualSalary);

            // net-income 
            PaymentComponents.Instance.NetIncome = calculationInstance.CalcuNetIncome(PaymentComponents.Instance.GrossIncome, PaymentComponents.Instance.IncomeTax);

            // super 
            PaymentComponents.Instance.SuperAmount = calculationInstance.CalcSuper(PaymentComponents.Instance.GrossIncome, PaymentComponents.Instance.SuperRate);
            Console.WriteLine();
        }

        /// <summary>
        /// Get input values from user.
        /// </summary>
        private static void GetUserInputs(Calculation calculationInstance)
        {
            //First name
            Console.Write("Please enter following details:");
            Console.WriteLine();
            Console.Write("First name:");
            PaymentComponents.Instance.Fname = Console.ReadLine();

            //Last name
            Console.Write("Last name:");
            PaymentComponents.Instance.Lname = Console.ReadLine();

            //Super Amount:
            Console.Write("Super Rate:");
            bool success = false;
            do
            {
                int value;
                var userInput = Console.ReadLine();
                int.TryParse(userInput, out value);

                success = calculationInstance.CheckIsInteger(userInput); 

                if (success)
                    
                if (calculationInstance.CheckSuperRateRange(value))
                        PaymentComponents.Instance.SuperRate = value;
                    else
                    {
                        Console.Write("Please enter a integer with in the range 0% - 12% :");
                        success = false;
                    }
                else
                {
                    Console.Write("Please enter a integer value for Super Amount:");
                }
            }
            while (success == false);

            //Annual Salary
            Console.Write("Annual Salary:");
            success = false;
            do
            {
                int value;
                var userInput = Console.ReadLine();
                int.TryParse(userInput, out value);

                success = calculationInstance.CheckIsInteger(userInput);

                if (success)
                    PaymentComponents.Instance.AnnualSalary = value;
                else
                {
                    Console.Write("Please enter a integer value for Annual Salary:");
                }
            }
            while (success == false);

            //Payment Month:
            Console.Write("Payment Month:");
            PaymentComponents.Instance.PaymentMonth = Console.ReadLine();
        }


    }
}
