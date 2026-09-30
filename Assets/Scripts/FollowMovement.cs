using System.Collections;
using UnityEngine;

public class FollowMovement : MonoBehaviour
{
    public GameObject Target;
    public Vector3 offset;
    public float speed;
    public bool active = false;

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (active == true)
        {
            transform.position = Vector3.Lerp(transform.position, Target.transform.position + offset, Time.fixedDeltaTime * speed);
        }
    }
}
