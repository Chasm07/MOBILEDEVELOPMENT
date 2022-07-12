using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemySideways : MonoBehaviour
{


    [SerializeField]
    private float damage;





    [Header("Movement parameters")]
    [SerializeField] private float speed;
    private Vector3 initScale;


    private void Awake()
    {
        initScale = transform.localScale;
    }

    private void Update()
    {
        MoveInDirection(-1);
    }

    private void MoveInDirection(int _direction)
    {
        transform.localScale = new Vector3(Mathf.Abs(initScale.x) * _direction,
            initScale.y, initScale.z);


        transform.position = new Vector3(transform.position.x + Time.deltaTime * _direction * speed,
            transform.position.y, transform.position.z);
    }




    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<Health>().TakeDamage(damage);
        }
         


    } 
}
