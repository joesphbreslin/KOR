/* Joey Breslin 02/07/2018
 * Movement Script for main player */

using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    Vector3 move;

    [Tooltip("Scaler for player Speed"), Range(0,10)]
    public float    speed;

    [Tooltip("Axis strings for user input")]
    public string   xAxis,
                    yAxis;

    void Update () {
        move = new Vector3(Input.GetAxisRaw(xAxis), Input.GetAxisRaw(yAxis));
        move = (move.magnitude > 1.0f) ? move = move.normalized : move;
        transform.position += move * Time.deltaTime * speed;
	}
}
