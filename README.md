# payslip

Model
PaymentComponents.cs <br/>
This is a model class named as PaymentComponents.cs. It consists of properties that hold 
User Input and values that needs to be shown in the Output.

Interface
This folder consists of the interface named as Interface1.cs.
This interface contains declaration of the following methods:
        string CalcuPayperiod(string startMonth);   
        int CalcGrossIncome(int annualSalary);
        int CalcIncomeTax(double annualSalary);
        int CalcuNetIncome(int grossSalary, int incomeTax);
        int CalcSuper(int grossSalary, int superRate);
        int CalcIncomeTaxAsPerTaxSlab(int annualSalary);

Program.cs
This is the main class. The execution of the application starts from this class.
It contains following methods:
GetUserInputs() - this methods is executed to take the inputs from the user.
CalculatePaymentComponents() - method that calculates the salary components by calling the Business logic methods in calculation.cs. It also updates the model values in PaymentComponents.cs.
DisplaySalarySlip() - Method to output the salary slip component.

BL
The folder BL contains the class calculation.cs. It is responsible for all the business logic.
This file contains the following methods:

CalcuPayperiod() - this method checks for the payment month.
CalcGrossIncome() - calculates the Gross income
Virtual CalcIncomeTax() – it’s a virtual method in the class and calculates the income tax.
CalcuNetIncome() - Calculates the Net income.
CalcSuper() - this method calculates the super amount.
CalcIncomeTaxAsPerTaxSlab() - this methods is responsible for calculating the income tax as per the slab rate.
CheckIsInteger() - this method class common class method to check whether the user input is a integer or not and returns a boolean result
CheckSuperRateRange() - This method in turn calls the common class method to check the range of the Super Rate  and returns a boolean result.
Below are the classes for different TaxSlab, so if a new taxslabs gets added only new class needs to be added.

TaxSlab1 <br/>
TaxSlab2 <br/>
TaxSlab3 <br/>
TaxSlab4 <br/>
TaxSlab5 <br/>







Common
This folder consists of the class Common.cs.
This class holds the methods that are not specific but can be used common functions throught the application.
Following are the methods with in this class:
RoundoffValue() - Rounds off a decimal value and returns the result.
CheckIsInteger() - Method to check whether the user input is a integer or not and returns a boolen result
CheckSuperRateRange() - Method to check the range of the Super rate  and returns a boolen result.

UnitTest
This is a unit test project added to the solution to test unit the methods
UnitTest1.cs
This a class named as UnitTest1.cs and contains following test methods:
TestIncomeTaxCalculatedCorrectly <br/>
TestIncomeTaxCalculatedIncorrectly <br/>
TestGrossIncomeCalculatedIncorrectly <br/>
TestGrossIncomeCalculatedProperly <br/>
TestNetIncomeCalculatedInorrectly <br/>
TestNetIncomeCalculatedCorrectly <br/>
TestSuperAmountCalculatedCorrectly <br/>
TestSuperAmount <br/>
TestIsIntegerFunction <br/>
TestSuperRateRange <br/>
CalculateCalcuNetIncomeReturnNotNull <br/>
CalculateCalcSuperReturnNotNull <br/>
CalculateCalcIncomeTaxAsPerTaxSlabReturnNotNull <br/>
CalculateCheckSuperRateRangeReturnNotNull <br/>
CalculateCalcIncomeTaxNotNull <br/>
