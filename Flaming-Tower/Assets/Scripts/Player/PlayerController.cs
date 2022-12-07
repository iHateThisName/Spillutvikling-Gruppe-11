using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// Class which handles player movement.
/// </summary>
public class PlayerController : MonoBehaviour
{
    [Header("Movement Settings")] [Tooltip("The movement speed of the player")]
    public float movementSpeed = 10f;

    [Tooltip("The jump force to be applied to the player jumps")]
    public float jumpForce = 20f;

    [Tooltip("The current movement.")] private float _movement;

    [Tooltip("Shall the player currently face right?")]
    private bool _isFacingRight = true;

    [Header("Animator")] [Tooltip("The player animator to be used")]
    public Animator animator;

    [Tooltip("The rigidbody is used to move the player. This is necessary and therefore not public.")]
    private Rigidbody2D _rigidbody;

    private PlayerInput _playerInput;
    private PlayerInputActions _playerInputActions;

    [SerializeField] private AudioSource jumpSoundEffect;
    private static readonly int Speed = Animator.StringToHash("Speed");

    private bool _allowMovement;

    //Is called before any start function.
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

    //Is used to enable the new Input system and we can use keys to handle it.
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

    /// <summary>
    /// Controls if the player can move or not.
    /// </summary>
    /// <returns>True if player can move, False if not.</returns>
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

    /// <summary>
    /// Simple jump function that checks if the player is grounded before jumping can be done.
    /// Only single jumping.
    /// </summary>
    public void Jump(InputAction.CallbackContext context)
    {
        if (_allowMovement)
        {
            if (context.performed && IsGrounded())
            {
                jumpSoundEffect.Play();
                _rigidbody.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            }
        }
    }

    /// <summary>
    /// Flips the player horizontal so the player is always facing the right direction.
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