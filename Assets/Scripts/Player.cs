using UnityEngine;

// Rigidbody ��� 3D �̵� + ���콺 �þ� ȸ�� + ����
[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour
{
    [Header("�̵� ����")]
    public float moveSpeed = 5f;
    public float jumpForce = 5f;

    [Header("���콺 �þ� ����")]
    public float mouseSensitivity = 2f;
    public Transform cameraTransform; // ī�޶� Transform (�÷��̾� �ڽ����� ����)
    public float maxLookAngle = 85f;

    private Rigidbody rb;
    private Vector3 moveDir;
    private float xRotation = 0f;
    private bool isGrounded = false;

    private float hp = 100f;
    private float currenthp;
    private float damage;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true; // ���� ȸ�� ����

        // Ŀ�� ����
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        currenthp = hp;
    }

    void Update()
    {
        HandleMouseLook();
        HandleJump();
        if (currenthp <= 0)
        {
            Debug.Log("회복술사의 회복술!");
            currenthp = hp;
        }
    }

    void FixedUpdate()
    {
        HandleMovement();
    }

    void HandleMouseLook()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        // �÷��̾� ���� ȸ��
        transform.Rotate(Vector3.up * mouseX);

        // ī�޶� ���� ȸ��
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -maxLookAngle, maxLookAngle);
        if (cameraTransform != null)
            cameraTransform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
    }

    void HandleMovement()
    {
        float h = Input.GetAxisRaw("Horizontal"); // A,D
        float v = Input.GetAxisRaw("Vertical");   // W,S

        // �̵� ���� (�÷��̾� ���� �����¿�)
        Vector3 direction = transform.forward * v + transform.right * h;
        direction.Normalize();

        // y �ӵ��� ���� (�߷�/������)
        Vector3 velocity = new Vector3(direction.x * moveSpeed, rb.linearVelocity.y, direction.z * moveSpeed);
        rb.linearVelocity = velocity;
    }

    void HandleJump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        // �ٴ� ������ (�ܼ��ϰ�)
        if (collision.contacts.Length > 0)
        {
            Vector3 normal = collision.contacts[0].normal;
            if (Vector3.Dot(normal, Vector3.up) > 0.5f)
                isGrounded = true;
        }
    }
    public void Get_Damage(float _damage)
    {
        currenthp -= _damage;
        Debug.Log("들어온 데미지 : " + _damage);
        Debug.Log("풀 HP : " + hp + ", 현재 HP : " + currenthp);
    }
}
