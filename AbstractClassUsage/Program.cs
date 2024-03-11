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

        public void Display()
        {
            System.Console.WriteLine($"Account Name: {this.Name}");
            System.Console.WriteLine($"Type: {this.GetType().Name}");
            System.Console.WriteLine($"Balance: {Balance}");
            System.Console.WriteLine($"InterestRate: {this.GetRateOfInterest()}");
            System.Console.WriteLine();
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
            return 3.5;
        }
    }

    public class Fixed : Account
    {
        public Fixed(string name, double balance) : base(name, balance)
        {
        }

        public override double GetRateOfInterest()
        {
            return 4.5;
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            Account a = new Saving("Girish", 10000);
            Account b = new Saving("Amit", 2000);

            System.Console.WriteLine("Balance before Interest Credited to Account...");
            a.Display();

            b.Display();

            System.Console.WriteLine("Credited Interest to Account...");
            Account.CreditInterest(a);
            Account.CreditInterest(b);


            a.Display();
            b.Display();
        }
    }
}