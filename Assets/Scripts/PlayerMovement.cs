using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Animator animator;
    public CharacterController controller;

    void Start()
    {
        if (animator == null)
            animator = GetComponent<Animator>();

        if (controller == null)
            controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal"); 
        float vertical = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(horizontal, 0f, vertical);
        
        if (direction.magnitude >= 0.1f)
        {
            controller.Move(direction.normalized * moveSpeed * Time.deltaTime);
            animator.SetFloat("Speed", direction.magnitude);
        }
        else
        {
            animator.SetFloat("Speed", 0f);
        }
    }
}
