using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class c_zeroGDeActive : MonoBehaviour
{
    

    private void OnTriggerEnter(Collider other)
    {

       
            other.GetComponent<Rigidbody>().useGravity = true;
        

        if (other.gameObject.tag == ("Player"))
        {
            other.GetComponentInChildren<CharacterControl>().isUsingGravity = true;
        }
        
    }
}

