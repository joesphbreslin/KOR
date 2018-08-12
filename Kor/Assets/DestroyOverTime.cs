using UnityEngine;

public class DestroyOverTime : MonoBehaviour {

    public float killTime = 1;

	void Start () {
        Destroy(gameObject, killTime);
	}

}
