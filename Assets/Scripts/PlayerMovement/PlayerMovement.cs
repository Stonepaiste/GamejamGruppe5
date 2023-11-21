using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
///Kode inspireret af https://www.youtube.com/watch?v=_QajrabyTJc 
    public CharacterController controller;

    public float speed = 12f;

    public float gravity = -9.81f;
    Vector3 velocity;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z; //går i den retning som playeren kigger
    
        controller.Move(move * speed * Time.deltaTime);
    
    //gravity
    //vi sætter vores velocity på y axen og giver den en force som er "gravity"
        velocity.y = gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }
}
