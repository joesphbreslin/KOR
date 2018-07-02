/* Joey Breslin 02/07/2018
 * Use to re-position camera towards player position, searches for "Player" tag.
 */

using UnityEngine;

public class FollowPlayer : MonoBehaviour {

    Transform player;

    [Header("Used to move towards 'Player' tagged object")]
    
    [Tooltip("LerpSpeed is a scaler for the lerp function that alligns camera position with player position"), Range(0,10)]
    public float lerpSpeed = 1;

    [Tooltip("serpSpeed is a scaler for the slerp function that alligns camera rotation with player rotation"), Range(0, 10)]
    public float slerpSpeed = 1;

    void Start () {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
	}
	
	void Update () {
        AlignWithPlayer();
    }

    void AlignWithPlayer() {
        transform.position = Vector3.Lerp(transform.position, new Vector3(player.position.x, player.position.y, transform.position.z), Time.deltaTime * lerpSpeed);
        transform.rotation = Quaternion.Slerp(transform.rotation, player.rotation, Time.deltaTime * slerpSpeed);
    }
}
