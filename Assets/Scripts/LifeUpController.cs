using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeUpController : MonoBehaviour {
    AudioSource audioSource;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        GameObject go = col.gameObject;
        if (go.CompareTag("PlayerBody"))
        {
            StartCoroutine(lifePicked(col.GetComponentInParent<PlayerHealth>()));
        }
    }
    public IEnumerator lifePicked(PlayerHealth playerHealth)
    {
        audioSource.Play();
        playerHealth.OneUp();
        gameObject.GetComponent<SpriteRenderer>().enabled = false; 
        yield return new WaitForSeconds(audioSource.clip.length);
        Destroy(gameObject);
    }
}
