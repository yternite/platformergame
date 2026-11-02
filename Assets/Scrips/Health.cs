using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField] public float MaxHealth =  100f;
    [SerializeField] private float currentHealth = 100f;
    public UnityEvent OnDeath;
    public UnityEvent<float,float> OnHealthChange;
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

    public void Healh(float amount)
    {
        currentHealth += amount;
        //als de currentHealth > maxHealth
        //currenthealth = maxhealth
        OnHealthChange.Invoke(currentHealth, MaxHealth);
        // Tel op bij current health (niet boven max)
        // Fire OnHealthChanged met .Invoke();
    }
    
    
}
