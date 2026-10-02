using System;
using UnityEngine;

public class EindeTrigger : MonoBehaviour
{
   public GameManager gameManager;
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
           gameManager.BeeindigSpel();
        }
    }
}

