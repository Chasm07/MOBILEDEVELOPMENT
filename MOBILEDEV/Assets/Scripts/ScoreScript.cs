using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreScript : MonoBehaviour
{

    public TextMeshProUGUI MyscoreText;
    private int ScoreNum;
    [SerializeField] private AudioClip collectSound;

    // Start is called before the first frame update
    void Start()
    {
        ScoreNum = 0;
        MyscoreText.text = "" + ScoreNum;
    }

    private void OnTriggerEnter2D(Collider2D Coin)
    {
        if (Coin.tag == "MyCoin")
        {
            ScoreNum += 1;
            Destroy(Coin.gameObject);
            SoundManager.instance.PlaySound(collectSound);
            MyscoreText.text = "" + ScoreNum;

        }

        if (Coin.tag == "MyPen")
        {
            ScoreNum += 5;
            Destroy(Coin.gameObject);
            SoundManager.instance.PlaySound(collectSound);
            MyscoreText.text = "" + ScoreNum;

        }
    }


}
