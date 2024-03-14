using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D playerRigidBody;
    [SerializeField] private Vector2 forceToApply;
    private Vector2 screenBounds;
    [SerializeField] private float screenBoundsOffset;
    [SerializeField] private CameraMovement cmScript;
    [SerializeField] private UIManagerScript UIScript;
    [SerializeField] TextMeshProUGUI tmproGameObject;
    private int coinsCounter = 0;

    private void Awake() 
    {
        Application.targetFrameRate = 120;
    }
    private void FixedUpdate()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height)); // Gets Screen Bounds From Camera ViewPort
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -(screenBounds.x - screenBoundsOffset), (screenBounds.x - screenBoundsOffset)), Mathf.Clamp(transform.position.y, -6f, (screenBounds.y - screenBoundsOffset)), transform.position.z); // Limits The Position Of Player's X and Y Between Screen Bounds.
        if (playerRigidBody.velocity == Vector2.zero) // Canera Moves When Player isnt Moving
        {
            cmScript.MoveCamera();
        }
        if (transform.position.y < -4.5f) // Display Game Over Screen When Player Below A Certain Height
        {
            UIScript.OnGameOverScreen();
        }
    }
    void Update()
    {
        if(UIScript.gamePlayScreen) // Gameplay Boolean Enable Then Only Take Input
        {
            if (Input.mousePresent) // To Detect Whether Mouse Is Present Or Not
            {
                if (Input.GetMouseButtonDown(0))
                {
                    if (!EventSystem.current.IsPointerOverGameObject()) // Checks Whether Input Not Being Taken On An UI Element
                    {
                        PlayerJump();
                    }
                }
            }
            else if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                if (!EventSystem.current.IsPointerOverGameObject(0)) // Checks Whether Input Not Being Taken On An UI Element
                {
                    if (touch.phase == TouchPhase.Began)
                    {
                        PlayerJump();
                    }
                }
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision) // Deactivate Coin Game Object On TriggerEnter And Increase The Coin Count
    {
        collision.gameObject.SetActive(false);
        coinsCounter += 10;
        tmproGameObject.text = coinsCounter.ToString();
    }
    private void PlayerJump() // Adds Force To Player To Demonstrate Jumping Like Movement
    {
        playerRigidBody.AddForce(forceToApply, ForceMode2D.Impulse);
    }
}