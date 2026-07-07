using UnityEngine;

public class LazerMove : MonoBehaviour
{
    public float speed = 300f;
    public float lifeTime = 2f;
    //public Transform targetObject;

    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        float step = speed * Time.deltaTime;
        //transform.position = Vector3.MoveTowards(transform.position, targetObject.position, step);
    }
}