using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AppsGenerator : MonoBehaviour
{
	public List<App> Apps;
	public GameObject Content;
	public GameObject AppDescriptionObject;
	public GameObject AppDescriptionScreenshotsObject;
	public Vector2 NumerateTextPosition;
	public Vector2 ImageStandartPosition;
	public Vector2 TextStandartPosition;
	public Vector2 ContentRectTransformSizeAddition;
	public Vector2 StandartSize;
	public Vector2 NameTextSize;
	public Vector3 StandartScale;
	public Vector3 IconScale;
	public int FontSize;
	public Font Arial;

	private GameObject ParentOfComponents;
	private GameObject NewObjForNumerate;
	private GameObject NewObjForIcon;
	private GameObject NewObjForText;
	private RectTransform ContentRectTransform;
	int i;

	private void Start()
	{
		ContentRectTransform = Content.GetComponent<RectTransform>();
		for (i = 0; i < Apps.Count; i++)
		{
			AddEditAndActivateObjectsForApp();
			EditSizeDelta(ContentRectTransform, ContentRectTransform.sizeDelta + ContentRectTransformSizeAddition);
		}
	}
	private void AddEditAndActivateObjectsForApp()
	{
		ParentOfComponents = new GameObject();
		EditAndActivateParentObject();
		NewObjForNumerate = new GameObject();
		EditAndActivateNumerateText();
		NewObjForIcon = new GameObject();
		EditAndActivateIcon();
		NewObjForText = new GameObject();
		EditAndActivateTextObject();
		RenameObjects();
	}
	private void EditAndActivateParentObject()
	{
		EditParentObject();
		ParentOfComponents.SetActive(true);
	}
	private void EditParentObject()
	{
		EditPositionParentObject();
		GiveParentAppInfoAndAddListener();
		AddImageComponentToParentObjectAndEditIt();
	}
	private void EditPositionParentObject()
	{
		ParentOfComponents.transform.position = Vector3.zero;
	}
	private void GiveParentAppInfoAndAddListener()
	{
		CreateDescriptionToApp ParentOfComponentsScript = ParentOfComponents.AddComponent<CreateDescriptionToApp>();
		ParentOfComponentsScript.AppDescription = AppDescriptionObject;
		ParentOfComponentsScript.ScreenShots = AppDescriptionScreenshotsObject;
		ParentOfComponentsScript.GivenApp = Apps[i];
		ParentOfComponents.AddComponent<Button>().onClick.AddListener(ParentOfComponentsScript.LoadCreateScreenshotsAndOpenAppDescription);
	}
	private void AddImageComponentToParentObjectAndEditIt()
	{
		Image NewImageForParent = ParentOfComponents.AddComponent<Image>();
		RectTransform ParentOfComponentsRectTransform = ParentOfComponents.GetComponent<RectTransform>();
		EditRectTransform(ParentOfComponentsRectTransform, Content, StandartScale, new Vector2(ContentRectTransform.sizeDelta.x, StandartSize.y), ParentOfComponentsRectTransform.localPosition);
	}
	private void EditRectTransform(RectTransform RectTransformFromObject, GameObject Parent, Vector3 LocalScale, Vector2 Size, Vector2 LocalPosition)
	{
		RectTransformFromObject.SetParent(Parent.transform);
		RectTransformFromObject.localScale = LocalScale;
		EditSizeDelta(RectTransformFromObject, Size);
		RectTransformFromObject.localPosition = LocalPosition;
	}
	private void EditSizeDelta(RectTransform RectTransformToEdit, Vector2 SizeDelta)
	{
		RectTransformToEdit.sizeDelta = SizeDelta;
	}
	private void EditAndActivateNumerateText()
	{
		AddComponentTextToObjectAndEditIt(NewObjForNumerate, (i + 1).ToString(), Arial, FontSize, TextAnchor.MiddleCenter, Color.black);
		RectTransform NewObjForNumerateRectTransform = NewObjForNumerate.GetComponent<RectTransform>();
		EditRectTransform(NewObjForNumerateRectTransform, ParentOfComponents, StandartScale, StandartSize, NumerateTextPosition);
		NewObjForNumerate.SetActive(true);
	}
	private void AddComponentTextToObjectAndEditIt(GameObject ObjectForEdit, string TextForWrite, Font FontToText, int FontSize, TextAnchor TextLocation, Color TextColor)
	{
		Text Mytext = ObjectForEdit.AddComponent<Text>();
		Mytext.text = TextForWrite;
		Mytext.font = FontToText;
		Mytext.fontSize = FontSize;
		Mytext.alignment = TextLocation;
		Mytext.color = TextColor;
	}
	private void EditAndActivateIcon()
	{
		AddImageToIconObjectAndEditIt();
		NewObjForIcon.SetActive(true);
	}
	private void AddImageToIconObjectAndEditIt()
	{
		Image NewImage = NewObjForIcon.AddComponent<Image>();
		NewImage.sprite = Apps[i].AppIcon;
		RectTransform NewObjForIconRectTransform = NewObjForIcon.GetComponent<RectTransform>();
		EditRectTransform(NewObjForIconRectTransform, ParentOfComponents, IconScale, StandartSize, ImageStandartPosition);
	}
	private void EditAndActivateTextObject()
	{
		AddComponentTextToObjectAndEditIt(NewObjForText, Apps[i].AppName, Arial, FontSize, TextAnchor.MiddleLeft, Color.black);
		RectTransform NewObjForTextRectTransform = NewObjForText.GetComponent<RectTransform>();
		EditRectTransform(NewObjForTextRectTransform, ParentOfComponents, StandartScale, NameTextSize, TextStandartPosition);
		NewObjForText.SetActive(true);
	}
	private void RenameObjects()
	{
		ParentOfComponents.name = "Parent" + (i + 1).ToString();
		NewObjForNumerate.name = "Number" + (i + 1).ToString();
		NewObjForIcon.name = "Icon" + (i + 1).ToString();
		NewObjForText.name = "Name" + (i + 1).ToString();
	}
}
