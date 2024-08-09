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

        float moveInput = Mathf.Clamp01(Mathf.Abs(horizontal)+ Mathf.Abs(vertical)); // Clamp, ù��° ���ڷ� ���� �ּ� �ִ� ���� ������ �������ִ� �Լ�.
                                         // Mathf.abs : ����, �Ʒ����� �Է¹��� �� Input.GetAxis (���� ���� ��ȯ�մϴ�.) ������ ����� ��ȯ�ϱ� ����
    
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
