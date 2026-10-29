using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections.Generic;


public class NectarPoints : MonoBehaviour , IPickupable
{

    public int Points = 0;
    public TextMeshProUGUI scoreText;

    public void PickUp()
    {
            Points++;
            scoreText.text = "Nextar = " + Points.ToString();
            Destroy(gameObject);
    }
}
