using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenshotsGenerator : MonoBehaviour
{
	public GameObject Content;
	public App GivenApp;

	private Vector2 SavedSizes;
	private GameObject Screenshot;

	private void Start()
	{
		SavedSizes = Content.GetComponent<RectTransform>().sizeDelta;
	}

	public void CreateScreenshotsWithAppImagesAndChangeContentSize()
	{
		UpdateContentToStandart();
		for (int i = 0; i < GivenApp.AppScreenshots.Count; i++)
		{
			Screenshot = new GameObject();
			Image CreatingImage = Screenshot.AddComponent<Image>();
			CreatingImage.sprite = GivenApp.AppScreenshots[i];
			Screenshot.GetComponent<RectTransform>().SetParent(Content.transform);
			Screenshot.GetComponent<RectTransform>().sizeDelta = SavedSizes;
			Screenshot.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
			Screenshot.name = "Screenshot" + (i + 1).ToString();
			Screenshot.SetActive(true);
			ChangeContentSize();
		}
	}
	private void UpdateContentToStandart()
	{
		foreach (Transform child in Content.transform)
		{
			Destroy(child.gameObject);
		}
		Content.GetComponent<RectTransform>().sizeDelta = SavedSizes;
	}
	private void ChangeContentSize()
	{
		Content.GetComponent<RectTransform>().sizeDelta = new Vector2(Content.GetComponent<RectTransform>().sizeDelta.x + SavedSizes.x, Content.GetComponent<RectTransform>().sizeDelta.y);
	}
}
