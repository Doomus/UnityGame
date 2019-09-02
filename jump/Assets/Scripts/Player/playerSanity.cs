using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerSanity : MonoBehaviour
{
    public float sanity = 100;
    public Material postprocessMaterial;
    public GameObject cam;
    public VisionBlur camVisionBlur;
    public float sanityMultiplier;

    private void Awake()
    {
        camVisionBlur = cam.GetComponent<VisionBlur>();
    }

    public void loseSanity(float sanityLossAmount)
    {
        //Debug.Log("losing sanity");
        sanity -= sanityLossAmount * Time.deltaTime;
    }

    public void GainSanity(float sanityGainAmount)
    {
        Debug.Log("Regained sanity");
        sanity += sanityGainAmount;
    }

    private void Update()
    {
       if (sanity >= 99)
       {
           camVisionBlur.blurSize = 0;
           StopCoroutine(BlurIntensity());
       }
       if (sanity < 99)
       {
           StartCoroutine(BlurIntensity());
           //camVisionBlur.blurSize = 0.5f - (sanity / 100f);
       }
    }

    IEnumerator BlurIntensity()
    {
        camVisionBlur.blurSize = Mathf.Sin(Time.time) * sanityMultiplier;
        yield return null;
        //print("WaitAndPrint " + Time.time);
    }

}
