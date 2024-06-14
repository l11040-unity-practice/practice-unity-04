using UnityEngine;

public class ForceReceiver : MonoBehaviour
{
    CharacterController _controller;
    float _drag = 0.3f;
    float _verticalVelocity;
    public Vector3 Movement => _impact + Vector3.up * _verticalVelocity;
    private Vector3 _dampingVelocity;
    private Vector3 _impact;
    private void Start()
    {
        _controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        if (_controller.isGrounded)
        {
            _verticalVelocity = Physics.gravity.y * Time.deltaTime;
        }
        else
        {
            _verticalVelocity += Physics.gravity.y * Time.deltaTime;
        }

        _impact = Vector3.SmoothDamp(_impact, Vector3.zero, ref _dampingVelocity, _drag);
    }

    public void Reset()
    {
        _verticalVelocity = 0;
        _impact = Vector3.zero;
    }

    public void AddForce(Vector3 force)
    {
        _impact += force;
    }

    public void Jump(float jumpForce)
    {
        _verticalVelocity += jumpForce;
    }
}