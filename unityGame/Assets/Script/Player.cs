using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class Player : MonoBehaviour
{
    public CharacterController characterController;
    [SerializeField]
    public float speed; // 1프레임당 움직이는 것
    // Start is called before the first frame update
    Rigidbody Player_rigidbody;
    float jumpForce = 5.0f;
    bool grounded = false;

    public float a = 0f;
    public float b = 0f;
    public float c = 0f;
    public float timestart; // 시작
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

    private void jump() // 점프
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
        //if (Physics.Raycast(Transform.position,Vector3.down,out hit,0.1f)) //레이 쏘는 함수 (레이저 쏘는 함수 == 광선에 충돌되는 콜라이더에 대한 거리, 위치 등에 대한 정보를 Ratcasthit으로 반환한다.  
        //{
        //
        //}
    }
    // physics.Raycast(Vector3 위치, Vecter3 방향, out 결과물 float길이);

    private void Speed_Time()
    {
        timestart += Time.deltaTime; //timestart는 0, timestar에 Time.deltaTime을 더해줌. == 시간이 흐름.

        if (timestart > timeupdate) // timeupdate는 3.0, 3.0을 넘으면 player의 속도를 1f로 설정함. // timestart를 다시 0.0f로 만들어줌 
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
            timestart = 0.0f;  // slow오브젝트랑 충돌하면 timestart를 0.0f로 만들어줌. -> 플레이어가 slow오브젝트랑 충돌하고 난 후 timestart가 3.0f가 될 때까지 speed는 줄어든 상태,
                               // Speed_Time에 의해 timestart>timeupdate가 되면 다시 timestart를 0.0f로 만들어줌.  
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






