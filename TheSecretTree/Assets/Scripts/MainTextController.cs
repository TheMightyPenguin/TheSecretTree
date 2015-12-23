using UnityEngine;
using System.Collections;

public class MainTextController : MonoBehaviour {
	
	public Font font;
	public int fontSize;
	public Vector2 textPos;
	public float toggleSpeed;
	
	GUIStyle guiStyle = new GUIStyle();

	void Start () {
		guiStyle.font = font;
		guiStyle.fontSize = fontSize;
		guiStyle.normal.textColor = Color.black;
		StopCoroutine(alphaCoroutine());
		StartCoroutine(alphaCoroutine());
	}

	IEnumerator alphaCoroutine(){
		Color c = Color.black;
		c.a = 1;
		while(c.a > -0.9f){
			guiStyle.normal.textColor = c;
			c.a -= Time.deltaTime * toggleSpeed;
			yield return null;
		}
	}

	void OnGUI(){
		GUI.Label(new Rect(textPos.x, textPos.y, 100, 100), "Felix Cumpleaños!!!", guiStyle);
	}

}
