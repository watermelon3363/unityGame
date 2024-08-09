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
        SceneManager.LoadScene(1); // 1번에 등록된 Scene을 불러와라.
    }

    public void GameExit()
    {
        Application.Quit(); //게임을 빌드해야지만 적용이 된다.

#if UNITY_EDITOR
        EditorApplication.isPlaying = false;  // 에디터 에서 실행버튼을 비활성 시키세요. 

#endif 
    }
}
