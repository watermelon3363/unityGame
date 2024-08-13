using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed;
    public float a;
    public float b;
    public float c;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playermove = new Vector3 (a, b, c);
        transform.position = playermove * speed * Time.deltaTime;
        
        if (Input.GetKey(KeyCode.A))
        {
            a--;
           
        }
        if (Input.GetKey(KeyCode.D))
        {
            a++;
        }
        if (Input.GetKey(KeyCode.W))
        {
            c++;
        }
        if (Input.GetKey(KeyCode.S))
        {
            c--;
        }
    }
}
