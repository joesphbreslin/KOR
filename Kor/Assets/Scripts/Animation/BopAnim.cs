using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BopAnim : MonoBehaviour {

    public bool isLerp = false;
    public bool isXAxis = false, isMaxOnStart = false;
    public float min, max;
    private float _min, _max;
    public float speed = 1f;
    public float temp;
    
    Vector3 target;
    
	// Use this for initialization
	void Start () {
        if (isXAxis)
        {
            _min = transform.position.x - min;
            _max = transform.position.x + max;
        }
        else
        {
            _min = transform.position.y - min;
            _max = transform.position.y + max;
        }

        if (isMaxOnStart)
            temp = _max;
        else
            temp = _min;
    }

    // Update is called once per frame  
    void Update()
    {
        if (isXAxis)
            target = new Vector3(temp, transform.position.y, transform.position.z);
        else
            target = new Vector3(transform.position.x, temp, transform.position.z);

        transform.position = Vector3.Lerp(transform.position, target, Time.deltaTime * speed);

        float distance = Vector3.Distance(transform.position, target);

        if(distance < .1f)
        {
            Flip();
        }

    }

    void Flip()
    {
        if(temp == _max)
        {
            temp = _min;
        }
        else
        {
            temp = _max;
        }
    }
    
}
