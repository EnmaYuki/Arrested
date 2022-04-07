using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DistanceCount : MonoBehaviour {

	Transform player;
	Text disText;
	Vector3 startPos;
	public static float distance;

	void Start () {
		player = GameObject.FindWithTag("Player").transform;
		disText = GetComponent<Text>();
		startPos = player.position;
	}
	
	void Update () {
		if (!PlayerLife.dead) {
			distance = Vector3.Distance(player.position, startPos);
			disText.text = distance.ToString("0000M");
		}
	}
}
