using System;
using UnityEngine;

public class WinnersTrigger : MonoBehaviour
{
    public GameManager gameManager;


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            gameManager.Winnerswin();
        }
    }
}
