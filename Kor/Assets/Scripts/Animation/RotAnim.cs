using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotAnim : MonoBehaviour {

    public float rotSpeed = 1f;
    public float flipTime = 5f;
	// Use this for initialization
	void Start () {
        StartCoroutine(FlipRotSpeed());
    }
	

	// Update is called once per frame
	void Update () {
        transform.Rotate(Vector3.forward * rotSpeed * Time.deltaTime);
        	}

    IEnumerator FlipRotSpeed()
    {
        yield return new WaitForSeconds(flipTime);
        rotSpeed *= -1f;
        StartCoroutine(FlipRotSpeedNext());
    }

    IEnumerator FlipRotSpeedNext()
    {
        yield return new WaitForSeconds(flipTime * 2);
        rotSpeed *= -1f;
        StartCoroutine(FlipRotSpeedNext());
    }



}
