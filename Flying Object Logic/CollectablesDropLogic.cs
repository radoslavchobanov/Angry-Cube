using UnityEngine;
using System.Collections;

public class CollectablesDropLogic : MonoBehaviour {

	public GameObject shieldCollectable;
	public GameObject rock;
	public float minSpawnX;
	public float maxSpawnX;
	public float spawnY;
	private float rockSpawnTimer = 0;
	private float ShieldSpawnTimer = 0;
	private float timeToDropRock;
	private float timeToDropShield;


	void Start()
	{
		timeToDropShield = Random.Range(5,10);
		timeToDropRock = Random.Range (4, 9);
	}

	void Update()
	{
		ShieldController ();
		RockController ();
	}

	private void ShieldController()
	{
		ShieldSpawnTimer += 1 * Time.deltaTime;

		if(ShieldSpawnTimer > timeToDropShield)
		{
			SpawnShield();
			ShieldSpawnTimer = 0;
		}
	}

	private void RockController()
	{
		rockSpawnTimer += 1 * Time.deltaTime;

		if(rockSpawnTimer > timeToDropRock)
		{
			SpawnRock();
			rockSpawnTimer = 0;
		}
	}

	private void SpawnShield()
	{
		Instantiate (shieldCollectable, new Vector3 (Random.Range(this.minSpawnX,this.maxSpawnX), this.spawnY, 0), Quaternion.Euler (0, 0, 0));
		timeToDropShield = Random.Range (10, 15);
	}

	private void SpawnRock()
	{
		Instantiate (rock, new Vector3 (Random.Range(this.minSpawnX,this.maxSpawnX), this.spawnY, 0), Quaternion.Euler (0, 0, 0));
		timeToDropRock = Random.Range (4, 9);
	}
}
