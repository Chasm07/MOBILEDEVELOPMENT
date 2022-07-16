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

    [SerializeField] private Behaviour[] components;

    [SerializeField]
    private float numberOfFlashes;

    private SpriteRenderer spriteRend;

    [Header("Death Sound")]
    [SerializeField] private AudioClip deathSound;
    [SerializeField] private AudioClip hurtSound;

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

            SoundManager.instance.PlaySound(hurtSound);
        }
        else
        {

            if (!dead)
            {

                
                GetComponent<Player>().enabled = false;
                StartCoroutine(DelayRespawn());
                dead = true;
                anim.SetTrigger("die");
                SoundManager.instance.PlaySound(deathSound);
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

    private IEnumerator DelayRespawn()
    {
        yield return new WaitForSeconds(2);

        anim.SetTrigger("die");

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
