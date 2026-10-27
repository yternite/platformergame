using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField] public float MaxHealth =  100f;
    [SerializeField] private float currentHealth = 100f;
    public UnityEvent OnDeath;
    //public UnityEvent<float,float> OnHealthChange;
    bool isDead = false;
    
    public void TakeDamage(float amount)
    {   
        currentHealth -= amount;
        //OnHealthChange.Invoke(currentHealth, MaxHealth);
        
        // Trek af van current health (niet onder 0)
        if (currentHealth < 0f && isDead == false)
        {
            OnDeath.Invoke();
            isDead = true;
        }
        
        // Als health gelijk is aan 0, roep de OnDeath event aan met .Invoke().
    }


    
    
}
