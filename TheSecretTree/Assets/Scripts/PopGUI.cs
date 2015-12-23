using UnityEngine;
using System.Collections;

public class PopGUI : MonoBehaviour {
	
	public Texture2D texture2D;
	public float toggleSpeed;
	public string textToDisplay;
	public Font font;
	public Vector2 textPos;
	public int fontSize;

	GUIStyle guiStyle = new GUIStyle();

	static bool s = false;

	bool toggle = false;
	float alpha = 0;

	void Start(){
		guiStyle.font = font;
		guiStyle.fontSize = fontSize;
	}

	void Update(){
		if(toggle && alpha > 0.3f && Input.GetMouseButtonDown(0)){
			toggle = false;
			StopCoroutine(ToggleS());
			StartCoroutine(ToggleS());
		}
	}

	IEnumerator ToggleS(){
		float time = 0f;
		while((time += Time.deltaTime) < 0.1f){
			yield return null;
		}
		s = false;
	}

	void OnMouseDown(){
		if(!s){
			s = toggle = true;
		}
	}

	void OnGUI(){
		if(toggle){
			if(alpha < 1){
				alpha += Time.deltaTime * toggleSpeed;
				Color c = GUI.color;
				c.a = alpha;
				GUI.color = c;
			}
			GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), texture2D);
			Color b = Color.black;
			b.a = GUI.color.a;
			guiStyle.normal.textColor = b;
			GUI.Label(new Rect(textPos.x, textPos.y, 100, 100), textToDisplay, guiStyle);
		}else if(alpha > 0){
			alpha -= Time.deltaTime * toggleSpeed;
			Color c = GUI.color;
			c.a = alpha;
			GUI.color = c;
			GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), texture2D);
			Color b = Color.black;
			b.a = GUI.color.a;
			guiStyle.normal.textColor = b;
			GUI.Label(new Rect(textPos.x, textPos.y, 100, 100), textToDisplay, guiStyle);
		}else{
			alpha = 0;
		}
	}

}
