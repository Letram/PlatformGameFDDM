using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerController : MonoBehaviour {
    public GameObject player;
	// Use this for initialization
	void Start () {
        player.GetComponent<PlayerController>().SetSpawn(Vector3.zero);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
