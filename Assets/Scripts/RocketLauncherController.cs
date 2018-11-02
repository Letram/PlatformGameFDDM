﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketLauncherController : MonoBehaviour {
    public float speed = 6f;
    public BombController bomb;
    private PlayerController player;
    private System.Boolean flipped;
    private bool hasParent;

    void Start()
    {
        flipped = false;
        hasParent = false;
    }
	// Update is called once per frame
	void Update () {
        if (hasParent)
        {
            gameObject.transform.position = new Vector2(player.gameObject.transform.position.x, player.gameObject.transform.position.y + 0.5f);
            Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            float alpha = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            if((90 <= alpha && alpha <= 180) || (-180 <= alpha && alpha <= -90))
            {
                if (!flipped)
                {
                    flipped = true;
                    transform.localScale = new Vector3(transform.localScale.x, -transform.localScale.y, transform.localScale.z);
                }
            }
            else
            {
                    flipped = false;
                    transform.localScale = new Vector3(transform.localScale.x, Mathf.Abs(transform.localScale.y), transform.localScale.z);
            }
            Quaternion rotation = Quaternion.AngleAxis(alpha, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, speed * Time.deltaTime);

            if (Input.GetKeyDown(KeyCode.G) || Input.GetButton("Fire1"))
            {
                Instantiate(bomb, transform.position, transform.rotation);
            }
        }
    }

    public void playerFlipped()
    {
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerBody"))
        {
            player = collision.GetComponentInParent<PlayerController>();
            hasParent = true;
            gameObject.GetComponent <CircleCollider2D>().enabled = false;
        }
    }
}