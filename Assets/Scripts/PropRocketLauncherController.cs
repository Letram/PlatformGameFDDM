using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropRocketLauncherController : MonoBehaviour {
    public RocketLauncherController rocketLauncher;
    public BombController bomb;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerBody"))
        {
            RocketLauncherController rl = Instantiate(rocketLauncher, collision.gameObject.transform);
            BombController bc = Instantiate(bomb, rocketLauncher.transform);

            rl.bomb = bc;

            Destroy(gameObject);
        }
    }
}
