using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpikeDamage : MonoBehaviour
{
    [SerializeField] private float damage;
    public int Respawn;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<Health>().TakeDamage(damage);
            StartCoroutine(DelayedRespawn(Respawn));
        }
    }
    private IEnumerator DelayedRespawn(int sceneIndex)
    {
        {
            yield return new WaitForSeconds(2.0f); // Waits 2 seconds to respawn the player
            SceneManager.LoadScene(sceneIndex);
        }
    }
}