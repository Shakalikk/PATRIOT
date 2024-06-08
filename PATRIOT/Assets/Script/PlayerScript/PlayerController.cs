using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("�������� ������")]
    [SerializeField]
    private float playerSpeed;
    [Header("���������� ���������")]
    [SerializeField]
    private Rigidbody2D playerRigidbody;
    private Vector2 playerMove;
    private Vector2 playerMoveVelocity;
    [HideInInspector]public bool isFacingRight = true;
    void Start()
    {
        Cursor.visible = false;
        playerRigidbody = GetComponent<Rigidbody2D>();
    }
    
    void Update()
    {
        playerMove = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")); // ����� �������
        playerMoveVelocity = playerMove.normalized * playerSpeed;
        if(!isFacingRight && playerMove.x > 0)//�������� � ����� ������� ��������� �����.
        {
            Flip();
        }
        else if(isFacingRight && playerMove.x < 0)
        {
            Flip();
        }
    }
    

    private void FixedUpdate()
    {
        playerRigidbody.MovePosition(playerRigidbody.position + playerMoveVelocity * Time.fixedDeltaTime); //���������� ������
    }

    public void Flip() // ��������� ������
    {
        isFacingRight = !isFacingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }


}
