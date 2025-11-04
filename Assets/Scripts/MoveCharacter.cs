using UnityEngine;

public class MoveCharacter : MonoBehaviour
{
    public Rigidbody2D rb;
    public Animator animator;
    public SpriteRenderer spriteRenderer;
    public float speed = 5f;

    public bool isFishing = false;

    private Vector2 moveDirection;


    void Start()
    {
        if (rb == null)
            rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // TODO: Stop player from starting movement if fishing

        moveDirection = new Vector2(0, 0); // TODO: Make player move
        animator.SetFloat("Speed", 0); // TODO: Tell animator when player moves

        if (moveDirection.x != 0)
        {
            SetFacingDirection(moveDirection.x);
        }
    }

    // Special logic for making sure the fishing rod and fish follow the player direction
    private void SetFacingDirection(float x)
    {
        float scaleX = Mathf.Abs(transform.localScale.x);

        if (x < -0.01f)
            scaleX = -scaleX;

        transform.localScale = new Vector3(scaleX, transform.localScale.y, transform.localScale.z);

        // Prevent fish icon from flipping if it is a child
        Fishing fishing = GetComponent<Fishing>();
        if (fishing != null && fishing.fishIcon != null)
        {
            Vector3 fishScale = fishing.fishIcon.transform.localScale;
            float parentSign = Mathf.Sign(transform.localScale.x);
            fishing.fishIcon.transform.localScale = new Vector3(Mathf.Abs(fishScale.x) * parentSign, fishScale.y, fishScale.z);
        }
    }

    void FixedUpdate()
    {
        // Removes any existing movement if fishing
        if (!isFishing)
            rb.linearVelocity = moveDirection * speed;
        else
            rb.linearVelocity = Vector2.zero;
    }
}
