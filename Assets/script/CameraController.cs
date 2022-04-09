using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{

    public float moveSpeed = 20;
    public static float moveSpeed1 =0;
    public GameObject wave;
    public float waveSpeed = 0.1f;
    Material mat;

    public Transform dieCamPos;
    float stopSpeed = 5;

    void Start()
    {
        moveSpeed1 = moveSpeed;
        mat = wave.GetComponent<Renderer>().material;
    }

    void Update()
    {
        moveSpeed = moveSpeed1;
        if (!PlayerLife.dead)
        {
            float moveAmount = Time.deltaTime * moveSpeed;
            transform.Translate(Vector3.forward * moveAmount);
            MoveTexture(moveAmount);
        } else
        {
            Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, dieCamPos.position, stopSpeed * Time.deltaTime);
        }
    }

    void MoveTexture(float offsetY)
    {
        Vector2 offset = mat.mainTextureOffset;
        offset.y += offsetY * waveSpeed;
        mat.mainTextureOffset = offset;
    }
}