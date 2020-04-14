using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AppsGenerator : MonoBehaviour
{
	public List<App> Apps;
	public GameObject Content;
	public Vector2 NumerateTextPosition;
	public Vector2 ImageStandartPosition;
	public Vector2 TextStandartPosition;
	public Font Arial;

	private GameObject ParentOfComponents;
	private GameObject NewObjForNumerate;
	private GameObject NewObjForIcon;
	private GameObject NewObjForText;
	private int i = 0;

	private void Update()
	{
		if (i < Apps.Count)
		{
			AddEditAndActivateObjectsForApp();
			EditSizeDelta(Content.GetComponent<RectTransform>(), Content.GetComponent<RectTransform>().sizeDelta + new Vector2(0, 115));
			i++;
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
		ParentOfComponents.AddComponent<CreateDescriptionToApp>().GivenApp = Apps[i];
		ParentOfComponents.AddComponent<Button>().onClick.AddListener(ParentOfComponents.GetComponent<CreateDescriptionToApp>().LoadCreateScreenshotsAndOpenAppDescription);
	}
	private void AddImageComponentToParentObjectAndEditIt()
	{
		Image NewImageForParent = ParentOfComponents.AddComponent<Image>();
		EditRectTransform(ParentOfComponents.GetComponent<RectTransform>(), Content, new Vector3(1f, 1f, 1f), new Vector2(Content.GetComponent<RectTransform>().sizeDelta.x, 100), ParentOfComponents.GetComponent<RectTransform>().localPosition);
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
		AddComponentTextToObjectAndEditIt(NewObjForNumerate, (i + 1).ToString(), Arial, 50, TextAnchor.MiddleCenter, Color.black);
		EditRectTransform(NewObjForNumerate.GetComponent<RectTransform>(), ParentOfComponents, new Vector3(1, 1, 1), new Vector2(100, 100), NumerateTextPosition);
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
		EditRectTransform(NewObjForIcon.GetComponent<RectTransform>(), ParentOfComponents, new Vector3(0.75f, 0.75f, 0.75f), new Vector2(100, 100), ImageStandartPosition);
	}
	private void EditAndActivateTextObject()
	{
		AddComponentTextToObjectAndEditIt(NewObjForText, Apps[i].AppName, Arial, 50, TextAnchor.MiddleLeft, Color.black);
		EditRectTransform(NewObjForText.GetComponent<RectTransform>(), ParentOfComponents, new Vector3(1, 1, 1), new Vector2(572, 100), TextStandartPosition);
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
