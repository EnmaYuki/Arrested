using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public Transform leftBoundary;
	public Transform rightBoundary;
	public float moveDist=1;
	public AudioClip moveSound;
	public AudioClip jumpSound;
	public LayerMask whatIsGround;

	float sideSpeed=5;
	float prevPos;

	Vector3 dest;
	AudioSource AS;
	Animator anim;
	Rigidbody rb;

	void Start () {
		AS = GetComponent<AudioSource>();
		anim = GetComponent<Animator>();
		rb = GetComponent<Rigidbody>();
		dest = transform.position;
	}

	void Update () {
		Touch touch;
		if (Input.touchCount ==1) {

			touch = Input.GetTouch(0);

			if (touch.phase == TouchPhase.Ended) {

				switch (SwipeDetector.direction) {
				case "left":
					dest.x -= moveDist;
					break;
				case "right":
					dest.x += moveDist;
					break;
				case "up":
					if (Physics.Raycast (transform.position + new Vector3 (0,0.1f, 0), Vector3.down, 0.3f)){ 
						rb.AddForce(Vector3.up*13, ForceMode.Impulse);
						anim.SetTrigger("jump");
						AS.PlayOneShot(jumpSound);
					}
					break;
				}

				dest.x = Mathf.Clamp (dest.x, leftBoundary.position.x, rightBoundary.position.x);

				if (prevPos != dest.x)
					AS.PlayOneShot(moveSound);
			}
		}

		dest.y = transform.position.y;
		dest.z = transform.position.z;
		transform.position = Vector3.MoveTowards (transform.position, dest, sideSpeed*Time.deltaTime);
		prevPos = transform.position.x;
	}
}
