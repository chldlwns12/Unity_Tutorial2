using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    [SerializeField] float jumpForce = 0f;
    [SerializeField] int maxJumpCount = 0;
    int jumpCount = 0;

    Rigidbody2D rigid = null;

    float distance = 0f;
    [SerializeField] LayerMask layerMask = 0;

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        distance = GetComponent<BoxCollider2D>().bounds.extents.y + 0.05f;
    }
    void TryJump()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(jumpCount < maxJumpCount)
            {
                jumpCount++;
                rigid.velocity = Vector2.up * jumpForce;
            }
        }
    }

    void CheckGround()
    {
        if (rigid.velocity.y < 0)
        {
            RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.down, distance, layerMask);
            if(hitInfo)
            {
                if(hitInfo.transform.CompareTag("Ground"))
                {
                    jumpCount = 0;
                }
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        TryJump();
        CheckGround();
    }
}
