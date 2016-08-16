using UnityEngine;

//This is all of my Events that can be called or subscribed to.
public class GameManager_EventMaster : MonoBehaviour
{
    public GameObject WinnerGameObject; 

    public delegate void SpeedCheckpointEvent();

    public event SpeedCheckpointEvent mySpeedCheckpointEvent;

    public void CallMySpeedCheckpointEvent()
    {
        if (mySpeedCheckpointEvent != null)
        {
            mySpeedCheckpointEvent();
        }
    }

    public delegate void StartRaceEvent();

    public event StartRaceEvent myStartRaceEvent;

    public void CallmyStartRaceEvent()
    {
        if (myStartRaceEvent != null)
        {
            myStartRaceEvent();
        }
    }

    public delegate void ResetRaceEvent();

    public event ResetRaceEvent myResetRaceEvent;

    public void CallMyResetRaceEvent()
    {
        if (myResetRaceEvent != null)
        {
            myResetRaceEvent();
        }
    }

    public delegate void FinishRaceEvent();

    public event FinishRaceEvent myFinishRaceEvent;

    public void CallMyFinishRaceEvent(GameObject winner)
    {
        if (myFinishRaceEvent != null)
        {
            WinnerGameObject = winner;
            myFinishRaceEvent();
        }
    }
}
