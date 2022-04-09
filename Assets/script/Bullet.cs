
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;
    public float speed = 0f;
    public int prize = 100;
    public GameObject impactEffect;
    public void Seek(Transform _target)
    {
        target = _target;
    }
    
    void Update()
    {
        
        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if(dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }
        transform.Translate(dir.normalized * distanceThisFrame,Space.World);
    }
    void HitTarget()
    {
        GameObject effectIns =(GameObject)Instantiate(impactEffect,transform.position,transform.rotation);
        Destroy(effectIns, 2f);
        Destroy(target.gameObject);
       
        Destroy(gameObject);
    }
}
