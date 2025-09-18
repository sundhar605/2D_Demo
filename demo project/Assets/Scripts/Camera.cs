using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField] Transform Player;

    void Update()
    {
        transform.position = new Vector3(Player.position.x, Player.position.y, transform.position.z);
    }
}
