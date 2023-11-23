using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneWayCollider : MonoBehaviour
{
    public Transform player;
    private Collider coll;

    private void Start()
    {
        coll = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.position.x > this.transform.position.x)
            coll.enabled = false;
        
        else
            coll.enabled = true;

    }
}
