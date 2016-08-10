using UnityEngine;
using System.Collections;

public class FinishRace : MonoBehaviour {
    GameManager_EventMaster eventScript;

    void Start()
    {
        eventScript = GameObject.Find("GameManager").GetComponent<GameManager_EventMaster>();
    }

    void OnTriggerEnter(Collider other)
    {
        eventScript.CallMyFinishRaceEvent(other.gameObject);
    }
}
