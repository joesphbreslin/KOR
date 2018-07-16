using UnityEngine;

public class TBC_Camera : MonoBehaviour {

    public Camera cam;

    TBC_Queue tBC_Queue;
    TBC_Manager tBC_Manager;

    [Range(0,10)]   
    public float lerpSpeed = 1f;

    private void Start()
    {
        tBC_Queue = GetComponent<TBC_Queue>();
        tBC_Manager = GetComponent<TBC_Manager>();        
    }

    // Update is called once per frame
    void Update () {
            cam.transform.position = Vector3.Lerp(new Vector3(cam.transform.position.x,cam.transform.position.y,cam.transform.position.z)
                                                 ,new Vector3(tBC_Queue.turnOrder[tBC_Manager.turnOrderIndex].transform.position.x 
                                                             ,tBC_Queue.turnOrder[tBC_Manager.turnOrderIndex].transform.position.y
                                                             ,cam.transform.position.z)
                                                 ,Time.deltaTime * lerpSpeed);

	}
}
