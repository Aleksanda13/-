public class BankAccount
{
    private string AccountNumber;
    private string name;
    private decimal balanse;


    public BankAccount()
    {
        AccountNumber = "Unknow";
        name = "Unknow";
        balanse = 0;
    
    }


    public BankAccount(string accountnum, string name, decimal balanse)
    {
        this.AccountNumber = accountnum;
        this.name = name;
        this.balanse = balanse;
    }

    public decimal GetBalance()
    {
        Console.WriteLine($"Баланс счета {AccountNumber} составляет {balanse}");
        return balanse;
    }

    public void Deposit(decimal amount)
    {
        if (amount > 0)
        {
            balanse += amount;
            Console.WriteLine($"Cчет: {AccountNumber} был пополнен. Итоговый баланс составляет - {balanse}");
        }
        else
        {
            Console.WriteLine("Сумма пополнения должна быть больше нуля");
        }
    }

    public void Withdraw(decimal amount)
    {
        if (amount > 0 && amount <= balanse)
        {
            balanse -= amount;
            Console.WriteLine($"Снятие со счета: {AccountNumber}. Итоговый баланс составляет - {balanse}");
        }
        else
        {
            Console.WriteLine("Недостаточно средств или сумма неверна");
        }
    }

    public void Transfer(BankAccount targetAccout, decimal amount)
    {
        if (amount > 0 && amount <= balanse)
        {
            this.Withdraw(amount);
            targetAccout.Deposit(amount);
            Console.WriteLine($"Пополнение на cумму {amount} переведено co счета {AccountNumber} на счет: {targetAccout.AccountNumber}");
        }
        else
        {
            Console.WriteLine("Перевод невозможен. Недостаточно средств или сумма неверна");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        BankAccount account1 = new BankAccount("000001", "Henry Huxley", 1000);
        BankAccount account2 = new BankAccount("000084", "Charlotte Wiltshire", 500);

        Console.WriteLine("\nПополнение счёта:");
        account1.Deposit(500);

        Console.WriteLine("\nСнятие со счёта:");
        account1.Withdraw(250);

        Console.WriteLine("\nПеревод средств:");
        account1.Transfer(account2, 500);

        Console.WriteLine("\nПроверка баланса:");
        account1.GetBalance();
        account2.GetBalance();
    }
}