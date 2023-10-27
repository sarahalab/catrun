using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FishCollector : MonoBehaviour
{
    private int score = 0;

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
    }
}
