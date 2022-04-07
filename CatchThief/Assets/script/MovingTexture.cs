using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingTexture : MonoBehaviour {

    Material mat;
    public Vector2 speed;

    void Start () {
        mat = GetComponent<Renderer>().material;	
	}
	
	void Update () {
        Vector2 offset = mat.mainTextureOffset;
        offset.x += speed.x*Time.deltaTime;
        offset.y += speed.y*Time.deltaTime;
        mat.mainTextureOffset = offset;
	}
}
