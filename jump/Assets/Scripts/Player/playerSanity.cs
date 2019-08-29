using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerSanity : MonoBehaviour
{
    public float sanity = 100;

    private void Awake()
    {
    }

    public void loseSanity(float sanityLossAmount)
    {
        Debug.Log("losing sanity");
        sanity -= sanityLossAmount * Time.deltaTime;
    }

    public void RandomSound()
    {

    }

    private void Update()
    {
        
    }
}
