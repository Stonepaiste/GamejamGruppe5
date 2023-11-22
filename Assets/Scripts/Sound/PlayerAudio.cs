using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudio : MonoBehaviour
{
    //Audio controller
    GeneralSoundController soundController;
    PlayerMovement pm;

    //Singular action sounds
    // Sound to play
    public AudioClip fencesound;
    //Looping sounds
    public AudioClip playerfootsteps;
    public AudioClip Owl;

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
        //Audio controller
        soundController = GetComponent<GeneralSoundController>();
        pm = GetComponent<PlayerMovement>();
        
        // Store the initial position of the object
        //previousPosition = transform.position;
    }

    //Character movement
    void FixedUpdate()
    {
        //Example on how to start looping audio, like flying/foot steps
        //This is code you call when you want to start looping sound, but logic on when to do that has been removed for clarity reasons
        //You will need to add this logic for your specific game

        // Calculate the distance the object has moved since the last frame
        //float moveDistance = Vector3.Distance(transform.position, previousPosition);

        // If the object has moved more than the minimum distance
        if (pm.isMoving == true)
        {

            // Store the current position of the object for the next frame
            // previousPosition = transform.position;
           
            playFootsteps = true;
            print ("true");
        }
        else 
        {
           
           playFootsteps = false;
            print("false)");

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


    

        //Example on how to stop looping audio
        //This is code you call when you want to stop looping sound, but logic on when to do that has been removed for clarity reasons
        //You will need to add this logic for your specific game
        //playerfootsteps = false;
        //startedPlaying = false;
    }


    // Flag to check if the object is inside the trigger zone
    public bool isInTriggerzone = false;

    // Called when another collider enters the trigger zone
    void OnTriggerEnter(Collider other)
    {
        
        if (other.name ==("Fences"))
        {
            // Play the sound when the player enters the trigger zone
            soundController.PlaySound(fencesound);
            isInTriggerzone = true;
            Debug.Log("Entered the trigger zone");
        }
        
    }


    // Called when another collider exits the trigger zone
    public void OnTriggerExit(Collider other)
    {
        // Stop the sound when the player exits the trigger zone
        if (other.name ==("Fences"))
                {
            soundController.StopLoopSound();
            isInTriggerzone = false;
            Debug.Log("Exited the trigger zone");


        }
    }
}
