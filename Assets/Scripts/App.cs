using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[CreateAssetMenu(fileName = "New App", menuName = "New App")]
public class App : ScriptableObject
{
	public string AppName;
	public Sprite AppIcon;
	public string AppDescription;
	public List<Sprite> AppScreenshots;
}
