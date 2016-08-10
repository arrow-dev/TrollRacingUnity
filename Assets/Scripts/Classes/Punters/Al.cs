using Assets.Scripts.Classes;
using UnityEngine.UI;

public class Al : Punter {

    public Al(Text myText, Text myToggle)
    {
        Name = "Al";
        MyBet = null;
        Cash = 50;
        MyRadioButtonLabel = myToggle;
        MyLabel = myText;
        Busted = false;
    }
}
