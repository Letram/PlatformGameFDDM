using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaMovil : MonoBehaviour {

	public Transform target;
	public float speed;
    private Vector3 from, to, targetPos;
	// Use this for initialization
	void Start () {
        from = transform.position;
        to = target.position;
        targetPos = to;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate(){
        float fixedSpeed = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, targetPos, fixedSpeed);
        if (transform.position == targetPos)
        {
            targetPos = (targetPos == from) ? to : from;
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawLine(from, targetPos);
        Gizmos.DrawSphere(from, 0.15f);
        Gizmos.DrawSphere(targetPos, 0.15f);
    }

}
