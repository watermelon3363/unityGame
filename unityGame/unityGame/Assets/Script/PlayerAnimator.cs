using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    public Animator animator;
    public Animator[] animators;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
       //animator = GetComponentInParent<Animator>();    
       // animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        float moveInput = Mathf.Clamp01(Mathf.Abs(horizontal)+ Mathf.Abs(vertical)); // Clamp, 첫번째 인자로 받은 최소 최대 값의 범위를 지정해주는 함수.
                                         // Mathf.abs : 왼쪽, 아래쪽을 입력받을 때 Input.GetAxis (음수 값을 반환합니다.) 음수도 양수로 반환하기 위한
    
        if(moveInput == 0)
        {
            animator.SetBool("Run", false);
        }

        else if(moveInput == 1) 
        {
            animator.SetBool("Run",true);
        }

        if (Input.GetKeyDown(KeyCode.F)) 
        {
            animator.SetTrigger("Victory");        
        }

    }

}
