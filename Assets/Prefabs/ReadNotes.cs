using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ReadNotes : MonoBehaviour
{
    //public GameObject player;
    public GameObject noteCanvas;
    public GameObject playerCanvas;

    public GameObject pickUpNote;

    public PlayerMovement pm;

    public GameObject pressF;

    public bool InReach;

    // Start is called before the first frame update
    void Start()
    {
        noteCanvas.SetActive(false);
        pickUpNote.SetActive(false);
        //controller = GetComponent<CharacterController>();
        InReach = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            pressF.SetActive(true);
            InReach = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            InReach = false;
            pressF.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F) && InReach && noteCanvas.activeInHierarchy == false)
        {
            pm.canMove = false;
            noteCanvas.SetActive(true);
            pickUpNote.SetActive(true);
            pressF.SetActive(false);
        }
        else if (Input.GetKeyDown(KeyCode.F) && noteCanvas.activeInHierarchy == true)
        {
            pm.canMove = true;
            noteCanvas.SetActive(false);
        }
    }
}
