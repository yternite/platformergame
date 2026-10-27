using System;
using UnityEngine;

public class WindZone : MonoBehaviour
{
    private Rigidbody rb;
    public float windStrength;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Rigidbody rb =  other.GetComponent<Rigidbody>();
            rb.AddForce(Vector3.right * windStrength);
        }
    }
}
