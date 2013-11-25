using UnityEngine;
using System.Collections;

public class killMeWhen : MonoBehaviour {

	public float deathClock = 1.0f;

	// Use this for initialization
	void Start () {

		StartCoroutine(destroyOnTimer());
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator destroyOnTimer () {
		yield return new WaitForSeconds(deathClock);
		//print("Im dead");
		Destroy(this.gameObject);
	}
}
