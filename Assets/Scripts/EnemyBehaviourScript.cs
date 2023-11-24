using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
//The general movement of the enemy is very inspired by the book "Learning C# by Developing Games with Unity 2021" by Harrison Ferrone
//The code made for approaching the Player was also made by the help of feedback from Chat_GBT

public class EnemyBehaviourScript : MonoBehaviour
{
    public bool FlashOn;
    public Transform PatrolRoute;
    public List<Transform> Locations;
    
    private Transform Player;
    private NavMeshAgent _agent;
    private float reachedDestinationThreshold = 0.2f;
    private int _locationIndex = 0;
    public PlayerMovement pm;
    
    private GameObject LastPosition;
    private bool PlayerInRange = false;
    private MouseLook mouseLookScript;

    public bool canMove;


    void Start()
    {
        canMove = true;
        _agent = GetComponent<NavMeshAgent>();
        Player = GameObject.Find("FirstPersonPlayer").transform;
        mouseLookScript = FindObjectOfType<MouseLook>();

        InitializePatrolRoute();
        MoveToNextPatrolLocation();
    }

    void Update()
    {
        FlashOn = mouseLookScript.flashlightEnabled;

        if (pm.isDead == true)
        {
            canMove = false;
        }

        if (canMove)
        {
            if (_agent.remainingDistance < reachedDestinationThreshold && !_agent.pathPending)
            {
                MoveToNextPatrolLocation();
            }

            if (PlayerInRange && FlashOn)
            {
                _agent.destination = Player.position;
            }

            if (!FlashOn && LastPosition != null)
            {
                _agent.destination = LastPosition.transform.position;

                if (Vector3.Distance(transform.position, LastPosition.transform.position) < reachedDestinationThreshold)
                {
                    Destroy(LastPosition);
                }
            }
        }
    }

    void InitializePatrolRoute()
    {
        foreach (Transform child in PatrolRoute)
        {
            Locations.Add(child);
        }
    }

    void MoveToNextPatrolLocation()
    {
        if (Locations.Count == 0)
            return;

        _agent.destination = Locations[_locationIndex].position;
        _locationIndex = (_locationIndex + 1) % Locations.Count;

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.name == "FirstPersonPlayer")
        {
            PlayerInRange = true;
            if (FlashOn && LastPosition == null)
            {
                LastPosition = new GameObject("LastPosition");
                LastPosition.transform.position = Player.position;
            }

        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.name == "FirstPersonPlayer")
        {
            PlayerInRange = false;
            Destroy(LastPosition);
        }
    }
}