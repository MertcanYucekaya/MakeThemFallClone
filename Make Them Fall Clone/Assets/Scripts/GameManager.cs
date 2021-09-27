using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public float speed;
    public float spawnAddedTime;
    public float speedAddedTime;
    float realTime = 0;
    public GameObject scoreOrDie;
    public GameObject[] spawnPointRight;
    public GameObject[] spawnPointLeft;
    float duration = 0;
    public Text[] scoreText;
    public Text bestScoreText;
    int random1;
    int random2;
    float spawnRandom1;
    float spawnRandom2;
    void Start()
    {
        if (!PlayerPrefs.HasKey("BestScore"))
        {
            PlayerPrefs.SetInt("BestScore",0);
        }
    }


    void Update()
    {
        if (Time.time > realTime)
        {
            realTime = Time.time + speedAddedTime;
            speed++;
        }
        if (Time.time > duration)
        {
            duration = Time.time + spawnAddedTime-speed/20;
            random1 = Random.Range(0, 2);
            random2 = Random.Range(0, 2);
            spawnRandom1= Random.Range(0, .3f);
            spawnRandom2 = Random.Range(0, .3f);
           
            
            StartCoroutine(spawn1());
            StartCoroutine(spawn2());

        }

        if (scoreText[1].enabled == true)
        {
            scoreText[1].text = scoreText[0].text;
        }
        if (bestScoreText.enabled == true)
        {
            int score = int.Parse(scoreText[1].text);
            if (score > PlayerPrefs.GetInt("BestScore"))
            {
                PlayerPrefs.SetInt("BestScore", score);
                bestScoreText.text = score.ToString();
            }
            else
            {
                bestScoreText.text = PlayerPrefs.GetInt("BestScore").ToString();
            }
        }

    }


    public void restartButton()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }

    IEnumerator spawn1()
    {
        yield return new WaitForSeconds(spawnRandom1);
        Instantiate(scoreOrDie, spawnPointRight[random1].transform.position, spawnPointRight[random1].transform.rotation);

    }
    IEnumerator spawn2()
    {
        yield return new WaitForSeconds(spawnRandom2);
        Instantiate(scoreOrDie, spawnPointLeft[random2].transform.position, spawnPointLeft[random2].transform.rotation);

    }
}
