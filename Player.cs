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
		double moneyOnHand;

		public Player(double balance, double moneyOnHand)
		{
			this.balance = balance;
			this.moneyOnHand = moneyOnHand;
		}

		public double getBalance()
		{
			return balance;
		}

		public void setBalance(double newBalance)
		{
			balance = newBalance;
		}

		public double getMoneyOnHand()
		{
			return moneyOnHand;
		}

		public void setMoneyOnHand(double newMoneyOnHand)
		{
			moneyOnHand = newMoneyOnHand;
		}
	}
}
