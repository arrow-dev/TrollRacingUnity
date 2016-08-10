using Assets.Scripts.Classes;
using UnityEngine.UI;

public class Bob : Punter
{

    public Bob(Text myText, Text myToggle)
    {
        Name = "Bob";
        MyBet = null;
        Cash = 50;
        MyRadioButtonLabel = myToggle;
        MyLabel = myText;
        Busted = false;
    }
}
