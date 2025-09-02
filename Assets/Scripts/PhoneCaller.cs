using UnityEngine;

public class PhoneCaller : MonoBehaviour
{
    public void CallEmergency()
    {
        Application.OpenURL("tel:0963520514"); // 台灣消防緊急電話
    }
}
