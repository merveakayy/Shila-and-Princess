using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Transform Cam;
    public Rigidbody rb;
    public float speed;
    public float jumpSpeed;

    private int jumpCount;
    public int maxJumpCount;
    private bool jumped;
    public LayerMask mask;
    private bool isGrounded => IsGroundControl();
    private float x, z;
    private Vector3 movePos = Vector3.zero;
    bool delay = true;

    public GameObject wprefab;

    public float damageEnemy;

    public Sounds sounds;


    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        jumpCount = maxJumpCount;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = isGrounded ? Color.green : Color.red;
        Gizmos.DrawSphere(transform.position + Vector3.down * 0.3f, 0.35f);
    }

    void Update()
    {
        x = Input.GetAxis("Horizontal");
        z = Input.GetAxis("Vertical");
        movePos = new Vector3(x, 0, z).normalized * speed * Time.deltaTime; ;
        //rb.MovePosition(transform.position + transform.TransformDirection(movePos));
        transform.Translate(movePos);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            /*if (isGrounded || jumpCount > 1 && jumped == false)
            {
                //if (jumped == false) jumpCount--;
                jumped = true;
                rb.velocity = Vector3.up * jumpSpeed * Time.deltaTime;
            }*/ 
            if(jumpCount > 0)
            {
                sounds.jumpSound(transform.position);
                jumpCount--;
                rb.velocity = Vector3.up * jumpSpeed;
                Debug.Log(isGrounded);
            }
        }
        //else jumped = false;
        if (x != 0 || z != 0)
        {
            Quaternion rot = Cam.transform.rotation;
            rot.x = 0;
            rot.z = 0;
            transform.rotation = Quaternion.Lerp(transform.rotation, rot, 0.1f);
        }
        if (isGrounded) 
        { 
            jumpCount = maxJumpCount;

        }




        if (Input.GetKeyDown(KeyCode.V) && delay)
        {
            delay = false;
            Invoke(nameof(SetDelay), 1.3f);
            Quaternion rotation = Quaternion.LookRotation(transform.forward);
            Instantiate(wprefab, transform.position + new Vector3(0, 3, 0), rotation);
            //Instantiate(wprefab, transform.position, wprefab.transform.rotation);
        }
    }

    bool IsGroundControl()
    {
        Collider[] cols = Physics.OverlapSphere(transform.position + Vector3.down * 0.3f, 0.35f, mask);
        return cols.Length > 0;
    }

    private void SetDelay()
    {
        delay = true;
    }


}
