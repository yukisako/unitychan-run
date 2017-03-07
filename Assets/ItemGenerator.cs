using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour {

	public GameObject carPrefab;
	public GameObject coinPrefab;
	public GameObject conePrefab;
	public GameObject unitychan;
	private int startPos = -160;
	private int goalPos = 120;
	private int firstPos = -100;
	private float posRange = 3.4f;

	private float delta = 0;
	int i;

	// Use this for initialization
	void Start () {
		this.unitychan = GameObject.Find ("GameResultText");
		for (i = startPos; i < firstPos ; i += 15){
			GenerateItem (i);
		}

	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log (i);
		this.delta += Time.deltaTime;
		if (this.delta > 1.0f) {
			if ( i < goalPos ){
				this.delta = 0;
				GenerateItem (i);
				i += 15;
			}
		}
	}

	void GenerateItem(int i){
		int num = Random.Range (1, 10);
		if (num <= 1){
			for (float j = -1; j <= 1; j += 0.4f){
				GameObject cone = Instantiate (conePrefab) as GameObject;
				cone.transform.position = new Vector3(4*j, cone.transform.position.y, i);
			}
		} else {
			for(int j = -1; j<2;j++){
				int item = Random.Range(1,11);
				int offsetZ = Random.Range(-5,6);
				//60%コイン,30%車,10%なにもなし
				if (1<=item && item <= 6){
					GameObject coin = Instantiate (coinPrefab) as GameObject;
					coin.transform.position = new Vector3(posRange * j, coin.transform.position.y, i + offsetZ);
				} else if (7<= item && item <= 9){
					GameObject car = Instantiate (carPrefab) as GameObject;
					car.transform.position = new Vector3(posRange * j, car.transform.position.y, i+offsetZ);
				}
			}
		}
	}

}
