using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudio : MonoBehaviour
{
    //Audio controller
    GeneralSoundController soundController;
    PlayerMovement pm;

    //Singular action sounds
    public AudioClip fencesound;
    //Looping sounds
    public AudioClip playerfootsteps;
    public AudioClip death;

    //Loop control booleans
    public bool playFootsteps = false;
    public bool startedPlaying = false;
   

    // The minimum distance the object must move before the sound is played
    //public float minMoveDistance = 0.1f;
    // The position of the object in the previous frame
    //public Vector3 previousPosition;



    // Start is called before the first frame update
    void Start()
    {
        //Audio controller and getting our components
        soundController = GetComponent<GeneralSoundController>();
        pm = GetComponent<PlayerMovement>();
        
        
    }

    //Character movement
    void FixedUpdate()
    {

        // Looking for the bool isMoving in our playerMovements script and checks if it's true or false
        if (pm.isMoving == true)
        {

           
            playFootsteps = true;
            
        }
        else 
        {
           
           playFootsteps = false;
           

        }

        //Looping audio control logic
        if (playFootsteps == true && startedPlaying == false)
        {
            soundController.PlaySoundLoop(playerfootsteps);
            startedPlaying = true;
        }

        else if (playFootsteps == false)
        {
            soundController.StopLoopSound();
            startedPlaying = false;

        }


    

      
    }
    
    public bool isInTriggerzone = false;

    private bool canPlay = true;

    //Character damage
    void OnTriggerEnter(Collider other)
    {
        //play attack audio example
        //This is the code to actually play the sound, logic on when to play has been removed for clarity reasons
        //You will need to add this logic for your specific game

        if (other.name ==("Fences"))
        {
            soundController.PlaySound(fencesound);
            isInTriggerzone = true;
        };

        if(other.name == "Enemy1" && other.GetType() == typeof(CapsuleCollider) && canPlay == true || other.name == "Enemy2" && other.GetType() == typeof(CapsuleCollider) && canPlay == true)
        {
            canPlay = false;
            soundController.PlaySound(death);
            isInTriggerzone = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.name == "Fences" )
        {
            soundController.StopLoopSound();
            isInTriggerzone = false;
        }
    }

}
