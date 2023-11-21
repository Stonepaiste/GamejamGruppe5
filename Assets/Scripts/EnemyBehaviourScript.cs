using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
//The general movement of the enemy is very inspired by the book "Learning C# by Developing Games with Unity 2021" by Harrison Ferrone

public class EnemyBehaviourScript : MonoBehaviour
{
    public Transform Player;
    public Transform PatrolRoute;
    public List<Transform> Locations;
    public Collider ChaseRange;

    private int _locationIndex = 0;
    private NavMeshAgent _agent;
    private bool PlayerCaught = false;
    private bool FlashOn = false;


    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();


        Player = GameObject.Find("Player").transform;

        InitializePatrolRoute();
        MoveToNextPatrolLocation();
    }

    void InitializePatrolRoute()
    {
        foreach(Transform child in PatrolRoute)
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

    void Update()
    {
       if(_agent.remainingDistance < 0.2f && !_agent.pathPending)
        {
            MoveToNextPatrolLocation();
        }
    }
/*
    void OnCollisionEnter(Collider other)
    {    
        LastPosition = Player.Transform

        if(other.name == "Player")
        {
            if(FlashOn)
            {
                _agent.destination = Player.position; 
            }
            else
            {
               _agent.destination = PlayerLastPosition; 
            }
            
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.name == "Player")
        {
            if(PlayerCaught == false)
            {
                if(Position == PlayerLastPosition !& )
                {
                    _agent.destination = PlayerLastPosition; 
                }      
            }
            
        }
    }
*/
}
