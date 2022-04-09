using UnityEngine;
using System.Collections;

public class CoinSpawner : MonoBehaviour {

	public GameObject soda;
	public Transform[] spawnPos;
	public float startDelay = 0;
	public float spawnInterval= 0.2f;

	float drawTime;
	int draw;

	void Start () {
		drawTime = 0;	
		InvokeRepeating ("Spawn", startDelay, spawnInterval);
	}

	void Update () {
		if (drawTime < Time.time) {
			draw = Random.Range(0, spawnPos.Length);
			drawTime = Time.time + Random.Range(0f,1f);
		}
	}

	void Spawn() {
		if (PlayerLife.dead)
			CancelInvoke("Spawn");
		Instantiate (soda, spawnPos[draw].position, transform.rotation = new Quaternion(17, -84, -19, 0));
	}
}
