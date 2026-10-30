using System;
using UnityEngine;
using TMPro;

public class PlayerPickUp : MonoBehaviour
{
    public SoundManager soundManager;
    public static int Points = 0;
    public TextMeshProUGUI scoreText;
    public static PlayerPickUp Instance;

    void Start()
    {
        scoreText.text = "Nextar = " + Points.ToString();
    } 
    
    void Awake()
    {
        Instance = this;
    }

    private void OnTriggerEnter(Collider other)
    {
       //zoekt of "other" een component heeft met de interface, 
        IPickupable pickupable = other.GetComponent<IPickupable>();
        //als het wel een pickupable heeft dan doet ie wat er in de pickup functie zit
        if (pickupable != null)
        {
            pickupable.PickUp();
            soundManager.SpeelCollect();
        }
    } 
    public void AddPoints(int amount)
         {
             //voegt de punten toe aan de string
             Points += amount;
             scoreText.text = "Nextar = " + Points.ToString();
             
         }

}
