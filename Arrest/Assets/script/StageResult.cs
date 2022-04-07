using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StageResult : MonoBehaviour {

	public Text distance;
	public Text coin;
	public Text score;
	public Text highScore;

	void Start () {
		distance.text = DistanceCount.distance.ToString(".00 M");;
		coin.text = CoinCount.coins.ToString();
		score.text = ScoreCount.score.ToString(); 
		highScore.text = ScoreCount.highScore.ToString();
	}

	public void Restart () {
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

	public void Quit () {
		SceneManager.LoadScene("title");
	}
}
