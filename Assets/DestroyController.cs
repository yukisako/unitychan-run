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
			if( (cars[carCount].GetComponent<Transform>().position.z) < this.unitychan.GetComponent<Transform>().position.z){
				Destroy(cars[carCount]);
				carCount++;
			}

			if( (cones[coneCount].GetComponent<Transform>().position.z) < this.unitychan.GetComponent<Transform>().position.z){
				Destroy(cones[coneCount]);
				coneCount++;
			}

			if( (coins[coinCount].GetComponent<Transform>().position.z) < this.unitychan.GetComponent<Transform>().position.z){
				Destroy(coins[coinCount]);
				coinCount++;
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
	
