using UnityEngine;
using System.Collections;

public class SwipeDetector : MonoBehaviour {
	private Touch initialTouch = new Touch();
	private float distance = 0;
	private bool hasSwiped = false;
	public float sensitivity = 50;
	public static string direction;

	void Start () {
		direction=null;
	}

	void Update() {

		foreach(Touch t in Input.touches) {
			
			if (t.phase == TouchPhase.Began) {
				initialTouch = t;
			}
			else if (t.phase == TouchPhase.Moved && !hasSwiped) {
				
				float deltaX = initialTouch.position.x - t.position.x;
				float deltaY = initialTouch.position.y - t.position.y;
				distance = Mathf.Sqrt((deltaX * deltaX) + (deltaY * deltaY));
				bool swipedSideways = Mathf.Abs(deltaX) > Mathf.Abs(deltaY);

				if (distance > sensitivity) {
					if (swipedSideways && deltaX > 0) //swiped left
					{
						print ("left");
						direction = "left";
					}
					else if (swipedSideways && deltaX <= 0) //swiped right
					{
						print ("right");
						direction = "right";
					}
					else if (!swipedSideways && deltaY > 0) //swiped down
					{
						print ("down");
						direction = "down";
					}
					else if (!swipedSideways && deltaY <= 0)  //swiped up
					{
						print ("up");
						direction = "up";
					}

					hasSwiped = true;
				}

			}
			else if (t.phase == TouchPhase.Ended) {
				initialTouch = new Touch();
				hasSwiped = false;
			}
		}
	}
}
