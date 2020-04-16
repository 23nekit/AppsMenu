using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenshotsGenerator : MonoBehaviour
{
	public GameObject Content;
	[HideInInspector] public App GivenApp;

	private Vector2 SavedSizes;
	private GameObject Screenshot;
	private RectTransform ContentRectTransform;

	private void Start()
	{
		ContentRectTransform = Content.GetComponent<RectTransform>();
		SavedSizes = ContentRectTransform.sizeDelta;
	}

	public void CreateScreenshotsWithAppImagesAndChangeContentSize()
	{
		UpdateContentToStandart();
		for (int i = 0; i < GivenApp.AppScreenshots.Count; i++)
		{
			Screenshot = new GameObject();
			Image CreatingImage = Screenshot.AddComponent<Image>();
			CreatingImage.sprite = GivenApp.AppScreenshots[i];
			RectTransform ScreenshotRectTransform = Screenshot.GetComponent<RectTransform>();
			ScreenshotRectTransform.SetParent(Content.transform);
			ScreenshotRectTransform.sizeDelta = SavedSizes;
			ScreenshotRectTransform.localScale = Vector3.one;
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
		ContentRectTransform.sizeDelta = SavedSizes;
	}
	private void ChangeContentSize()
	{
		ContentRectTransform.sizeDelta = new Vector2(ContentRectTransform.sizeDelta.x + SavedSizes.x, ContentRectTransform.sizeDelta.y);
	}
}
