using UnityEngine;

public class B0PanelController : MonoBehaviour
{
    private GameObject b2Panel;
    private GameObject b3Panel;

    void Start()
    {
        b2Panel = GameObject.Find("B0_Panel");
        b3Panel = GameObject.Find("B0Panel");

        if (b2Panel != null) b2Panel.SetActive(false);
        else Debug.LogError("找不到 B0_Panel");

        if (b3Panel != null) b3Panel.SetActive(false);
        else Debug.LogError("找不到 B0Panel");
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
