using UnityEngine;
using System.Collections;

public class RockLogic : MonoBehaviour 
{

	public AudioClip rockDestroySound;

	void Start()
	{
		Destroy (this.gameObject, 6f);
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if(col.gameObject.tag == "Player")
		{
			GameObject.Find("PlayerSquare").GetComponent<PlayerLogic>().KillCube();
		}
	}

	void OnDestroy()
	{
		AudioSource.PlayClipAtPoint (rockDestroySound, new Vector3(0,0,0));
	}
}
