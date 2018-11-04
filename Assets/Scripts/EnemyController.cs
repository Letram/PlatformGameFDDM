using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

	public float maxSpeed = 1f;
	public float speed = 1f;
    public AudioSource enemyAudio;
	private Rigidbody2D rb2d;

	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D>();
        enemyAudio = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		rb2d.AddForce(Vector2.right * speed);		
		float limitedSpeed = Mathf.Clamp(rb2d.velocity.x, -maxSpeed, maxSpeed);
		rb2d.velocity = new Vector2(limitedSpeed, rb2d.velocity.y);

		if (rb2d.velocity.x > -0.01f && rb2d.velocity.x < 0.01f){
			speed = -speed;
			rb2d.velocity = new Vector2(speed, rb2d.velocity.y);
		}

		if (speed < 0) {
			transform.localScale = new Vector3(1f, 1f, 1f);
		} else if (speed > 0){
			transform.localScale = new Vector3(-1f, 1f, 1f);
		}
	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.tag == "PlayerBody"){
			float yOffset = 0.4f;
			if (transform.position.y + yOffset < col.transform.position.y){
				col.GetComponentInParent<PlayerController>().SendMessage("EnemyJump");
                StartCoroutine(EnemyDead(col.GetComponentInParent<PlayerController>(), 100));
			} else {
                col.GetComponentInParent<PlayerController>().SendMessage("EnemyKnockBack", new float[] { transform.position.x, 20 });
			}
		}
        if (col.gameObject.CompareTag("Bomb"))
        {
            PlayerController player = GameObject.Find("Player").GetComponent<PlayerController>();
            col.gameObject.GetComponent<BombController>().bombAnimator.SetTrigger("Explode");
            StartCoroutine(EnemyDead(player, 50));
        }
	}

    public IEnumerator EnemyDead(PlayerController player, int pointAmount)
    {
        player.earnPoints(pointAmount);
        enemyAudio.Play();
        gameObject.transform.position = new Vector3(-999,-999,0);
        yield return new WaitForSeconds(enemyAudio.clip.length);
        Destroy(gameObject);
    }
}
