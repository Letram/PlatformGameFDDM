using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombController : MonoBehaviour {

    private Rigidbody2D bombBody;
    private Animator bombAnimator;
    private Vector2 direction;
	// Use this for initialization
	void Start () {
        bombBody = GetComponent<Rigidbody2D>();
        bombAnimator = GetComponent<Animator>();
        direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        launch();
        Destroy(gameObject, 4f);
	}

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            bombBody.isKinematic = true;
            bombBody.velocity = new Vector2(0,0);
            bombAnimator.SetTrigger("Explode");
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
}
