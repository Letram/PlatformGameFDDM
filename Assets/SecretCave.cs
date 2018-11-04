using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecretCave : MonoBehaviour {
    private AudioSource audio;
    private bool entered;
	// Use this for initialization
	void Start () {
        audio = GetComponent<AudioSource>();
        entered = false;
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerBody"))
        {
            if(!entered)
                StartCoroutine(PlaySound());
        }
    }

    private IEnumerator PlaySound()
    {
        audio.Play();
        entered = true;
        yield return new WaitForSeconds(audio.clip.length);
    }
}
