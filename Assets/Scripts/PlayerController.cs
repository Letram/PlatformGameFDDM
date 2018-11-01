using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float maxSpeed = 5f;
	public float speed = 2f;
	public bool grounded;
	public float jumpPower = 6.5f;

	private Rigidbody2D rb2d;


    private Animator anim;
	private SpriteRenderer spr;
	private bool jump;
	private bool doubleJump;
    private int points;
    private bool movement = true;
    private bool invincible = false;
    private Vector3 spawnPoint;
    internal void SetSpawn(Vector3 spawn)
    {
        spawnPoint = spawn;
    }
    internal void earnPoints(int value)
    {
        points += value;
    }
    internal int GetScore()
    {
        return points;
    }

    // Use this for initialization
    void Start () {
		rb2d = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
		spr = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		anim.SetFloat("Speed", Mathf.Abs(rb2d.velocity.x));
		anim.SetBool("Grounded", grounded);

		if (grounded){
			doubleJump = true;
		}

		if (Input.GetKeyDown(KeyCode.UpArrow)){
			if (grounded){
				jump = true;
				doubleJump = true;
			} else if (doubleJump){
				jump = true;
				doubleJump = false;
			}
		}
	}

	void FixedUpdate(){

		Vector3 fixedVelocity = rb2d.velocity;
		fixedVelocity.x *= 0.75f;

		if (grounded){
			rb2d.velocity = fixedVelocity;
		}

		float h = Input.GetAxis("Horizontal");
		if (!movement) h = 0;

		rb2d.AddForce(Vector2.right * speed * h);

		float limitedSpeed = Mathf.Clamp(rb2d.velocity.x, -maxSpeed, maxSpeed);
		rb2d.velocity = new Vector2(limitedSpeed, rb2d.velocity.y);

		if (h > 0.1f) {
			transform.localScale = new Vector3(1f, 1f, 1f);
		} 

		if (h < -0.1f){
			transform.localScale = new Vector3(-1f, 1f, 1f);
		}

		if (jump){
			rb2d.velocity = new Vector2(rb2d.velocity.x, 0);
			rb2d.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
			jump = false;
		}

	}

    void OnBecameInvisible(){
        transform.position = spawnPoint;
        GetComponent<PlayerHealth>().ResetLife();
	}

	public void EnemyJump(){
		jump = true;
	}

        /*
         * values[0] -> enemy X position
         * values[1] -> damage dealt by the enemy
         * */
	public void EnemyKnockBack(float[] values){
		jump = true;

		float side = Mathf.Sign(values[0] - transform.position.x);
		rb2d.AddForce(Vector2.left * side * jumpPower, ForceMode2D.Impulse);
        if(!invincible)
            GetComponent<PlayerHealth>().DealDmg(values[1]);
		movement = false;
        invincible = true;
		Invoke("EnableMovement", 0.7f);

		Color color = new Color(255/255f, 106/255f, 0/255f);
		spr.color = color;
	}

	void EnableMovement(){
		movement = true;
        invincible = false;
		spr.color = Color.white;
	}

}
