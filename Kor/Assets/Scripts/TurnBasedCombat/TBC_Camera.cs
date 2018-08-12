using UnityEngine;

public class TBC_Camera : MonoBehaviour {

    public Camera cam;

    TBC_Order tBC_Order;
    TBC_Manager tBC_Manager;

    [Range(0,10)]   
    public float lerpSpeed = 1f;
    private Quaternion originalRot;

    private void Start()
    {
        tBC_Order = GetComponent<TBC_Order>();
        tBC_Manager = GetComponent<TBC_Manager>();
       originalRot = cam.transform.rotation;
    }

    // Update is called once per frame
    void Update () {
            cam.transform.rotation = Quaternion.Slerp(cam.transform.rotation, originalRot, Time.deltaTime * lerpSpeed);
            cam.transform.position = Vector3.Lerp(new Vector3(cam.transform.position.x,cam.transform.position.y,cam.transform.position.z)
                                                 ,new Vector3(tBC_Order.lCharacters[tBC_Manager.turnOrderIndex].transform.position.x 
                                                             ,tBC_Order.lCharacters[tBC_Manager.turnOrderIndex].transform.position.y
                                                             ,cam.transform.position.z)
                                                 ,Time.deltaTime * lerpSpeed);

	}
}
