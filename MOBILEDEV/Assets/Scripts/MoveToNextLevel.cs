using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MoveToNextLevel : MonoBehaviour
{
    public int nextSceneLoad;
    [SerializeField] private AudioClip teleportSound;
    [SerializeField] private GameObject Gameover;


    // Start is called before the first frame update
    void Start()
    {
        nextSceneLoad = SceneManager.GetActiveScene().buildIndex + 1;
        SoundManager.instance.PlaySound(teleportSound);
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (SceneManager.GetActiveScene().buildIndex == 11) /* < Change this int value to whatever your
                                                                   last level build index is on your
                                                                   build settings */
            {
                Debug.Log("You Completed ALL Levels");
                Gameover.SetActive(true);
                PauseTime();
                //Show Win Screen or Somethin.
            }
            else
            {
                //Move to next level
                SceneManager.LoadScene(nextSceneLoad);


                //Setting Int for Index
                if (nextSceneLoad > PlayerPrefs.GetInt("levelAt"))
                {
                    PlayerPrefs.SetInt("levelAt", nextSceneLoad);
                }
            }
        }
    }
    public void PauseTime() => Time.timeScale = 0;
}
