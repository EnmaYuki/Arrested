using UnityEngine;
using System.Collections;

public class PlayerLife : MonoBehaviour
{

	PlayerController control;
	CapsuleCollider capcol;
	Animator anim;
	AudioSource AS;
	public static bool dead;
	public GameObject deadCam;

	public AudioClip dieSound;

	public GameObject ResultMenu;

	void Start()
	{
		dead = false;
		control = GetComponent<PlayerController>();
		capcol = GetComponent<CapsuleCollider>();
		anim = GetComponent<Animator>();
		AS = GetComponent<AudioSource>();
	}

	void Update()
	{
		if (transform.position.y < -0.5f && !dead)
		{
			capcol.enabled = false;
			dead = true;
			AS.PlayOneShot(dieSound);
		}

		if (dead)
		{
			control.enabled = false;
			deadCam.transform.parent = null;
			ResultMenu.SetActive(true);
		}
	}

	void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.CompareTag("Obstacle"))
		{
			dead = true;
			anim.SetTrigger("die");
			AS.PlayOneShot(dieSound);
			transform.parent = null;
		}
		else if (col.gameObject.CompareTag("Enemy"))
		{
			dead = true;
			transform.parent = null;
			//win
			//WinMenu.SetActive(true);
			control.enabled = false;
			deadCam.transform.parent = null;
		}
	}
}