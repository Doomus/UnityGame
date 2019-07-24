using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerSanity : MonoBehaviour
{
    public float sanity = 100;

   //public AudioClip sound;
   //public AudioClip sound2;
   //
   //private AudioSource source;
    private float volLowRange = .1f;
    private float volHighRange = 1.0f;

    private float randomTime = 3.0f;

    private void Awake()
    {
        //source = GetComponent<AudioSource>();
    }

    public void loseSanity(float sanityLossAmount)
    {
        sanity -= sanityLossAmount * Time.deltaTime;
        float vol = Random.Range(volLowRange, volHighRange);
        //if (!source.isPlaying)
        //{
        //    source.PlayOneShot(sound, vol);
        //}
    }

    public void RandomSound()
    {

    }

    private void Update()
    {
        //Randomly play second sound
        //randomTime -= Time.deltaTime;
        //if(randomTime <= 0)
        //{
        //    if (!source.isPlaying)
        //    {
        //        source.PlayOneShot(sound2, 0.5f);
        //        randomTime = Random.Range(5.0f, 15.0f);
        //    }
        //}
    }
}
