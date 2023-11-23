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
    public AudioClip death;
   // public AudioClip monstergrowl;
    //Looping sounds
    public AudioClip playerfootsteps;


    //Loop control booleans
    public bool playFootsteps = false;
    public bool startedPlaying = false;



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

    //Creating and setting a bool variable we will use to play a sound when collinding with a given collider.
    public bool isInTriggerzone = false;

    private bool canPlay = true;

    // Below is our collider part This checks if the collider (our Player) that entered the trigger zone has the name "Fences or "enemy"."
    //If so, it plays a sound associated with it fences(fencesound) && death
    //using the soundController and sets isInTriggerzone to true.
   
    void OnTriggerEnter(Collider other)
    {
        

        if (other.name ==("Fences"))
        {
            soundController.PlaySound(fencesound);
            isInTriggerzone = true;
        }


        //This checks if the collider that entered the trigger zone has the name "Enemy1" or "Enemy2," is of type CapsuleCollider,
        //and the variable canPlay is true. If all these conditions are met,
        //it plays a death sound (death) using the soundController.
        // It then sets canPlay to false, and sets isInTriggerzone to true.



        if (other.name == "Enemy1" && other.GetType() == typeof(CapsuleCollider) && canPlay == true || other.name == "Enemy2" && other.GetType() == typeof(CapsuleCollider) && canPlay == true)
        {
            canPlay = false;
            soundController.PlaySound(death);
            isInTriggerzone = true;
        }
        
        //if (other.name == ("SoundColliderScream"))
        //{
            //soundController.PlaySound(monstergrowl);
          //  isInTriggerzone = true;



        //}
        
    }


    // below we make sure to stop the sound from playing again and resets the isInTriggerZone back to default false.

    private void OnTriggerExit(Collider other)
    {
        if (other.name == "Fences" )
        {
         //   soundController.StopLoopSound();
            isInTriggerzone = false;
        }
        if (other.name == "SoundColliderScream")
        {
         //   soundController.StopLoopSound();
            isInTriggerzone = false;
        }
    }

}
