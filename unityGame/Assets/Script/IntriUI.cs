using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;



public class IntriUI : MonoBehaviour
{
    // Start is called before the first frame update
   public void GameStart()
    {
        SceneManager.LoadScene(1); // 1���� ��ϵ� Scene�� �ҷ��Ͷ�.
    }

    public void GameExit()
    {
        Application.Quit(); //������ �����ؾ����� ������ �ȴ�.

#if UNITY_EDITOR
        EditorApplication.isPlaying = false;  // ������ ���� �����ư�� ��Ȱ�� ��Ű����. 

#endif 
    }
}
