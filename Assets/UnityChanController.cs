using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UnityChanController : MonoBehaviour {

	private Animator myAnimator;
	private Rigidbody myRigidBody;
	private float forwardForce = 800.0f;

	private float turnForce = 500.0f;
	private float upForce = 500.0f;
	private float movableRange = 3.4f;

	private float coefficient = 0.95f;
	private bool isEnd = false;

	private bool isLButtonDown = false;
	private bool isRButtonDown = false;

	int score = 0;

	private GameObject stateText;
	private GameObject scoreText;

	// Use this for initialization
	void Start () {
		this.myAnimator = GetComponent<Animator> ();
		this.myAnimator.SetFloat ("Speed", 1.0f);

		this.myRigidBody = GetComponent <Rigidbody> ();
		this.stateText = GameObject.Find ("GameResultText");
		this.scoreText = GameObject.Find ("ScoreText");
	}


	
	// Update is called once per frame
	void Update () {
		this.myRigidBody.AddForce (this.transform.forward * forwardForce);

		if ((Input.GetKey (KeyCode.LeftArrow) || this.isLButtonDown) && -this.movableRange < this.transform.position.x) {
			this.myRigidBody.AddForce (-this.turnForce, 0, 0);
		} else if ((Input.GetKey (KeyCode.RightArrow)||this.isRButtonDown) && this.movableRange > this.transform.position.x) {
			this.myRigidBody.AddForce (this.turnForce, 0, 0);
		} 

		if (this.myAnimator.GetCurrentAnimatorStateInfo (0).IsName ("Jump")) {
			this.myAnimator.SetBool ("Jump", false);
		}

		if (Input.GetKey (KeyCode.UpArrow) && this.transform.position.y < 0.5f) {
			this.myAnimator.SetBool ("Jump", true);
			this.myRigidBody.AddForce (0, this.turnForce, 0);
		}

		//ゲーム終了ならUnityちゃんの動きを減衰
		if (this.isEnd) {
			this.forwardForce *= this.coefficient;
			this.turnForce *= this.coefficient;
			this.upForce *= this.coefficient;
			this.myAnimator.speed *= this.coefficient;
		}
	}

	void OnTriggerEnter(Collider other){
		
		if (other.gameObject.tag == "CarTag" || other.gameObject.tag == "TrafficConeTag") {
			this.isEnd = true;
			this.coefficient = 0.7f;
			this.stateText.GetComponent<Text> ().text = "GAME OVER";
		}

		if (other.gameObject.tag == "GoalTag") {
			this.isEnd = true;
			this.stateText.GetComponent<Text> ().text = "CLEAR!!";
		}
		if (other.gameObject.tag == "CoinTag") {
			this.score += 10;
			this.scoreText.GetComponent<Text> ().text = "Score " + this.score + "pt";
			GetComponent<ParticleSystem> ().Play ();
			Destroy (other.gameObject);

		}
	}

	public void GetMyJumpButtonDown(){
		Debug.Log ("ok");
		if (this.transform.position.y < 0.5f) {
			this.myAnimator.SetBool ("Jump", true);
			this.myRigidBody.AddForce (0, this.turnForce, 0);
		}
	}

	public void GetMyLeftButtonDown(){
		this.isLButtonDown = true;
	}

	public void GetMyRightButtonDown(){
		this.isRButtonDown = true;
	}

	public void GetMyLeftButtonUp(){
		this.isLButtonDown = false;
	}

	public void GetMyRightButtonUp(){
		this.isRButtonDown = false;
	}
}