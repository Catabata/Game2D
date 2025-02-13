using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.InputSystem;


public class TopDownCharacterController : MonoBehaviour
{
    #region Framework Variables

    //The inputs that we need to retrieve from the input system.
    private InputAction m_moveAction;
    private InputAction m_attackAction;

    //The components that we need to edit to make the player move smoothly.
    private Animator m_animator;
    private Rigidbody2D m_rigidbody;
    
    //The direction that the player is moving in.
    private Vector2 m_playerDirection;
   

    [Header("Movement parameters")]
    //The speed at which the player moves
    [SerializeField] private float m_playerSpeed = 200f;
    //The maximum speed the player can move
    [SerializeField] private float m_playerMaxSpeed = 1000f;

    #endregion+


    private void Awake()
    {

        m_moveAction = InputSystem.actions.FindAction("Move");
        m_attackAction = InputSystem.actions.FindAction("Attack");
        m_animator = GetComponent<Animator>();
        m_rigidbody = GetComponent<Rigidbody2D>();
      
    }
    

    void Start()
    {
        print("thing");
    }

    private void FixedUpdate()
    {
        //clamp the speed to the maximum speed for if the speed has been changed in code.
        float speed = m_playerSpeed > m_playerMaxSpeed ? m_playerMaxSpeed : m_playerSpeed;
        
        //apply the movement to the character using the clamped speed value.
        m_rigidbody.linearVelocity = m_playerDirection * (speed * Time.fixedDeltaTime);
    }
    
    /// <summary>
    /// When the update loop is called, it runs every frame.
    /// Therefore, this will run more or less frequently depending on performance.
    /// Used to catch changes in variables or input.
    /// </summary>
    void Update()
    {
        Vector3 mousepos = Input.mousePosition;

        // store any movement inputs into m_playerDirection - this will be used in FixedUpdate to move the player.
        m_playerDirection = m_moveAction.ReadValue<Vector2>();
        
        // ~~ handle animator ~~
        // Update the animator speed to ensure that we revert to idle if the player doesn't move.
        m_animator.SetFloat("Speed", m_playerDirection.magnitude);
        
        // If there is movement, set the directional values to ensure the character is facing the way they are moving.
        if (m_playerDirection.magnitude > 0)
        {
            m_animator.SetFloat("Horizontal", m_playerDirection.x);
            m_animator.SetFloat("Vertical", m_playerDirection.y);
        }

        // check if an attack has been triggered.
        if (m_attackAction.IsPressed())
        {

        }
        Vector2 mouseDir = (Vector2)(mousepos -  transform.position).normalized;

        RaycastHit2D hit = Physics2D.Raycast(transform.position, mouseDir);
        if(hit)
        {
            if(hit.transform.name.Equals("Square"))
            {
                Debug.Log("Hit square cheers");
            }
        }
    }

}