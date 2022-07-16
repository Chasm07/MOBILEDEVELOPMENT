using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    [SerializeField] 
    private float startingHealth;

    [SerializeField] 
    private GameManager gameManager;

    public float currentHealth { get; private set; }

    private bool dead;

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

            if (!dead)
            {
                GetComponent<Player>().enabled = false;
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                dead = true;
            }
            //anim
        }
    }
   
    public void AddHealth(float _value)
    {
        currentHealth = Mathf.Clamp(currentHealth + _value, 0, startingHealth);
    }
}
