using UnityEngine.UI;

namespace Assets.Scripts.Classes.Punters
{
    public class PunterFactory
    {
        //Pass in a valid subclass name and get back an object of that type.
        public Punter CreatePunter(string subclass, Text myText, Text myToggleText)
        {
            switch (subclass)
            {
                case "Al":
                    return new Al(myText, myToggleText);
                    break;
                case "Bob":
                    return new Bob(myText, myToggleText);
                    break;
                case "Joe":
                    return new Joe(myText, myToggleText);
                    break;
                default:
                    return null;
            }
        }
    }
}
