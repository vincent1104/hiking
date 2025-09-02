using UnityEngine;

public class B1PanelController : MonoBehaviour
{
    private GameObject b2Panel;
    private GameObject b3Panel;

    void Start()
    {
        b2Panel = GameObject.Find("B1_Panel");
        b3Panel = GameObject.Find("B1Panel");

        if (b2Panel != null) b2Panel.SetActive(false);
        else Debug.LogError("找不到 B1_Panel");

        if (b3Panel != null) b3Panel.SetActive(false);
        else Debug.LogError("找不到 B1Panel");
    }

    public void ShowB2Panel()
    {
        if (b2Panel != null) b2Panel.SetActive(true);
    }

    public void HideB2Panel()
    {
        if (b2Panel != null) b2Panel.SetActive(false);
    }

    public void ShowB3Panel()
    {
        if (b3Panel != null) b3Panel.SetActive(true);
    }

    public void HideB3Panel()
    {
        if (b3Panel != null) b3Panel.SetActive(false);
    }
}
