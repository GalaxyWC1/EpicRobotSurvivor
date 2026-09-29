using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class SpawnHitbox : MonoBehaviour
{
    public Vector2 _meleeSize;
    public Vector2 _meleePos;

    private TopDownMovement tdm;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        tdm = GetComponent<TopDownMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Attack(InputAction.CallbackContext ctx)
    {
        RaycastHit2D hit2D = Physics2D.BoxCast(transform.position+(Vector3)_meleePos, _meleeSize, 0, tdm.movement);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position + (Vector3)_meleePos, _meleeSize);
    }
}
