using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float horizontal;
    private float vertical;
    public float speed = 8f;
    private Vector2 moveDirection;

    private Vector2 mouseDirection;
    public Camera sceneCamera;


    [SerializeField] 
    private Rigidbody2D rb;


    void Start()
    {
    }


    // Update is called once per frame
    void Update()
    {
        this.ProcessInputs();

    }

    private void FixedUpdate()
    {
        this.Move();
    }

    void ProcessInputs()
    {

        this.horizontal = Input.GetAxisRaw("Horizontal");
        this.vertical = Input.GetAxisRaw("Vertical");
        this.moveDirection = new Vector2(this.horizontal, this.vertical).normalized;

        this.mouseDirection = this.sceneCamera.ScreenToWorldPoint(Input.mousePosition);
    }

    void Move()
    {
        rb.velocity = new Vector2(this.moveDirection.x * this.speed, this.moveDirection.y * this.speed);

        Vector2 aimDirection = this.mouseDirection - rb.position;
        float aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg - 90f;

        rb.rotation = aimAngle;
    }
}
