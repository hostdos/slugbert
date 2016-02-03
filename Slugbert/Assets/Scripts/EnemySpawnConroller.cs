using UnityEngine;
using System.Collections;

public class EnemySpawnConroller : MonoBehaviour {

	public GameObject enemy;

	public float spawnTime = 2f;



	// Use this for initialization
	void Start () {

		InvokeRepeating ("spawnEnemy", spawnTime, spawnTime);
	
	}

	void spawnEnemy() {

	
		Instantiate (enemy, transform.position, transform.rotation);



	}

	// Update is called once per frame
	void Update () {
	
	}
}
