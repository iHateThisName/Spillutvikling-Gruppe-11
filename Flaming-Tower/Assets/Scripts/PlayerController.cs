using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// Class which handles player movement.
/// </summary>
public class PlayerController : MonoBehaviour
{
    [Header("Movement Settings")]
    [Tooltip("The movement speed of the player")]
    public float movementSpeed = 10f;

    [Tooltip("The jump force to be applied to the player jumps")]
    public float jumpForce = 20f;

    [Tooltip("The current movement.")]
    private float _movement;

    [Tooltip("Shall the player currently face right?")]
    private bool _isFacingRight = true;

    [Header("Animator")]
    [Tooltip("The player animator to be used")]
    public Animator animator;

    [Tooltip("The rigidbody is used to move the player. This is necessary and therefore not public.")]
    private Rigidbody2D _rigidbody;
    private PlayerInput _playerInput;
    private PlayerInputActions _playerInputActions;

    [SerializeField]private AudioSource jumpSoundEffect;
    private static readonly int Speed = Animator.StringToHash("Speed");
    
    private bool _allowMovement;

    private void Awake()
    {
        _allowMovement = true;
        _rigidbody = GetComponent<Rigidbody2D>();
        _playerInput = GetComponent<PlayerInput>();

        _playerInputActions = new PlayerInputActions();
        EnablePlayerInputActions(true);
    }
    
    private void OnEnable() => EnablePlayerInputActions(true);
    private void OnDisable() => EnablePlayerInputActions(false);

    private void EnablePlayerInputActions(bool status)
    {
        switch (status)
        {
            case true:
                _playerInputActions.Player.Enable();
                break;
            case false:
                _playerInputActions.Player.Disable();
                break;
        }
    }
    public void AllowMovement(bool allowMovement)
    {
        _allowMovement = allowMovement;
    }

    /// <summary>
    /// Start is called before the first frame update.
    /// </summary>
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update()
    {
        _movement = _playerInputActions.Player.Movement.ReadValue<Vector2>().x;
        
        if (_allowMovement)
        {
            Debug.Log("Allow movement: " + _allowMovement);
            switch (_movement)
            {
                case < 0 when _isFacingRight:
                    FlipPlayer();
                    break;
                case > 0 when !_isFacingRight:
                    FlipPlayer();
                    break;
            } 
            animator.SetFloat(Speed, Mathf.Abs(_movement));
            transform.position += new Vector3(_movement, 0, 0) * (Time.deltaTime * movementSpeed);
        }

    }
    
    
    public void Jump(InputAction.CallbackContext context)
    {
        if (_allowMovement)
        {
            Debug.Log(context);
            if (context.performed && IsGrounded())
            {
                Debug.Log("Jump! " + context.phase);
                jumpSoundEffect.Play();
                _rigidbody.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            }
            }

    }
    
    /// <summary>
    /// Flips the player horizontal.
    /// </summary>
    void FlipPlayer()
    {
        _isFacingRight = !_isFacingRight;
        transform.Rotate(0f, 180f, 0f);
    }

    /// <summary>
    /// Checks if the player are on the ground.
    /// </summary>
    /// <returns>True if player is grounded, False if not.</returns>
    private bool IsGrounded()
    {
        var velocity = _rigidbody.velocity;
        return (Mathf.Abs(velocity.y) < 0.01f);

    }
}
