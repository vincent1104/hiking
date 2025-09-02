using UnityEngine;
using UnityEngine.SceneManagement;

public class StartSceneManager : MonoBehaviour
{
    public void EnterApp()
    {
        SceneManager.LoadScene("MainScene"); // 注意大小寫要與你的主頁 Scene 名稱一致
    }
}
