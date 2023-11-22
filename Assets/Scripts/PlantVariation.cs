using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantVariation : MonoBehaviour
{
    public float maxHeight;
    public float minHeight;

    public float maxRot;
    public float minRot;

    void Start()
    {
        transform.Rotate(0, transform.rotation.y + Random.Range(minRot, maxRot), 0);

        float sizefloat = Random.Range(minHeight, maxHeight);
        transform.localScale += new Vector3(sizefloat, sizefloat, sizefloat);
    }
}
