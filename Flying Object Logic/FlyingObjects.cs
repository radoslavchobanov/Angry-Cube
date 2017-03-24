using UnityEngine;
using System.Collections;

public class FlyingObjects : MonoBehaviour 
{
	private float speed;

	void Start () 
	{
		speed = 3f;
	}

	void Update () 
	{
		this.gameObject.transform.Translate(new Vector3(0,-1f,0) * Time.deltaTime * speed);
	}
}
