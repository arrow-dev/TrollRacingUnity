using UnityEngine;

namespace Assets.Scripts.Classes
{
    public class Bet
    {
        public int Amount;
        public GameObject Racer;
        public Punter Bettor;

        public Bet(int amount, GameObject racer, Punter bettor)
        {
            Amount = amount;
            Racer = racer;
            Bettor = bettor;
        }

        public int Payout(GameObject result)
        {
            if (Racer == result)
            {
                return Amount;
            }
            else
            {
                return Amount*-1;
            }
        }

        public string GetDescription()
        {
            if (Amount > 0)
            {
                return string.Format("{0} has bet {1} on {2}.", Bettor, Amount, Racer);
            }
            else
            {
                return string.Format("{0} has not placed a bet.", Bettor);
            }
        }
    }
}
