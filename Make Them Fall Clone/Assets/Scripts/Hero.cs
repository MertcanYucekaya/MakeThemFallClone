using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hero : MonoBehaviour
{
    Animator animator;
    bool isRight = true;
    public Text scoreText;
    int score = 0;
    public GameObject scoreCanvas;
    void Start()
    {
        animator = GetComponent<Animator>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Thorn"))
        {
           Time.timeScale = 0;
           scoreCanvas.SetActive(true);
        }
        if (collision.transform.CompareTag("Score"))
        {
            score++;
            scoreText.text = score.ToString();
        }
    }

    public void wayChange()
    {
        if (isRight)
        {
            animator.Play("Right");
            isRight = false;
        }
        else
        {
            animator.Play("Left");
            isRight = true;
        }
    }
}
