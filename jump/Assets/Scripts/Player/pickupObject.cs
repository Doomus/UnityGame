using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickupObject : MonoBehaviour
{
    public GameObject target;
    public GameObject holdPOS;
    public GameObject player;

    // Update is called once per frame
    void Update()
    {
        if(target != null)
        {
            target.transform.position = holdPOS.transform.position;
            target.transform.rotation = holdPOS.transform.rotation;
        }
        if (Input.GetMouseButtonDown(0) && target != null)
        {
            Throw();
        }
    }
    public void Throw()
    {
        Rigidbody targetRB = target.GetComponent<Rigidbody>();
        targetRB.velocity = new Vector3(0.0f, 0.0f, 0.0f);
        targetRB.AddForce(player.transform.forward * 1000.0f);
        target = null;
    }
}
