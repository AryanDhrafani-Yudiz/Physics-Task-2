using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{
    private Vector2 screenBounds;
    private Vector2 screenLowerBounds;
    [SerializeField] private float screenBoundsOffset;
    [SerializeField] private CameraMovement cmScript;
    [SerializeField] private UIManagerScript UIScript;
    [SerializeField] private SoundManager soundManagerScript;
    [SerializeField] TextMeshProUGUI tmproGameObject;

    private readonly float gameOverYLimit = -4.5f;
    private int coinsCounter = 0;
    private int instanceID;

    private Rigidbody2D playerRigidBody;
    private SpringJoint2D playerSpringJoint2D;
    [SerializeField] private Rigidbody2D rbOfGrapplePlatform;
    [SerializeField] private float distanceChange;
    [SerializeField] Vector2 velocityChange;
    private bool canMove = false;
    private LineRenderer lineRenderer;
    private bool singleTime = true;

    private void Awake()
    {
        Application.targetFrameRate = 120;
        playerRigidBody = GetComponent<Rigidbody2D>();
        playerSpringJoint2D = GetComponent<SpringJoint2D>();
        lineRenderer = GetComponent<LineRenderer>();
    }
    private void FixedUpdate()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height)); // Gets Screen Bounds From Camera ViewPort
        screenLowerBounds = Camera.main.ScreenToWorldPoint(Vector2.zero); // Gets Screen Bounds From Camera ViewPort
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, screenLowerBounds.x + screenBoundsOffset, (screenBounds.x - screenBoundsOffset)), Mathf.Clamp(transform.position.y, -6f, (screenBounds.y - screenBoundsOffset)), transform.position.z); // Limits The Position Of Player's X and Y Between Screen Bounds.
        if (transform.position.y < gameOverYLimit) // Display Game Over Screen When Player Below A Certain Height
        {
            if (singleTime)
            {
                UIScript.OnGameOverScreen();
                soundManagerScript.onGameOver();
                singleTime = false;
            }
        }
    }
    void Update()
    {
        if (UIScript.gamePlayScreen) // Gameplay Boolean Enable Then Only Take Input
        {
            if (!EventSystem.current.IsPointerOverGameObject()) // Checks Whether Input Not Being Taken On An UI Element
            {
                SpidermanMovement();
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision) // On Colliding With Building's Top , Checks If Camera Can Move
    {
        if (collision.gameObject.CompareTag("BuildingTop"))
        {
            if (instanceID == 0 || instanceID != collision.gameObject.GetInstanceID())
            {
                instanceID = collision.gameObject.GetInstanceID();
                StartCoroutine(cmScript.LerpFunction(1f));
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision) // Deactivate Coin Game Object On TriggerEnter And Increase The Coin Count
    {
        collision.gameObject.SetActive(false);
        coinsCounter += 10;
        tmproGameObject.text = coinsCounter.ToString();
        soundManagerScript.onCoinsCollect();
    }
    private void SpidermanMovement() // Adds Force To Player To Demonstrate Jumping Like Movement
    {
        if (canMove) // Attached To Grappling Platform
        {
            if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
            {
                playerSpringJoint2D.distance += distanceChange;
            }
            if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
            {
                if (playerSpringJoint2D.distance > 1.5f)
                {
                    playerSpringJoint2D.distance -= distanceChange;
                }
            }
            if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
            {
                playerRigidBody.velocity -= velocityChange;
            }
            if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
            {
                playerRigidBody.velocity += velocityChange;
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                leaveGrapple();
            }
        }
        else // Not Attached To Any Grappling Platform
        {
            if (Input.GetMouseButtonDown(0))
            {
                joinGrapple();
                soundManagerScript.onWebShoot();
            }
        }
    }
    private void leaveGrapple()
    {
        playerSpringJoint2D.connectedBody = null;
        playerSpringJoint2D.enabled = false;
        canMove = false;
        lineRenderer.enabled = false;
    }
    private void joinGrapple()
    {
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, 0f, 1 << 3);

        if (hit.collider != null)
        {
            playerSpringJoint2D.enabled = true;
            rbOfGrapplePlatform = hit.collider.gameObject.GetComponent<Rigidbody2D>();
            playerSpringJoint2D.connectedBody = rbOfGrapplePlatform;
            canMove = true;
            lineRenderer.enabled = true;
        }
    }
}