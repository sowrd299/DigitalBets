using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


// A class for managing a group of buttons with bets for different events
public class BetButtons : MonoBehaviour
{

	[SerializeField]
	private GameObject button;

	[SerializeField]
	private GameManager gameManager;

	[SerializeField]
	private Vector3 firstPos;

	[SerializeField]
	private Vector3 step;

	[SerializeField]
	private int[] betAmounts;


    void Start()
    {
		for(int i = 0; i < betAmounts.Length; i++) {
			GameObject newButton = Instantiate(button);
			newButton.transform.SetParent(transform);
			newButton.transform.position = transform.position + firstPos + step * i;
			newButton.GetComponentInChildren<Text>().text = betAmounts[i].ToString();
			int j = i; // Create an appropriately scoped copy
			newButton.GetComponent<Button>().onClick.AddListener(() => { 
				gameManager.PlaceBet(betAmounts[j]);
			});
		}
    }

}
