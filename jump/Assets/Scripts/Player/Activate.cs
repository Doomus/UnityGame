using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activate : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(InputManager.inputManager.activate))
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 3.0f))
            {
                if (hit.collider.gameObject.GetComponent<Interactable>() != null)
                {

                    Interactable interactable = hit.collider.gameObject.GetComponent<Interactable>();
                    interactable.Interact();
                   
                }
            }
        }
    }
}
