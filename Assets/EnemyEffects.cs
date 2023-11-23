using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class EnemyEffects : MonoBehaviour
{
    public Transform player;
    public Transform enemy1;
    public Transform enemy2;

    public PostProcessVolume postProcessVolume;
    private Vignette vg;

    public float distance;

    // Start is called before the first frame update
    void Start()
    {
        postProcessVolume = GetComponent<PostProcessVolume>();
        postProcessVolume.profile.TryGetSettings(out vg);
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(player.position, enemy1.position);

        if(distance <= 20)
        {
            vg.active = true;
            vg.intensity.value = Mathf.InverseLerp(0, 1, distance);
        }
    }
}
