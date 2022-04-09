using UnityEngine;
using System.Collections;

public class Collect : MonoBehaviour {
	
	public AudioClip CoinSound;
	
	AudioSource AS;

	void Start () {
		AS = GetComponent<AudioSource>();
	}
	
	void OnTriggerEnter (Collider col) {
		if (col.CompareTag("Player")) {
			//CoinCount.UpdateCoin(1);
			AS.PlayOneShot(CoinSound);
			Destroy(gameObject);
			StartCoroutine(SpeedUp());
		}
	}
	private IEnumerator SpeedUp()
	{
		CameraController.moveSpeed1 = 100;
		yield return new WaitForSeconds(5.0f);
		CameraController.moveSpeed1 = 20;
	}
}
