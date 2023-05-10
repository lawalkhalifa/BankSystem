
namespace BankAccount
{
abstract class BankAccount
{
    public string AccountNumber { get; set; }
    public double Balance { get; set; }

    public virtual void Deposit(double amount)
    {
        Balance += amount;
    }

    public virtual bool Withdraw(double amount)
    {
        if (Balance >= amount)
        {
            Balance -= amount;
            return true;
        }

        return false;
    }
}
class SavingsAccount : BankAccount
{
    public double InterestRate { get; set; }

    public override void Deposit(double amount)
    {
        
        Balance += Balance * InterestRate;
        base.Deposit(amount);
    }

    public override bool Withdraw(double amount)
    {
     
        if (Balance - amount >= 0)
        {
            return base.Withdraw(amount);
        }

        return false;
    }
}

class CurrentAccount : BankAccount
{
    public double OverdraftLimit { get; set; }

    public override bool Withdraw(double amount)
    {

        if (Balance + OverdraftLimit >= amount)
        {
            Balance -= amount;
            return true;
        }

        return false;
    }
}
public class Account
{
    public string AccountNumber { get; set; }
    public string AccountHolderName { get; set; }
    public double AccountBalance { get; set; }

    public virtual string GetAccountType()
    {
        return "Generic Account";
    }
}
}

