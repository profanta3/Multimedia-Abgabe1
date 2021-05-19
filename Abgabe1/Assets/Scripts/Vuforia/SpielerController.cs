using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpielerController : MonoBehaviour
{
    [SerializeField]
    private float _Speed = 2;
    private Vector3 direction;
    private Vector3 rotation;
    private Transform _Player;
    // Start is called before the first frame update
    void Start()
    {
        _Player = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += (direction * _Speed * Time.deltaTime);
        transform.rotation *= Quaternion.Euler(rotation);
    }

    public void Move(Vector3 dir)
    {
        direction = dir;
    }

    public void Rotate(Vector3 rot)
    {
        rotation = rot;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Collectable"))
        {
            Debug.Log("Coin touched");
            Destroy(collision.gameObject);
        }
        else
        {
            Debug.Log("wrong object touched... TAG: "+collision.gameObject.tag);
            
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Collectable"))
        {
            Debug.Log("Coin touched");
            Destroy(collision.gameObject);
        }
        else
        {
            Debug.Log("wrong object touched... TAG: " + collision.gameObject.tag);

        }
    }
}
