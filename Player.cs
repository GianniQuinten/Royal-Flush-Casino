using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Royal_Flush_Casino
{
	internal class Player
	{
		public double  balance;
		public double moneyOnHand;
		public double chips;

		public Player(double balance, double moneyOnHand, double chips)
		{
			this.balance = balance;
			this.moneyOnHand = moneyOnHand;
			this.chips = chips;
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

		public double getChips()
		{
			return chips;
		}

		public void setChips(double newChips)
		{
			chips = newChips;
		}
	}
}
