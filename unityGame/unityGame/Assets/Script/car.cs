using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Jobs;


public class car : MonoBehaviour
{
    public float speed;
    public Vector3 StartPosition;
    // Start is called before the first frame update
    void Start()
    {
        StartPosition = transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position - transform.right * speed * Time.deltaTime;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Wall"))
        {
            transform.position = StartPosition;
        }
    }
}
