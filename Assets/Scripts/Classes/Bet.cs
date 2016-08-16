using UnityEngine;

namespace Assets.Scripts.Classes
{
    public class Bet
    {
        public int Amount;
        public GameObject Racer;
        public Punter Bettor;


        //Constructor
        public Bet(int amount, GameObject racer, Punter bettor)
        {
            Amount = amount;
            Racer = racer;
            Bettor = bettor;
        }

        //Pass in the winner, see if bet was successful and return an int.
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

        //Gets a string containing a description of the bet.
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
