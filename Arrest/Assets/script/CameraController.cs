using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{

    public float moveSpeed = 20;
    public GameObject wave;
    public float waveSpeed = 0.1f;
    Material mat;

    void Start()
    {
        mat = wave.GetComponent<Renderer>().material;
    }

    void Update()
    {
        float moveAmount = Time.deltaTime * moveSpeed;
        transform.Translate(Vector3.forward * moveAmount);
        MoveTexture(moveAmount);
    }

    void MoveTexture(float offsetY)
    {
        Vector2 offset = mat.mainTextureOffset;
        offset.y += offsetY * waveSpeed;
        mat.mainTextureOffset = offset;
    }
}