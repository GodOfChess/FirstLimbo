using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterTrigger : MonoBehaviour
{
    private float power= 50f;
    private float speed = 5f;
    private void OnTriggerStay(Collider col)
    {
        if (col.tag == "physical")
        {
            col.GetComponent<Rigidbody>().AddForce(transform.up * power);
        }

        if (col.tag == "Player")
        {
            col.GetComponent<Rigidbody>().AddForce(transform.up * power);
            if (Input.GetKey(KeyCode.Space))
            {
                transform.Translate(0, speed * Time.deltaTime, 0);
            }
        }
    }
}
