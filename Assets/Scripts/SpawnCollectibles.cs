using System.Collections.Generic;
using UnityEngine;

public class SpawnCollectibles : MonoBehaviour
{
    public float ImpulseAmount = 5f;
    [SerializeField] private GameObject Collecetibles;

public void Spawn(int amount)
{
    GameObject newItem = Instantiate(Collecetibles,transform.position +  amount * Vector3.one * Random.Range(-0.1f,0.2f)
        ,transform.rotation);
    Rigidbody _rb = newItem.GetComponent<Rigidbody>();
    Vector3 RandomDir = new Vector3(Random.Range(-0.5f, 0.5f), 1f, Random.Range(-0.5f, 0.5f));
    _rb.AddForce(ImpulseAmount * RandomDir , ForceMode.Impulse);

    Vector3 randomRotate =
        new Vector3(Random.Range(-0.05f,0.05f), Random.Range(-0.05f,0.05f),0f);
    _rb.AddTorque(randomRotate,ForceMode.Impulse);

}


}
