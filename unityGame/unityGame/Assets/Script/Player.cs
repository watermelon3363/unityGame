using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class Player : MonoBehaviour
{
    public CharacterController characterController;
    [SerializeField]
    public float speed; // 1�����Ӵ� �����̴� ��
    // Start is called before the first frame update
    public Vector3 StartPosition; 

    public float timestart; // ����
    private float timeupdate;
    public float a;
    public float b;
    public float c;
    void Start()
    {
        speed = 1f;
        timestart = 0.0f;
        timeupdate = 3.0f;
        StartPosition = transform.position;
        Debug.Log(StartPosition);
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMove();
       
        Speed_Time();
    }


   
    private void Speed_Time()
    {
        timestart += Time.deltaTime; //timestart�� 0, timestar�� Time.deltaTime�� ������. == �ð��� �帧.

        if (timestart > timeupdate) // timeupdate�� 3.0, 3.0�� ������ player�� �ӵ��� 1f�� ������. // timestart�� �ٽ� 0.0f�� ������� 
        {
            speed = 1f;
            timestart = 0.0f;
        }
    }

    private void PlayerMove()
    {

        if (Input.GetKey(KeyCode.D))
        {
            a -= speed * Time.deltaTime;
            transform.position += new Vector3(a, b, c);

        }

        if (Input.GetKey(KeyCode.A))
        {
            a += speed * Time.deltaTime;
            transform.position += new Vector3(a, b, c);

        }

        if (Input.GetKey(KeyCode.W))
        {
            c -= speed * Time.deltaTime;
            transform.position += new Vector3(a, b, c);

        }

        if (Input.GetKey(KeyCode.S))
        {
            c += speed * Time.deltaTime;
            transform.position += new Vector3(a, b, c);

        }


      

    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("booster"))
        {
            speed += 5f;
            Destroy(other.gameObject, 3);
            timestart = 0.0f;


            
        }
        if (other.CompareTag("slow"))
        {
            speed -= 5f;
            Destroy(other.gameObject, 3);
            timestart = 0.0f;  // slow������Ʈ�� �浹�ϸ� timestart�� 0.0f�� �������. -> �÷��̾ slow������Ʈ�� �浹�ϰ� �� �� timestart�� 3.0f�� �� ������ speed�� �پ�� ����,
                               // Speed_Time�� ���� timestart>timeupdate�� �Ǹ� �ٽ� timestart�� 0.0f�� �������.  
            if (speed < 1)
            {
                speed = 1;
            }
        }

        if (other.CompareTag("door"))
        {
            //Destroy(other.gameObject, 3);
            timestart = 0.0f;

            
            if (timestart == 1f)
            {
                Debug.Log("1");
            }
            if (timestart == 2f)
            {
                Debug.Log("2");
            }
            if (timestart == 3f)
            {
                Debug.Log("3");
            }
        }
        if (other.CompareTag("car"))
        {
            transform.position = StartPosition;
        }
    }
}






