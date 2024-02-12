using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Royal_Flush_Casino
{
	internal class Player
	{
		double  balance;
		double moneyOnHand = 500;

		public Player(double balance) 
		{
			this.balance = balance;
		}

		public double getBalance()
		{
			return balance;
		}

		public void setBalance(double newBalance)
		{
			balance = newBalance;
		}
	}
}
