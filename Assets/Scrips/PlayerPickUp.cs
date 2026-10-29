using System;
using UnityEngine;

public class PlayerPickUp : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        /*in here it looks for something with the compontent that has
        Ipickupable adn then does the pickup function */
        IPickupable pickupable = other.GetComponent<IPickupable>();
        if (pickupable != null)
        {
            pickupable.PickUp();
        }
    } //if pickupble isnt nothing then itll sdo the pickup thing 
    //mmmm i understand 
}
