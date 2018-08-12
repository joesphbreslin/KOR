using UnityEngine;

public class CameraShake : MonoBehaviour {

    Trauma trauma;
    Transform shakingCamera;

    [Header("Camera Shake utilises Trauma Component")]
    [Header("attached to Manager object.")]
    [Header("Trauma accesed using 'Manager' tag ")]
    [Space(10)]

    [Tooltip("'Max Offset' is a transational scaler used to enhance X & Y shake magnitude."), Range(0, 2)]
    public float maxOffset;

    [Tooltip("'Max Angle' is a Rotational scaler used to enhance z axis"), Range(0, 10)]
    public float maxAngle;

    [Tooltip("TEST function for damage i.e. trauma modifier"), Range(0, 10)]
    public string TESTdamageButton;

    void Start () {
        shakingCamera = this.transform;
        trauma = GameObject.FindGameObjectWithTag("Manager").GetComponent<Trauma>();
	}

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            Damage();
        }
        TransformCamera();
        RotateCamera();
    }

    void RotateCamera()
    {  
        shakingCamera.rotation = transform.rotation * Quaternion.Euler(0,0, Angle());
        transform.rotation = shakingCamera.rotation;
    }

    void TransformCamera()
    {
        shakingCamera.position = transform.position + new Vector3(Offset(), Offset(),0);
        transform.position = shakingCamera.position;
    }

    #region Test Damage Function
    public void Damage()
    {
        if (trauma.trauma < 1)
        {
            trauma.trauma += Random.Range(0.1f, 1f);
        }
    }
    #endregion

    #region Math

    float Shake(){
        return trauma.trauma * trauma.trauma;
    }  

    float GetRandomFloatNegOneToOne(){
        return Random.Range(-1f, 1f);        
    }

    float Offset(){
        return maxOffset * Shake() * GetRandomFloatNegOneToOne();
    }

    float Angle() {
        return maxAngle * Shake() * GetRandomFloatNegOneToOne();
    }

    //TODO Create Perlin noise that returns -1, 1 with seed 
    float GetPerlinNoise(float seed) {
        return Mathf.PerlinNoise(-1, 1);
    }

    #endregion
}
