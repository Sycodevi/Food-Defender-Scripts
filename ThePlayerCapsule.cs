
using UnityEngine;

public class ThePlayerCapsule : MonoBehaviour
{
    public Transform player;
    void Update()
    {
        gameObject.transform.position = player.position;
        gameObject.transform.rotation = player.rotation;
    }
}
