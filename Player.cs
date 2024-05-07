public class Player
{
	private double balance;
	private double moneyOnHand;
	private double chips;

	// Properties
	public double Balance
	{
		get { return balance; }
		private set { balance = value; } 
	}
	public double MoneyOnHand
	{
		get { return moneyOnHand; }
		set { moneyOnHand = value; }
	}
	public double Chips
	{
		get { return chips; }
		set { chips = value; }
	}

	// Constructor
	public Player(double balance, double moneyOnHand, double chips)
	{
		this.Balance = balance;
		this.MoneyOnHand = moneyOnHand;
		this.Chips = chips;
	}

	// Methods to modify the balance 
	public void AddToBalance(double amount)
	{
		if (amount < 0)
			throw new InvalidOperationException("Cannot add a negative amount.");
		Balance += amount;
	}

	public void SubtractFromBalance(double amount)
	{
		if (amount < 0)
			throw new InvalidOperationException("Cannot subtract a negative amount.");
		if (amount > Balance)
			throw new InvalidOperationException("Insufficient balance.");
		Balance -= amount;
	}
}

