using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class c_zeroGActive : MonoBehaviour
{
    

    private void OnTriggerEnter(Collider other)
    {
        
        
           
            other.GetComponent<Rigidbody>().useGravity = false;
        
        
        if (other.gameObject.tag == ("Player"))
        {
            other.GetComponentInChildren<CharacterControl>().isUsingGravity = false;
        }
    }
}

