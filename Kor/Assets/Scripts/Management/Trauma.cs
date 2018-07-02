/* Joey Breslin 02/07/2018
 * Trauma is updated by damage and is used to inform MainCamera >> ScreenShake.cs
 */
using UnityEngine;

public class Trauma : MonoBehaviour {

    [Header("Used to inform camera shake, increase Trauma.trauma to incur shake")]

    [HideInInspector]
    public float trauma = 0;

	void Start () {
        Mathf.Clamp(trauma, 0f, 1f);
	}

    void Update () {
        if (trauma > 0)
            trauma -= Time.deltaTime;		
	}
}
