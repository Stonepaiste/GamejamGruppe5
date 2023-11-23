using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ReadNotes : MonoBehaviour
{
    public GameObject player;
    public GameObject noteUI;
    public GameObject hud;

    public GameObject pickUpText;

    public PlayerMovement pm;

    public bool InReach;

    public CharacterController controller;

    // Start is called before the first frame update
    void Start()
    {
        noteUI.SetActive(false);
        hud.SetActive(true);
        pickUpText.SetActive(false);
        controller = GetComponent<CharacterController>();
        InReach = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            InReach = true;
            pickUpText.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            InReach = false;
            pickUpText.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
     if(Input.GetKey(KeyCode.F) && InReach)
        {
            pm.canMove = false;
            noteUI.SetActive(true);
            hud.SetActive(false);
            controller.enabled = false;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;

            
        }
     if (Input.GetKey(KeyCode.Tab))
        {
            pm.canMove = true;
            noteUI.SetActive(false);
            hud.SetActive(true);
            player.GetComponent<CharacterController>().enabled = true;
        }
    }


    }
