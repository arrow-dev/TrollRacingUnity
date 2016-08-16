using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

namespace Assets.Scripts.Classes
{
    public class Racer
    {
        public GameObject TrollGameObject;
        public Vector3 StartingPosition;
        public ThirdPersonCharacter MovementScript;
        public NavMeshAgent MyNavMeshAgent;
        public GameManager_EventMaster EventScript;

        public Racer(GameObject gameObject)
        {
            TrollGameObject = gameObject;
            StartingPosition = gameObject.GetComponent<Transform>().position;
            MovementScript = gameObject.GetComponent<ThirdPersonCharacter>();
            MyNavMeshAgent = gameObject.GetComponent<NavMeshAgent>();
            EventScript = GameObject.Find("GameManager").GetComponent<GameManager_EventMaster>();
            EventScript.mySpeedCheckpointEvent += UpdateSpeed;
            EventScript.myStartRaceEvent += Go;
        }

        public void Go()
        {
            //The NavMeshAgent is a Unity class to move AI characters around. I am giving my racer a destination to move to.
            //Set NavMeshAgent's destination to the Vector3 position of the finish line when start event is triggered.
            MyNavMeshAgent.destination = StartingPosition + new Vector3(85f, 0f);
        }

        public void UpdateSpeed()
        {
            //Update the Racer's speed multiplier when event is triggered.
            float speed = Random.Range(1f, 2.5f);
            MovementScript.m_MoveSpeedMultiplier = speed;
        }

        public void Reset()
        {
            //Reset the Racer's Transform position in the Scene as well as the NavMeshAgent's destination.
            TrollGameObject.GetComponent<Transform>().position = StartingPosition;
            MyNavMeshAgent.destination = StartingPosition;
        }
    }
}