using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Classes;
using UnityEngine.UI;

public class GameManager_Main : MonoBehaviour
{
    //Ui Elements
    private ToggleGroup PunterToggles;
    private Toggle ToggleJoe;
    private Toggle ToggleBob;
    private Toggle ToggleAl;
    private Text LblToggleJoe;
    private Text LblToggleBob;
    private Text LblToggleAl;
    private Text TxtMinBet;
    private Button PlayButton;
    private Text TxtJoe;
    private Text TxtBob;
    private Text TxtAl;
    private Text TxtAlert;
    private Button BetButton;
    private Dropdown BetAmount;
    private Dropdown BetRacerNum;
    private GameObject UserInterface;
    private GameObject WinnerScreen;
    private Text TxtWinner;
    private GameObject Winner;
    private GameObject FinishLine;
    private int MinBet;

    //Punters
    private List<Punter> Punters; 
    //Racers
    private List<Racer> Racers;
    //Scripts
    private GameManager_EventMaster Events;
    
	// Use this for initialization
	void Start ()
	{
        SetInitialReferences();
	    PlayButton.onClick.AddListener(StartRace);
        BetButton.onClick.AddListener(BetClick);
        InitGame();
	}

    void SetInitialReferences()
    {
        //Set references to Ui GameObjects
        PunterToggles = GameObject.Find("PunterToggles").GetComponent<ToggleGroup>();
        ToggleJoe = GameObject.Find("toggleJoe").GetComponent<Toggle>();
        ToggleBob = GameObject.Find("toggleBob").GetComponent<Toggle>();
        ToggleAl = GameObject.Find("toggleAl").GetComponent<Toggle>();
        LblToggleJoe = GameObject.Find("LabelJoe").GetComponent<Text>();
        LblToggleBob = GameObject.Find("LabelBob").GetComponent<Text>();
        LblToggleAl = GameObject.Find("LabelAl").GetComponent<Text>();
        TxtMinBet = GameObject.Find("txtMinimumBet").GetComponent<Text>();
        PlayButton = GameObject.Find("btnPlay").GetComponent<Button>();
        TxtJoe = GameObject.Find("txtJoe").GetComponent<Text>();
        TxtBob = GameObject.Find("txtBob").GetComponent<Text>();
        TxtAl = GameObject.Find("txtAl").GetComponent<Text>();
        TxtAlert = GameObject.Find("TextAlert").GetComponent<Text>();
        BetButton = GameObject.Find("btnPlaceBet").GetComponent<Button>();
        BetAmount = GameObject.Find("DropdownBet").GetComponent<Dropdown>();
        BetRacerNum = GameObject.Find("DropdownRacerNum").GetComponent<Dropdown>();
        UserInterface = GameObject.Find("UiPanel");
        WinnerScreen = GameObject.Find("RaceEndScreen");
        TxtWinner = GameObject.Find("txtWinner").GetComponent<Text>();
        FinishLine = GameObject.Find("FinishTrigger");
        Events = GetComponent<GameManager_EventMaster>();
        MinBet = 5;

        //Set up racers and punters
        Racers = new List<Racer>();
        Racers.Add(new Racer(GameObject.Find("Racer 1")));
        Racers.Add(new Racer(GameObject.Find("Racer 2")));
        Racers.Add(new Racer(GameObject.Find("Racer 3")));
        Racers.Add(new Racer(GameObject.Find("Racer 4")));
        Racers.Add(new Racer(GameObject.Find("Racer 5")));
        Punters = new List<Punter>();
        Punters.Add(new Joe(TxtJoe, LblToggleJoe));
        Punters.Add(new Bob(TxtBob, LblToggleBob));
        Punters.Add(new Al(TxtAl, LblToggleAl));

        //Subscribe to events
        Events.myFinishRaceEvent += FinishRace;
    }

    public void InitGame()
    {
        WinnerScreen.SetActive(false);
        TxtMinBet.text += MinBet.ToString();
        foreach (var punter in Punters)
        {
            punter.UpdateLabels();
        }
        ToggleJoe.onValueChanged.AddListener(SetupBet);
        ToggleBob.onValueChanged.AddListener(SetupBet);
        ToggleAl.onValueChanged.AddListener(SetupBet);
        TxtAlert.enabled = false;
    }

    public void StartRace()
    {
        bool betsPlaced = true;

        foreach (var punter in Punters)
        {
            if (punter.MyBet == null && !punter.Busted)
            {
                betsPlaced = false;
            }
        }
        if (betsPlaced)
        {
            Events.CallmyStartRaceEvent();
            UserInterface.SetActive(false);
        }
        else
        {
            ShowAlertDialog("All Punters must place a bet");
        }

    }

    void FinishRace()
    {
        Winner = Events.WinnerGameObject;
        TxtWinner.text = string.Format("{0} Won!", Winner.name);
        WinnerScreen.SetActive(true);
        FinishLine.SetActive(false);
        Invoke("CleanUp", 5f);
    }

    void CleanUp()
    {
        WinnerScreen.SetActive(false);
        UserInterface.SetActive(true);
        foreach (var punter in Punters)
        {
            punter.Collect(Winner);
            punter.ClearBet();
            punter.UpdateLabels();
        }
        foreach (var racer in Racers)
        {
           racer.Reset(); 
        }
        PunterToggles.SetAllTogglesOff();
        Winner = null;
        FinishLine.SetActive(true);
        ClearBetAmounts();
    }

    public void BetClick()
    {
        if (PunterToggles.AnyTogglesOn())
        {
            var activeToggle = PunterToggles.ActiveToggles().First();
            var betAmount = int.Parse(BetAmount.options[BetAmount.value].text);
            var racer = int.Parse(BetRacerNum.options[BetRacerNum.value].text) - 1;

            switch (activeToggle.name)
            {
                case "toggleJoe":
                    Punters[0].PlaceBet(betAmount, Racers[racer].TrollGameObject);
                    Punters[0].UpdateLabels();
                    break;
                case "toggleBob":
                    Punters[1].PlaceBet(betAmount, Racers[racer].TrollGameObject);
                    Punters[1].UpdateLabels();
                    break;
                case "toggleAl":
                    Punters[2].PlaceBet(betAmount, Racers[racer].TrollGameObject);
                    Punters[2].UpdateLabels();
                    break;
                default:
                    break;
            }
        }
        else
        {
            ShowAlertDialog("You must select a Punter");
        }
    }

    public void SetupBet(bool b)
    {
        if (b)
        {
            Punter punter;
            Toggle activeToggle = PunterToggles.ActiveToggles().First();
            switch (activeToggle.name)
            {
                case "toggleJoe":
                    punter = Punters[0];
                    break;
                case "toggleBob":
                    punter = Punters[1];
                    break;
                case "toggleAl":
                    punter = Punters[2];
                    break;
                default:
                    punter = null;
                    break;
            }

            ClearBetAmounts();
            if (!punter.Busted)
            {
                for (int i = 0; i < punter.Cash; i++)
                {
                    BetAmount.options.Add(new Dropdown.OptionData((i + 1).ToString()));
                }
                BetAmount.value = 0;
                BetAmount.captionText.text = BetAmount.options[0].text;
            }
            else
            {
                ShowAlertDialog("This Punter is busted!");
            }
        }
        
    }

    public void ClearBetAmounts()
    {
        BetAmount.options.Clear();
    }

    public void ShowAlertDialog(string message)
    {
        TxtAlert.enabled = true;
        TxtAlert.text = message;
        Invoke("HideAlertDialog", 3);
    }

    public void HideAlertDialog()
    {
        TxtAlert.enabled = false;
    }
}