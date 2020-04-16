using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CreateDescriptionToApp : MonoBehaviour
{
	[HideInInspector] public App GivenApp;
	[HideInInspector] public GameObject AppDescription;
	[HideInInspector] public GameObject ScreenShots;

	public void LoadCreateScreenshotsAndOpenAppDescription()
	{
		LoadAppDescription();
		CreateScreenshots();
		AppDescription.GetComponent<PlayAnimation>().PlayGivenAnimationClip("AppPortraitOpen");
	}
	private void LoadAppDescription()
	{
		ForAppDecription LoadAppDescription = AppDescription.GetComponent<ForAppDecription>();
		LoadAppDescription.GivenApp = GivenApp;
		LoadAppDescription.LoadAppDescriptionOnObjectsAndUpdateContentSize();
	}
	private void CreateScreenshots()
	{
		ScreenshotsGenerator GenerateScreenshots = ScreenShots.GetComponent<ScreenshotsGenerator>();
		GenerateScreenshots.GivenApp = GivenApp;
		GenerateScreenshots.CreateScreenshotsWithAppImagesAndChangeContentSize();
	}
}
