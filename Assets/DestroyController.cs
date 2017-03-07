using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyController : MonoBehaviour {

	//private GameObject carPrefab;
	private GameObject[] cars;
	private GameObject[] cones;
	private GameObject[] coins;
	private GameObject unitychan;
	int carCount = 0;
	int coneCount = 0;
	int coinCount = 0;

	// Use this for initialization
	void Start () {
		cars = GameObject.FindGameObjectsWithTag("CarTag");
		cones = GameObject.FindGameObjectsWithTag("TrafficConeTag");
		coins = GameObject.FindGameObjectsWithTag("CoinTag");
		unitychan = GameObject.Find ("unitychan");
	}
	
	// Update is called once per frame
	void Update () {
//		Debug.Log (this.unitychan.GetComponent<Transform> ().position.z);
//		foreach (GameObject car in cars) {
		//if (car.GetComponent<Renderer>().isVisible) {

		if ((carCount < cars.Length) && (cars [carCount] != null) && ((cars [carCount].GetComponent<Transform> ().position.z) < this.unitychan.GetComponent<Transform> ().position.z)) {
			Destroy (cars [carCount]);
			carCount++;
		}
	

		if( (coneCount < cones.Length) && (cones[coneCount] != null) && ((cones[coneCount].GetComponent<Transform>().position.z) < this.unitychan.GetComponent<Transform>().position.z)){
			if (cones [carCount] != null) {	
				Destroy (cones [coneCount]);
				coneCount++;
			}
		}

		if ((coinCount < coins.Length) && (coins[coinCount] != null) && ((coins [coinCount].GetComponent<Transform> ().position.z) < this.unitychan.GetComponent<Transform> ().position.z)) {
			if (coins [coinCount] != null) {
				Destroy (coins [coinCount]);
				coinCount++;
			}
		}


//		if (!this.gameObject.GetComponent<Renderer>().isVisible) {
//			Destroy (this.gameObject);
//		}
	}

	void OnTriggerEnter(Collider other){
		Debug.Log ("coin");
		if (other.gameObject.tag == "CoinTag") {
			coinCount++;
		}
	}

}
	
