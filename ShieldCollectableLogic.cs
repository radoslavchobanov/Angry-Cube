using UnityEngine;
using System.Collections;

public class ShieldCollectableLogic : MonoBehaviour {

	public GameObject shieldGO;
	public AudioClip shieldSound;

	void Start()
	{
		Destroy (this.gameObject, 6f);
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if(col.gameObject.tag == "Player")
		{
			AudioSource.PlayClipAtPoint(shieldSound, new Vector3(0,0,0));
			Instantiate(shieldGO);
			Destroy(this.gameObject);
		}
	}
}
