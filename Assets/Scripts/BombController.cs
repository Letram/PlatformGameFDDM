using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombController : MonoBehaviour {

    public Animator bombAnimator;
    private Rigidbody2D bombBody;
    private Vector2 direction;
    private AudioSource audio;
    private bool explode;
	// Use this for initialization
	void Start () {
        audio = GetComponent<AudioSource>();
        bombBody = GetComponent<Rigidbody2D>();
        bombAnimator = GetComponent<Animator>();
        direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        launch();
	}

    void OnCollisionEnter2D(Collision2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Ground":
                bombBody.velocity = new Vector2(0, 0);
                bombAnimator.SetTrigger("Explode");
                break;
        }
        
        
    }
    public void launch()
    {
        bombBody.AddForce(direction, ForceMode2D.Impulse);
    }
    private void destroy()
    {
        Destroy(gameObject);
    }

    private void PlaySound()
    {
        if(gameObject != null)
            audio.Play();
    }

}
