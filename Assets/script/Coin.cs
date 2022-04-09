using UnityEngine;
using System.Collections;

public class Coin : MonoBehaviour {

	public float rotSpeed=360;
	public float destroyDelay = 10;

	void Start () {
		Destroy(gameObject, destroyDelay);
	}

	void Update () {
		transform.Rotate (Vector3.up*rotSpeed*Time.deltaTime, Space.World);
	}
}

