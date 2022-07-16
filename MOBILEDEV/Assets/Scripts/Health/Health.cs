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
    private Animator anim;
    private bool dead;

    [SerializeField] 
    private float iFramesDuration;

    [SerializeField]
    private float numberOfFlashes;

    private SpriteRenderer spriteRend;

    private void Awake()
    {
        currentHealth = startingHealth;
        anim = GetComponent<Animator>();
        spriteRend = GetComponent<SpriteRenderer>();
    }
    // Start is called before the first frame update
    public void TakeDamage(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);
        

        if (currentHealth > 0)
        {
            //iframe
            anim.SetTrigger("hurt");
            StartCoroutine(Invulnerability());
        }
        else
        {

            if (!dead)
            {
                anim.SetTrigger("die");
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

    private IEnumerator Invulnerability()
    {
        Physics2D.IgnoreLayerCollision(10, 11, true);
        for(int i = 0; i < numberOfFlashes; i++)
        {
            spriteRend.color = new Color(1, 0, 0, 0.5f);
            yield return new WaitForSeconds(1);
            spriteRend.color = Color.white;
            yield return new WaitForSeconds(1);
        }
        Physics2D.IgnoreLayerCollision(10, 11, false);
    }
}
