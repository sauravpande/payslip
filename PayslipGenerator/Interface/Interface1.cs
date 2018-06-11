using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayslipGenerator.Interface
{
    interface ICalculation
    {
        string CalcuPayperiod(string startMonth);   
   
        int CalcGrossIncome(int annualSalary);
    
        int CalcIncomeTax(double annualSalary);
   
        int CalcuNetIncome(int grossSalary, int incomeTax);
   
        int CalcSuper(int grossSalary, int superRate);

        int CalcIncomeTaxAsPerTaxSlab(int annualSalary);
    }
}
