using UnityEngine;
using UnityEngine.SceneManagement;

public class OutOfBounds : MonoBehaviour
{
    [SerializeField] private float boundary = -5.0f; // the value we will use for Y
    [SerializeField] private float fallDamage;
    private Vector3 initialPosition;

    private Health playerHealth;
    private SpikeDamage spikeDamage;
    [SerializeField] private AudioSource drownSoundEffect;

    private void Start()
    {
        initialPosition = transform.position;
        playerHealth = GetComponent<Health>();
        spikeDamage = FindObjectOfType<SpikeDamage>();
    }

    // Update is called once per frame
    private void Update()
    {
        
            CheckOffMap();
    }

    
    private void CheckOffMap()
    {
        if (transform.position.y < boundary)
        {
            //drownSoundEffect.Play();
            playerHealth.TakeDamage(fallDamage);
            StartCoroutine(spikeDamage.DelayedRespawn());
        }
    }
}
