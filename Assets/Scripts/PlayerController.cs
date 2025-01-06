using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;


[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    #region Variables: Movement

    private Vector2 _input;
    private CharacterController _characterController;
    private Vector3 _direction;

    [SerializeField] private float speed;

    private float initialSpeed;
    private float initialGravityMultiplier;

    #endregion
    #region Variables: Rotation

    [SerializeField] private float smoothTime = 0.05f;
    private float _currentVelocity;

    #endregion
    #region Variables: Gravity

    private float _gravity = -9.81f;
    [SerializeField] private float gravityMultiplier;
    private float _velocity;

    #endregion
    #region Variables: Jumping

    [SerializeField] private float jumpPower;

    #endregion

    [SerializeField] private TextMeshProUGUI textScore;
    [SerializeField] private TextMeshProUGUI textTimer;

    [SerializeField] private GameObject jumpBuffIcon;
    [SerializeField] private GameObject speedBuffIcon;

    private int scoreIncrement = 100;

    private float jumpBuffTime = 0;
    private float speedBuffTime = 0;

    private bool isJumpBuffActive = false;
    private bool isSpeedBuffActive = false;

    private int trimScoreCount = "Очки: ".Length;

    private Animator animator;
    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
        initialSpeed = speed;
        initialGravityMultiplier = gravityMultiplier;
        animator = GetComponentInChildren<Animator>();
    }



    private void Update()
    {
        ApplyGravity();
        ApplyRotation();
        ApplyMovement();
        ApplyBuffs();
        ApplyAnimation();
    }


    private void ApplyBuffs()
    {
        if (isJumpBuffActive)
        {
            jumpBuffTime += Time.deltaTime;
        }
        if (isSpeedBuffActive)
        {
            speedBuffTime += Time.deltaTime;
        }
        if (jumpBuffTime > 10)
        {
            isJumpBuffActive = false;
            gravityMultiplier = initialGravityMultiplier;
            jumpBuffIcon.SetActive(false);
        }
        if (speedBuffTime > 10)
        {
            isSpeedBuffActive = false;
            speed = initialSpeed;
            speedBuffIcon.SetActive(false);
        }
    }

    private void ApplyGravity()
    {
        if (IsGrounded() && _velocity < 0.0f)
        {
            _velocity = -1.0f;
        }
        else
        {
            _velocity += _gravity * gravityMultiplier * Time.deltaTime;
        }

        _direction.y = _velocity;
    }

    private void ApplyRotation()
    {
        if (_input.sqrMagnitude == 0) return;

        var targetAngle = Mathf.Atan2(_direction.x, _direction.z) * Mathf.Rad2Deg;
        var angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref _currentVelocity, smoothTime);
        transform.rotation = Quaternion.Euler(0.0f, angle, 0.0f);
    }

    private void ApplyMovement()
    {
        _characterController.Move(_direction * speed * Time.deltaTime);
    }
    private void ApplyAnimation()
    {
        if (!IsGrounded())
        {
            animator.Play("IdleCarry_Walk");
        }
        else if (_characterController.velocity.magnitude > 0.01f)
        {
            animator.Play("Walk");
        }
        else
        {
            animator.Play("Idle_Walk");
        }
    }

    public void Move(InputAction.CallbackContext context)
    {
        _input = context.ReadValue<Vector2>();
        _direction = new Vector3(_input.x, 0.0f, _input.y);

    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (!context.started) return;
        if (!IsGrounded()) return;

        _velocity += jumpPower;
    }


    private bool IsGrounded() => _characterController.isGrounded;

    private void OnTriggerEnter(Collider collision)
    {

        if (collision.gameObject.tag == "ScoreBuff")
        {
            Destroy(collision.gameObject);

            int score = int.Parse(textScore.text.Remove(0,trimScoreCount-1)) + scoreIncrement;
            textScore.SetText("Очки: " + score.ToString());
        }
        if (collision.gameObject.tag == "JumpBuff")
        {
            Destroy(collision.gameObject);
            isJumpBuffActive = true;
            jumpBuffTime = 0;
            gravityMultiplier = initialGravityMultiplier * 0.8f;
            jumpBuffIcon.SetActive(true);          
        }
        if (collision.gameObject.tag == "SpeedBuff")
        {
            Destroy(collision.gameObject);
            isSpeedBuffActive = true;
            speedBuffTime = 0;
            speed = initialSpeed * 1.4f;
            speedBuffIcon.SetActive(true);
        }
    }
}