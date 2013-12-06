using UnityEngine;
using System.Collections;

#if UNITY_EDITOR
using UnityEditor;


[ExecuteInEditMode () ]
public class alignMe : MonoBehaviour {
	
	public static float tileSize = 2;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if   (Selection.activeTransform) {

		float snapX = Mathf.Round (Selection.activeTransform.transform.position.x);
		float snapY = Mathf.Round (Selection.activeTransform.transform.position.y);
		float snapZ = Mathf.Round (Selection.activeTransform.transform.position.z);

		//Debug.Log (snapX);
		//Debug.Log (snapY);
		//Debug.Log (snapZ);

		Selection.activeTransform.transform.position = new Vector3(snapX, snapY, snapZ);
		
		}
	}
}

#endif
