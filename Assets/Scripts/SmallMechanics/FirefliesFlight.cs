using UnityEngine;

public class FirefliesFlight : MonoBehaviour
{
    private Vector3 centerPoint;
    private float angle;
    private float speed;
    private float radius;

    void Start()
    {
        centerPoint = transform.position;

        angle = Random.Range(0f, 360f);

        speed = Random.Range(5f, 30f); 
        radius = Random.Range(1f, 2f); 
    }

    void Update()
    {
        angle += speed * Time.deltaTime;
        float rad = angle * Mathf.Deg2Rad;

        float x = Mathf.Cos(rad) * radius;
        float z = Mathf.Sin(rad) * radius;

        transform.position = centerPoint + new Vector3(x, 0f, z);
    }
}