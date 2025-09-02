using UnityEngine;
using UnityEngine.SceneManagement;

public class change_to_home : MonoBehaviour  // 繼承 MonoBehaviour
{
    public void EnterApp()
    {
        SceneManager.LoadScene("MainScene"); // 確認 "map" 場景名稱正確且已加入 Build Settings
    }
}
