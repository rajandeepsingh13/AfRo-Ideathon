using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour {

	private float speed=0.5f;
	private float rotateSpeed=3.0f;

	Vector3 newPosition;
	void Start()
	{
		PositionChange();
	}
	void PositionChange()
	{
		newPosition = new Vector3(Random.Range (-5.0f, 5.0f), Random.Range (-5.0f, 5.0f),Random.Range (-5.0f, 5.0f));
	}
	// Update is called once per frame
	void Update () {
		if (Vector3.Distance (transform.position, newPosition) < 1)
			PositionChange();
		transform.position = Vector3.Lerp (transform.position, newPosition, Time.deltaTime * speed);
		transform.LookAt(newPosition);
	}
}
