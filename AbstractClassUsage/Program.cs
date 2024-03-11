

namespace AbstractClassUsage
{
    public abstract class Account
    {
        public string Name { get; set; }
        public double Balance { get; set; }
        public Account(string name, double balance)
        {
            Name = name;
            Balance = balance;
        }

        public abstract double GetRateOfInterest();

        //to deposit amount to an account
        public void Deposit(double amount)
        {
            Balance += amount;
        }

        //to credit interest to all the account
        public static void CreditInterest(Account ac)
        {
            double rateOfInterest = ac.GetRateOfInterest();
            double amountToCredit = (ac.Balance) * (rateOfInterest / 4) / 100;
            ac.Deposit(amountToCredit);
        }
    }

    public class Saving : Account
    {
        public Saving(string name, double balance) : base(name, balance)
        {
        }

        public override double GetRateOfInterest()
        {
            return 3;
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            Account s = new Saving("Girish", 10000);

            Account.CreditInterest(s);
        }
    }
}