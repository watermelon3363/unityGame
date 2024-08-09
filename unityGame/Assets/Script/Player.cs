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
    Rigidbody Player_rigidbody;
    float jumpForce = 5.0f;
    bool grounded = false;

    public float a = 0f;
    public float b = 0f;
    public float c = 0f;
    public float timestart; // ����
    private float timeupdate;
    private float Player_position;
    void Start()
    {
        Player_rigidbody = GetComponent<Rigidbody>(); //?
        speed = 1f;
        timestart = 0.0f;
        timeupdate = 3.0f;
    

    }

    // Update is called once per frame
    void Update()
    {
        PlayerMove();
        Speed_Time();
        jump();
        CheckGround();
    }

    private void jump() // ����
    {
        if(Input.GetButtonDown("jump")&&grounded)
        {
            Vector3 jumpVelocity = Vector3.up * Mathf.Sqrt(jumpForce*-Physics.gravity.y);
            Player_rigidbody.AddForce(jumpVelocity, ForceMode.Impulse);
        }
    }

    private void CheckGround()
    {
        //RaycastHit hit; // ?
        //if (Physics.Raycast(Transform.position,Vector3.down,out hit,0.1f)) //���� ��� �Լ� (������ ��� �Լ� == ������ �浹�Ǵ� �ݶ��̴��� ���� �Ÿ�, ��ġ � ���� ������ Ratcasthit���� ��ȯ�Ѵ�.  
        //{
        //
        //}
    }
    // physics.Raycast(Vector3 ��ġ, Vecter3 ����, out ����� float����);

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
            transform.position = new Vector3(a, b, c);

        }

        if (Input.GetKey(KeyCode.A))
        {
            a += speed * Time.deltaTime;
            transform.position = new Vector3(a, b, c);

        }

        if (Input.GetKey(KeyCode.W))
        {
            c -= speed * Time.deltaTime;
            transform.position = new Vector3(a, b, c);

        }

        if (Input.GetKey(KeyCode.S))
        {
            c += speed * Time.deltaTime;
            transform.position = new Vector3(a, b, c);

        }

        //float horizontalInput = Input.GetAxis("Horizontal");
        //float vertialInput = Input.GetAxis("vertical");
        //
        //Vector3 movevecter = new Vector3(horizontalInput, 0, vertialInput);
        //
        //characterController.SimpleMove(movevecter * speed);

    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("booster"))
        {
            speed += 5f;
            Destroy(other.gameObject, 3);
            timestart = 0.0f;


            //while (timestart < 10) 
            //{
            //
            //    timestart = timestart + timeupdate;
            //
            //    if (timestart > 10)
            //    {
            //        speed -= 10f;
            //        break;
            //    }
            //}
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
            Destroy(gameObject, 3);
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
    }
}






