using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
public class CardMover : MonoBehaviour
{

	[SerializeField]
	private float speed;


	private Vector3 targetPoint;
	public Vector3 TargetPoint{
		get{
			return targetPoint;
		}	
		set{
			targetPoint = value;
			GetComponent<Rigidbody2D>().velocity = (targetPoint - transform.position).normalized * speed;
		}
	}

	// Called once per frame to try and end the motion of the object
	//		if it is at its target point;
	// Returns if the target point has been reached
	public bool TryToFinish(){
		float distToTarget = (targetPoint - transform.position).sqrMagnitude; 
		if(distToTarget <= Mathf.Pow(speed * Time.deltaTime,2)){
			GetComponent<Rigidbody2D>().velocity = Vector3.zero;
			transform.position = targetPoint;
			return true;
		}
		return false;
	}

}
