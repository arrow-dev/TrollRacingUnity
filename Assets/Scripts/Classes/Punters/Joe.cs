using Assets.Scripts.Classes;
using UnityEngine.UI;

public class Joe : Punter
{

    public Joe(Text myText, Text myToggle)
    {
        Name = "Joe";
        MyBet = null;
        Cash = 50;
        MyRadioButtonLabel = myToggle;
        MyLabel = myText;
        Busted = false;
    }
}
