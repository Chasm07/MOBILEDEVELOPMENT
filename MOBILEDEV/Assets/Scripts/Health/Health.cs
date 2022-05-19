using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] 
    private float startingHealth;

    public float currentHealth { get; private set; }

    private void Awake()
    {
        currentHealth = startingHealth;
    }
    // Start is called before the first frame update
    public void TakeDamage(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);
        

        if (currentHealth > 0)
        {
            //iframe
        }
        else
        {
            //anim
        }
    }
   
    public void AddHealth(float _value)
    {
        currentHealth = Mathf.Clamp(currentHealth + _value, 0, startingHealth);
    }
}
