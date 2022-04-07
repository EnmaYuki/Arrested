using UnityEngine;
using System.Collections;

public class TrackController : MonoBehaviour {

	public GameObject[] track;

	void OnTriggerEnter (Collider col) {
		if (col.CompareTag("Next")) {
			int select = Random.Range(0, track.Length);
			Instantiate(track[select], col.transform.position, col.transform.rotation);
		}
	}
}
