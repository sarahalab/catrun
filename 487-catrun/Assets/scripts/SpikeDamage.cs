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
            collision.GetComponent<PlayerController>().Die();
            StartCoroutine(DelayedRespawn());
        }
    }
    public IEnumerator DelayedRespawn()
    {
        {
            yield return new WaitForSeconds(0.5f); 
            SceneManager.LoadScene(Respawn);
        }
    }
}