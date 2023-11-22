using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantVariation : MonoBehaviour
{
    public float maxHeight;
    public float minHeight;

    public float maxRot;
    public float minRot;

    void Awake()
    {
        transform.Rotate(0, Random.Range(minRot, maxRot), 0);

        float sizefloat = Random.Range(minHeight, maxHeight);
        transform.localScale += new Vector3(sizefloat/2, sizefloat, sizefloat/2);

    }
}
