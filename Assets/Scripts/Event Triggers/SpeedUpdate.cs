using UnityEngine;
using System.Collections;

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
