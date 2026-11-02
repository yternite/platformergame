using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;


public class NectarPoints : MonoBehaviour , IPickupable
{
    private bool collected;
    [SerializeField] private int amount;

    public void PickUp()
    {
        if (collected) return;
        collected = true;

        //referes to the player pick up without the hasstle 
            PlayerPickUp.Instance.AddPoints(amount);
            Destroy(gameObject);
    }
}
