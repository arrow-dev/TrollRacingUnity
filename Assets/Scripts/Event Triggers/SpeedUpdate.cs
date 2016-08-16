using UnityEngine;

//This script is attached to my speedupdate meshes along the track and when crossed they fire the speed update event which my racer objects updatespeed methods are subscribed to.
public class SpeedUpdate : MonoBehaviour
{
    private GameManager_EventMaster eventMasterScript;

    void Start()
    {
        SetRef();
    }

    void OnTriggerEnter(Collider other)
    {
        eventMasterScript.CallMySpeedCheckpointEvent();
    }

    void SetRef()
    {
        eventMasterScript = GameObject.Find("GameManager").GetComponent<GameManager_EventMaster>();
    }
}
