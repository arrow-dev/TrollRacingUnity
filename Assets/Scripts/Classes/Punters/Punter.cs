using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Classes
{
    public abstract class Punter
    {
        public string Name;
        public Bet MyBet;
        public int Cash;
        public Text MyRadioButtonLabel;
        public Text MyLabel;
        public bool Busted;

        public void UpdateLabels()
        {
            if (MyBet!= null)
            {
                MyLabel.text = MyBet.GetDescription();
            }
            else
            {
                MyLabel.text = string.Format("{0} has not placed a bet", Name);
            }

            MyRadioButtonLabel.text = string.Format("{0} has {1} bucks", Name, Cash);

        }

        public void PlaceBet(int amount, GameObject racer)
        {
            MyBet = new Bet(amount, racer, this);
        }

        public void ClearBet()
        {
            MyBet = null;
        }

        public void Collect(GameObject winner)
        {
            if (MyBet != null)
            {
                Cash += MyBet.Payout(winner);
                if (Cash == 0)
                {
                    Busted = true;
                }
            }
        }
    }
}
