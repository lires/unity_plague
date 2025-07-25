using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 100f;
    [SerializeField] private float rotationSpeed = 100f;

    private Animator PlayerAnimator;

    void Start()
    {
        PlayerAnimator = GetComponentInChildren<Animator>();
        if (PlayerAnimator == null)
        {
            Debug.LogError("Animator introuvable !");
        }
    }

    void Update()
    {
        float horizontal = 0f;
        float vertical = 0f;

        if (Input.GetKey(KeyCode.W)) vertical = 1f;
        if (Input.GetKey(KeyCode.S)) vertical = -1f;
        if (Input.GetKey(KeyCode.Q)) horizontal = -1f;
        if (Input.GetKey(KeyCode.D)) horizontal = 1f;

        transform.Rotate(0f, horizontal * rotationSpeed * Time.deltaTime, 0f);

        if (vertical != 0f)
        {
            transform.Translate(Vector3.forward * vertical * moveSpeed * Time.deltaTime, Space.Self);
        }

        if (PlayerAnimator != null)
        {
            PlayerAnimator.SetFloat("Speed", Mathf.Abs(vertical));
        }
    }
}
