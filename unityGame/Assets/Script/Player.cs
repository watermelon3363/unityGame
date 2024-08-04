using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
    public CharacterController characterController;
    [SerializeField]
    public float speed; // 1프레임당 움직이는 것
    // Start is called before the first frame update

    public float a = 0f;
    public float b = 0f;
    public float c = 0f;
    
    void Start()
    {
        speed = 0.05f;
       

    }

    // Update is called once per frame
    void Update()
    {
        PlayerMove();
    }

    private void PlayerMove()
    {
        
        if (Input.GetKey(KeyCode.D))
        {
            a += speed * Time.deltaTime;
            transform.position = new Vector3(a, b, c);

        }

        if (Input.GetKey(KeyCode.A))
        {
            a -= speed * Time.deltaTime;
            transform.position = new Vector3(a, b, c);

        }

        if (Input.GetKey(KeyCode.W))
        {
            c += speed * Time.deltaTime;
            transform.position = new Vector3(a, b, c);

        }

        if (Input.GetKey(KeyCode.S))
        {
            c -= speed * Time.deltaTime;
            transform.position = new Vector3(a, b, c);

        }

        //float horizontalInput = Input.GetAxis("Horizontal");
        //float vertialInput = Input.GetAxis("vertical");
        //
        //Vector3 movevecter = new Vector3(horizontalInput, 0, vertialInput);
        //
        //characterController.SimpleMove(movevecter * speed);

    }
}
