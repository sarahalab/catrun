using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FishCollector : MonoBehaviour
{
    private float score = 0;
    private bool startScoreCounter = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            startScoreCounter = true; 
        }
        if (startScoreCounter == true)
        {
            score += 100f * (Time.deltaTime);
            fishScore.text = "Score: " + Mathf.Round(score);
        }
    }

    [SerializeField] private Text fishScore;
    [SerializeField] private AudioSource collectionSoundEffect;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Goldfish"))
        {
            collectionSoundEffect.Play();
            Destroy(collision.gameObject);
            score += 1000;
            fishScore.text = "Score: " + score;
        }
        if (collision.gameObject.CompareTag("FinishLine"))
        {
            startScoreCounter = false;
        }
    }
}
