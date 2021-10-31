using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{

	[SerializeField]
	private GameObject holdUi;

	[SerializeField]
	private GameObject endOfRoundUi;

	[SerializeField]
	private GameObject betUi;

	[SerializeField]
	private GameObject splashUi;


	private List<GameObject> allUis;


	void Start() {
		allUis = new List<GameObject>{
			holdUi, endOfRoundUi, betUi, splashUi
		};
	}

	private void clear(){
		foreach(GameObject ui in allUis){
			ui.SetActive(false);
		}
	}

	public void ShowHoldUi(){
		clear();
		holdUi.SetActive(true);
	}

	public void ShowEndOfRoundUi(){
		clear();
		endOfRoundUi.SetActive(true);
	}

	public void SplashText(string text){
		splashUi.SetActive(true);
		Text splashText = splashUi.GetComponent<Text>();
		if(splashText != null){
			splashText.text = text;
		}
	}

	public void ShowBetUi(){
		clear();
		betUi.SetActive(true);
	}

}
