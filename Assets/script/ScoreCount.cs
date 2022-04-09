using UnityEngine;
using System.Collections;

public class ScoreCount : MonoBehaviour {

	public static float score;
	public static float highScore;

	void Start () {
		score = 0;
		highScore = PlayerPrefs.GetFloat("Data_highScore", 0);
	}
	
	void Update () {
		//if (!PlayerLife.dead)
			//score = Mathf.Round(DistanceCount.distance * Mathf.Max(CoinCount.coins*0.1f,1));
		if (score > highScore)
        {
			highScore = score;
			PlayerPrefs.SetFloat("Data_highScore", highScore);
			PlayerPrefs.Save();
		}
	}
}
