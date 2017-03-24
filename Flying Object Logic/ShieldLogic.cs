using UnityEngine;
using System.Collections;

public class ShieldLogic : MonoBehaviour 
{

	void Start()
	{
		this.gameObject.transform.SetParent (GameObject.FindGameObjectWithTag("Player").transform);
		this.gameObject.transform.localPosition = Vector3.zero;
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if(col.gameObject.name == "Rock" || col.gameObject.name == "Rock(Clone)")
		{
			Destroy(col.gameObject);
			Destroy(this.gameObject);
		}
	}
}
