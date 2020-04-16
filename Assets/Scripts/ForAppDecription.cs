using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ForAppDecription : MonoBehaviour
{
	[HideInInspector] public App GivenApp;
	public Image Icon;
	public Text AppName;
	public Image ScreenshotsContent;
	public Text Description;
	public Image DescriptionContent;

	public void LoadAppDescriptionOnObjectsAndUpdateContentSize()
	{
		Icon.sprite = GivenApp.AppIcon;
		AppName.text = GivenApp.AppName;
		Description.text = GivenApp.AppDescription;
		UpdateContentSize();
	}
	private void UpdateContentSize()
	{
		RectTransform DescriptionContentRectTransform = DescriptionContent.GetComponent<RectTransform>();
		DescriptionContentRectTransform.sizeDelta = DescriptionContentRectTransform.sizeDelta + Vector2.up;
	}
}
