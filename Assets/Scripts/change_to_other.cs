
using UnityEngine;
using UnityEngine.SceneManagement;

public class change_to_other : MonoBehaviour  // 繼承 MonoBehaviour
{
    public void EnterApp()
    {
        SceneManager.LoadScene("other"); // 確認 "map" 場景名稱正確且已加入 Build Settings
    }
}
