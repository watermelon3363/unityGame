using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Timeline;
using UnityEngine;


public class Player : MonoBehaviour
{
    public CharacterController characterController;
    [SerializeField]
    public float speed = 10f; // 1프레임당 움직이는 것
    // Start is called before the first frame update
    public Animator animator;
    public float timestart; // 시작
    private float timeupdate;
   
    void Start()
    {
        animator = GetComponent<Animator>();
        speed = 1f;
        timestart = 0.0f;
        timeupdate = 3.0f;

    }

    // Update is called once per frame
    void Update()
    {
        PlayerMove();
        Speed_Time();
        float horizontal = Input.GetAxis("Horizontal");
        float Vertical = Input.GetAxis("Vertical");

        float MoveInput = Mathf.Clamp01(Mathf.Abs(horizontal) + Mathf.Abs(Vertical));

        if (MoveInput == 0)
        {
            animator.SetBool("Run", false);
        }
        else if (MoveInput != 0 ) 
        {
            animator.SetBool("Run",true);
        }


        if (Input.GetKeyDown(KeyCode.F))
        {
            animator.SetTrigger("Victory");
        }
    }


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
            Debug.Log("충돌");

        }
    }
}






