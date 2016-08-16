using UnityEngine;


//This script is attached to my finishline mesh and fires the finish race event in the event master script when another gameobjects mesh collides with it.
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
