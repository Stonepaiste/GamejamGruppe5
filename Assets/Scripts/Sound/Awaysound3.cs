using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Awaysound3 : MonoBehaviour
{
    //Audio controller
   // GeneralSoundController soundController;
    
    //Singular action sounds
    //public AudioClip monstergrowl;
    public AudioSource sounddistance3;
  
    // Start is called before the first frame update
    void Start()

    {
        //Audio controller and getting our components
        //soundController = GetComponent<GeneralSoundController>();
    
    }

    //Creating and setting a bool variable we will use to play a sound when collinding with a given collider.
   // public bool isInTriggerzone = false;

    public bool canPlay = true;

    // Below is our collider part This checks if the collider (our Player) that entered the trigger zone has the name "Fences or "enemy"."
    //If so, it plays a sound associated with it fences(fencesound) && death
    //using the soundController and sets isInTriggerzone to true.

    void OnTriggerEnter(Collider other)
    {

        //This checks if the collider that entered the trigger zone has the name "Enemy1" or "Enemy2," is of type CapsuleCollider,
        //and the variable canPlay is true. If all these conditions are met,
        //it plays a death sound (death) using the soundController.
        // It then sets canPlay to false, and sets isInTriggerzone to true.


        if (other.CompareTag ("Player") && canPlay == true)
        {
            //soundController.PlaySound(monstergrowl);
            //isInTriggerzone = true;
            canPlay = false;
            sounddistance3.Play();

        }
    }

}

