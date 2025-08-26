using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5.0f;
    private Rigidbody _rb;
    private Vector3 _moveInput;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    void Update()
    {

        float moveX = Input.GetAxis("Horizontal"); 
        float moveZ = Input.GetAxis("Vertical");   

        _moveInput = new Vector3(moveX, 0f, moveZ);
    }

    void FixedUpdate()
    {
        _rb.MovePosition(_rb.position + _moveInput.normalized * speed * Time.fixedDeltaTime);
    }
}