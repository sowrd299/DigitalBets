using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardPositions : MonoBehaviour
{

	[SerializeField]
	Vector3 step;


	public Vector3 GetPosition(int i){
		return transform.position + step * i;
	}


}
