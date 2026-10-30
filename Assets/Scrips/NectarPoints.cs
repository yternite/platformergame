using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;


public class NectarPoints : MonoBehaviour , IPickupable
{
    private bool collected;

    public void PickUp()
    {
        if (collected) return;
        collected = true;

        //referes to the player pick up without the hasstle 
            PlayerPickUp.Instance.AddPoints(1);
            Destroy(gameObject);
    }
}
