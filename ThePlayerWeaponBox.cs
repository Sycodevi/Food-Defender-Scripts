using UnityEngine;

public class ThePlayerWeaponBox : MonoBehaviour
{
    public Transform handslot_r;

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = handslot_r.position;
        gameObject.transform.rotation = handslot_r.rotation;
    }
}
