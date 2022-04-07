using UnityEngine;
using System.Collections;

public class TrackRemover : MonoBehaviour {

	void OnTriggerEnter (Collider col) {
		if (col.CompareTag("Next")) {
			Destroy(col.transform.parent.gameObject);
		}
	}
}
