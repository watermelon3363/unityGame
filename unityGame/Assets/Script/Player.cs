using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Timeline;
using UnityEngine;


public class Player : MonoBehaviour
{
    public CharacterController characterController;
    [SerializeField]
    public float speed = 10f; // 1�����Ӵ� �����̴� ��
    // Start is called before the first frame update
    public Animator animator;
    public float timestart; // ����
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
        timestart += Time.deltaTime; //timestart�� 0, timestar�� Time.deltaTime�� ������. == �ð��� �帧.

        if (timestart > timeupdate) // timeupdate�� 3.0, 3.0�� ������ player�� �ӵ��� 1f�� ������. // timestart�� �ٽ� 0.0f�� ������� 
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
            Debug.Log("�浹");

        }
    }
}






