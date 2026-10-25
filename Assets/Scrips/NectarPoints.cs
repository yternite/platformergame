using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections.Generic;


public class NectarPoints : MonoBehaviour
{

    private int nectarPoints = 0;
    public TextMeshProUGUI scoreText;


    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            nectarPoints++;
            scoreText.text = "Nextar = " + nectarPoints.ToString();
            Destroy(gameObject);
        }
    }
}
