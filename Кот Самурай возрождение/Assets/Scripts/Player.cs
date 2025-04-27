using UnityEngine;

public class Player : MonoBehaviour
{
    private Vector2 startPosition;
    public float speed;
    public float jumpForce;
    public Rigidbody2D rb;
    public float fallThreshold = -23f;
    public bool onGround;
    public Transform CheckGround;
    public float checkRadius = 0.5f;
    public LayerMask Ground;
    private SpriteRenderer spriteRenderer;
    public Animator anim;

    private void Start()
    {
        startPosition = transform.position;
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        // Получаем ввод по горизонтали
        float moveInput = Input.GetAxis("Horizontal");
        Vector2 moveVector = new Vector2(moveInput * speed, rb.linearVelocity.y);
        rb.linearVelocity = moveVector;

        // Устанавливаем значение для анимации движения
        anim.SetFloat("moveX", Mathf.Abs(moveVector.x));

        // Поворот спрайта в зависимости от направления движения
        if (moveInput > 0)
        {
            spriteRenderer.flipX = false; // Поворот вправо
        }
        else if (moveInput < 0)
        {
            spriteRenderer.flipX = true; // Поворот влево
        }

        // Прыжок
        if (Input.GetKeyDown(KeyCode.Space) && onGround)
        {
            rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
            // Убираем анимацию прыжка
            // Если у вас есть анимация, которая должна проигрываться во время прыжка, вы можете оставить ее здесь.
            // Например: anim.SetTrigger("jump");
        }

        // Проверка на падение за пределы
        if (transform.position.y < fallThreshold)
        {
            Die();
        }

        CheckingGround();
    }

    void CheckingGround()
    {
        onGround = Physics2D.OverlapCircle(CheckGround.position, checkRadius, Ground);
        anim.SetBool("onGround", onGround);
    }

    private void Die()
    {
        transform.position = startPosition;
    }
}