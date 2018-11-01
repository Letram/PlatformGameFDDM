using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour {

    public int value;
    private AudioSource audio;
	// Use this for initialization
	void Start () {
        audio = gameObject.GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        GameObject go = col.gameObject;
        if (go.CompareTag("PlayerBody"))
        {
            StartCoroutine(playSound());
            col.GetComponentInParent<PlayerController>().earnPoints(value);
        }
    }

    private IEnumerator playSound()
    {
        audio.Play();
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        yield return new WaitForSeconds(audio.clip.length);
        Destroy(gameObject);
    }
}
