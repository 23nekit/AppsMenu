using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenshotsGenerator : MonoBehaviour
{
    public GameObject Content;
    public App GivenApp;
    public Vector2 SizeOfScreenshot;

    private GameObject Screenshot;

    public void CreateScreenshotsWithAppImagesAndChangeContentSize()
    {
        UpdateContentToStandart();
        for (int i = 0; i < GivenApp.AppScreenshots.Count; i++)
        {
            Screenshot = new GameObject();
            Image CreatingImage= Screenshot.AddComponent<Image>();
            CreatingImage.sprite = GivenApp.AppScreenshots[i];
            Screenshot.GetComponent<RectTransform>().sizeDelta = SizeOfScreenshot;
            Screenshot.name = "Screenshot" + (i + 1).ToString();
            Screenshot.GetComponent<RectTransform>().SetParent(Content.transform);
            Screenshot.SetActive(true);
            ChangeContentSize();
        }
    }
    private void UpdateContentToStandart()
    {
        foreach (Transform child in Content.transform)
        {
            Destroy(child.gameObject);
            Content.GetComponent<RectTransform>().sizeDelta = new Vector2(100, 239.5f);
        }
    }
    private void ChangeContentSize()
    {
        Content.GetComponent<RectTransform>().sizeDelta = new Vector2(Content.GetComponent<RectTransform>().sizeDelta.x + SizeOfScreenshot.x, Content.GetComponent<RectTransform>().sizeDelta.y);
    }
}
