using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Spikes : MonoBehaviour
{
    public string currentLevel;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(collision.gameObject);
            StartCoroutine(WaitLoadScene());
        }

    }

    IEnumerator WaitLoadScene()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(currentLevel);
    }

}
