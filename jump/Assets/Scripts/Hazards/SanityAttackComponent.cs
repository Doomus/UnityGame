using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SanityAttackComponent : MonoBehaviour
{
    public new Renderer renderer;
    public GameObject player;

    [Tooltip("Intensity of camera shake. keep between 0.1 and 0.2")]
    public float magnitude;

    [Tooltip("Duration in seconds of camera shake")]
    public float duration;

    public CameraShake camShake;

    [Tooltip("The amount of sanity take from the player each tick")]
    public float sanityLossAmount = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
       renderer = GetComponent<Renderer>();
       player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        //check if the object is rendering
        if (renderer.isVisible)
        {
            //check if player has unobstructed line of sight
            if (Physics.Linecast(transform.position, player.transform.position))
            {
                //apply camera shake and decrease sanity
                player.GetComponent<playerSanity>().loseSanity(sanityLossAmount);
                StartCoroutine(camShake.shake(duration, magnitude));
            }
        }
        if (!renderer.isVisible)
        {
            camShake.ResetPOS();
        }
    }
}
