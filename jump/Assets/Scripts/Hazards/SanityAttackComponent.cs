using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SanityAttackComponent : MonoBehaviour
{
    public new Renderer renderer;
    public GameObject player;

    public CameraShake camShake;
    public float sanityLossAmount = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        //renderer = GetComponent<Renderer>();
        //player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (renderer.isVisible)
        {
            player.GetComponent<playerSanity>().loseSanity(sanityLossAmount);
            StartCoroutine(camShake.shake(0.15f, 0.4f));
        }
        if (!renderer.isVisible)
        {
            camShake.ResetPOS();
        }
    }
}
