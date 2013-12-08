using UnityEngine;
using System.Collections;


public static class CustomExtensions {

	//this is used for smoothing the rotation of the character as it turns
	public static Quaternion EaseTowards(this Quaternion curr, Quaternion target, float easing) {
		return Quaternion.Slerp(curr, target, Mathf.Pow(easing, Mathf.Clamp01(60f * Time.deltaTime)));
	}
}