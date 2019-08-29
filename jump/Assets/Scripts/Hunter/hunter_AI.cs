using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Hunter_AI : MonoBehaviour
{
    public float lookRadius = 10f;
    public float moveSpeed = 10f;
    public float rotSpeed = 100f;

    private bool isWandering;
    private bool isRotatingLeft;
    private bool isRotatingRight;
    private bool isWalking;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(isWandering == false)
        {
            StartCoroutine(Wander());
        }

        if(isRotatingRight == true)
        {
            transform.Rotate(transform.up * Time.deltaTime * rotSpeed);
        }
        if (isRotatingLeft == true)
        {
            transform.Rotate(transform.up * Time.deltaTime * -rotSpeed);
        }
        if(isWalking == true)
        {
            transform.position += transform.forward * moveSpeed *Time.deltaTime;
        }
    }

    IEnumerator Wander()
    {
        int rotTime = Random.Range(1, 3);
        int rotWait = Random.Range(1, 2);
        int rotLeftRight = Random.Range(0, 3);
        int roamWait = Random.Range(1, 2);
        int roamTime = Random.Range(1, 5);

        isWandering = true;

        yield return new WaitForSeconds(roamWait);
        isWalking = true;
        yield return new WaitForSeconds(roamTime);
        isWalking = false;
        yield return new WaitForSeconds(rotWait);
        if(rotLeftRight == 1)
        {
            isRotatingRight = true;
            yield return new WaitForSeconds(rotTime);
            isRotatingRight = false;
        }
        if (rotLeftRight == 2)
        {
            isRotatingLeft = true;
            yield return new WaitForSeconds(rotTime);
            isRotatingLeft = false;
        }
        isWandering = false;

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}
