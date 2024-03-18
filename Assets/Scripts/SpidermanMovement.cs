using UnityEngine;

public class SpidermanMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Rigidbody2D rbOfBlock;
    [SerializeField] private SpringJoint2D currentSpringJoint2D;
    [SerializeField] private float distanceChange;
    [SerializeField] private Vector2 forceDirection;

    private void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            currentSpringJoint2D.distance += distanceChange;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            if (currentSpringJoint2D.distance > 1.5f)
            {
                currentSpringJoint2D.distance -= distanceChange;
            }
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            //rb.AddForce(myJoint.connectedBody.position);
            //rb.AddForce(forceDirection);
            //rb.AddForce(transform.position);
            //rb.velocity -= new Vector2(0.1f, 0f);
            rb.velocity -= new Vector2(0.05f, 0f);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            //rb.AddForce(-myJoint.connectedBody.position);
            //rb.AddForce(-forceDirection);
            //rb.AddForce(-transform.position);
            //rb.velocity += new Vector2(0.1f, 0f);
            rb.velocity += new Vector2(0.05f, 0f);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            currentSpringJoint2D.connectedBody = null;
            currentSpringJoint2D.enabled = false;
        }
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, 0f, 1 << 3);

            if (hit.collider != null)
            {
                currentSpringJoint2D.enabled = true;
                rbOfBlock = hit.collider.gameObject.GetComponent<Rigidbody2D>();
                currentSpringJoint2D.connectedBody = rbOfBlock;
            }
        }
    }
}