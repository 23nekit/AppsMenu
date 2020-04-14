using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CreateDescriptionToApp : MonoBehaviour
{
	public App GivenApp;

	private GameObject AppDescription;
	private GameObject ScreenShots;

	public void LoadCreateScreenshotsAndOpenAppDescription()
	{
		LoadAppDescription();
		CreateScreenshots();
		AppDescription.GetComponent<PlayAnimation>().PlayGivenAnimationClip("AppPortraitOpen");
	}
	private void LoadAppDescription()
	{
		AppDescription = GameObject.Find("AppDescription");
		ForAppDecription LoadAppDescription = AppDescription.GetComponent<ForAppDecription>();
		LoadAppDescription.GivenApp = GivenApp;
		LoadAppDescription.LoadAppDescriptionOnObjectsAndUpdateContentSize();
	}
	private void CreateScreenshots()
	{
		ScreenShots = GameObject.Find("AppScreenshots");
		ScreenshotsGenerator GenerateScreenshots = ScreenShots.GetComponent<ScreenshotsGenerator>();
		GenerateScreenshots.GivenApp = GivenApp;
		GenerateScreenshots.CreateScreenshotsWithAppImagesAndChangeContentSize();
	}
}
