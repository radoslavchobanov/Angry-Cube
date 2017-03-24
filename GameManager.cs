using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class GameManager : MonoBehaviour 
{
	private GameObject[] laserShooters;
	public static int score = 0;
	private float maxSpeed = 8f;
	public static bool isAlive;
	private Vector3 touchInput;
	private GameObject playerCube;
	public GameObject playerCubeI;
	private Rigidbody2D playerCubeRigid;
	private float speed;
	private GameObject canvas;
	private Vector3 startCutePos;
	private Quaternion startCuteRot;
	public int highScore;
	public TextMesh scoreText;


	void Start()
	{
		playerCube = GameObject.FindGameObjectWithTag ("Player");
		canvas = GameObject.Find ("Canvas");
		playerCubeRigid = playerCube.GetComponent<Rigidbody2D> ();
		laserShooters = GameObject.FindGameObjectsWithTag ("Laser");
		speed = 12000f;
		startCutePos = playerCube.transform.position;
		startCuteRot = playerCube.transform.rotation;
		Time.timeScale = 0;
	}
	
	void Update()
	{

		if (GameManager.isAlive == false || playerCubeRigid == null || scoreText == null)
			return;
		scoreText.text = "Score : " + GameManager.score;
		LaserHandler ();

		if(score == 0)
		{
			GravityReverser.NormalGravity();

//			if(Input.GetMouseButtonDown(0))
//			{
//				touchInput = Camera.main.ScreenToWorldPoint (Input.mousePosition);
//				if(touchInput.x > 0)
//				{
//					playerCubeRigid.AddForce(new Vector2(-1,-2) * speed * Time.deltaTime);
//				}
//				else if(touchInput.x <= 0)
//				{
//					playerCubeRigid.AddForce(new Vector2(1,-2) * speed * Time.deltaTime);
//				}
//			}

			if (Input.touches.Length > 0 && Input.GetTouch (0).phase == TouchPhase.Began) 
			{
				touchInput = Camera.main.ScreenToWorldPoint (Input.touches [0].position);
				if (touchInput.x > 0) 
				{
					playerCubeRigid.AddForce (new Vector2 (-1, -2) * speed * Time.deltaTime);
				} else if (touchInput.x <= 0) 
				{
					playerCubeRigid.AddForce (new Vector2 (1, -2) * speed * Time.deltaTime);
				}
			}
		}
		      
		else if (score / 10 % 2 == 0)
		{
			//gravity is 10
			GravityReverser.NormalGravity();

//			if(Input.GetMouseButtonDown(0))
//			{
//				touchInput = Camera.main.ScreenToWorldPoint (Input.mousePosition);
//				if(touchInput.x > 0)
//				{
//					playerCubeRigid.AddForce(new Vector2(-1,-2) * speed * Time.deltaTime);
//				}
//				else if(touchInput.x <= 0)
//				{
//					playerCubeRigid.AddForce(new Vector2(1,-2) * speed * Time.deltaTime);
//				}
//			}

			if (Input.touches.Length > 0 && Input.GetTouch (0).phase == TouchPhase.Began) 
			{
				touchInput = Camera.main.ScreenToWorldPoint (Input.touches [0].position);
				if (touchInput.x > 0) 
				{
					playerCubeRigid.AddForce (new Vector2 (-1, -2) * speed * Time.deltaTime);
				} else if (touchInput.x <= 0) 
				{
					playerCubeRigid.AddForce (new Vector2 (1, -2) * speed * Time.deltaTime);
				}
			}
		}
		else if (score / 10 % 2 != 0)
		{
			//gravity is -10
			GravityReverser.GravityReverse();

//			if(Input.GetMouseButtonDown(0))
//			{
//				touchInput = Camera.main.ScreenToWorldPoint (Input.mousePosition);
//				if(touchInput.x > 0)
//				{
//					playerCubeRigid.AddForce(new Vector2(-1,2) * speed * Time.deltaTime);
//				}
//				else if(touchInput.x <= 0)
//				{
//					playerCubeRigid.AddForce(new Vector2(1,2) * speed * Time.deltaTime);
//				}
//			}

			if (Input.touches.Length > 0 && Input.GetTouch (0).phase == TouchPhase.Began) 
			{
				touchInput = Camera.main.ScreenToWorldPoint (Input.touches [0].position);
				if (touchInput.x > 0) 
				{
					playerCubeRigid.AddForce (new Vector2 (-1, 2) * speed * Time.deltaTime);
				} else if (touchInput.x <= 0) 
				{
					playerCubeRigid.AddForce (new Vector2 (1, 2) * speed * Time.deltaTime);
				}
			}
		}

		if(playerCubeRigid.velocity.magnitude > maxSpeed)
		{
			playerCubeRigid.velocity = playerCubeRigid.velocity.normalized * maxSpeed;
		}


	}


	private void LaserHandler()
	{
		for (int i=0; i < laserShooters.Length; i++) 
		{
			if(laserShooters[i].GetComponent<LaserShooterLogic>().IsFiring)
			{
				return;
			}
		}


		int randomNumber = Random.Range(0, laserShooters.Length);
		laserShooters[randomNumber].GetComponent<LaserShooterLogic>().Fire();
	}
	
	public void OnPlayClick()
	{
		Time.timeScale = 1f;
		canvas.transform.FindChild ("Button").gameObject.SetActive (false);
	}
	
	public void OnReplayClick()
	{
		speed = 12000f;
		GameObject newCube = Instantiate (playerCubeI, startCutePos, startCuteRot) as GameObject;
		this.playerCube = newCube;
		this.playerCube.name = "PlayerSquare";
		this.playerCubeRigid = playerCube.GetComponent<Rigidbody2D> ();
		Time.timeScale = 1f;
		GameManager.isAlive = true;
		GameManager.score = 0;
		canvas.transform.FindChild ("ButtonRetry").gameObject.SetActive (false);
	}

	public void ReloadGame()
	{
		StartCoroutine (ReloadGameEnumerator ());
	}
	
	private IEnumerator ReloadGameEnumerator()
	{
		if(score > highScore)
		{
			highScore = score;
		}
		
		yield return new WaitForSeconds(2f);
		canvas.transform.FindChild ("ButtonRetry").gameObject.SetActive (true);
		canvas.transform.FindChild ("ButtonRetry").gameObject.transform.FindChild ("ScoreText").gameObject.GetComponent<Text> ().text = "High Score: " + highScore.ToString () + ", now : " + (GameManager.score-1).ToString ();
		Time.timeScale = 0f;
	}

}
