namespace PayslipGenerator
{
    class PaymentComponents
    {

        private static PaymentComponents instance;

        private PaymentComponents() { }

        public static PaymentComponents Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new PaymentComponents();
                }
                return instance;
            }
        } 


        // User Input
        public string Fname { get; set; }
        public string Lname { get; set; }
        public int AnnualSalary { get; set; }
        public int SuperRate { get; set; }
        public string PaymentMonth { get; set; }

        //Output
        public string  PayPeriod { get; set; }
        public int GrossIncome { get; set; }
        public int IncomeTax { get; set; }
        public int NetIncome { get; set; }
        public int SuperAmount { get; set; }

    }
}
