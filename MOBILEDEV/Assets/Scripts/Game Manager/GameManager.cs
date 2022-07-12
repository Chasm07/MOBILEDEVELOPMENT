using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject Gameover;



    public void GameOver()
    {


        Gameover.SetActive(true);
        PauseTime();

    }

    public void PauseTime() => Time.timeScale = 0;


}