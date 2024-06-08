using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapsuleTrap : MonoBehaviour
{
    [Header("�����")]
    [SerializeField] private Transform target1;
    [SerializeField] private Transform target2;
    [Header("��������")]
    [SerializeField] private float trapSpeed;
    private bool movingToTarget1 = true;
    [Header("�����")]
    [SerializeField] private PlayerHealth _player;
    [Header("����")]
    [SerializeField] private float damage;
 
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("damage");
            _player.GetComponent<PlayerHealth>().ICapsuleTrapDamage(damage); //������� ������ �� � ������ � �������� �������� ���-�� ��
        }
    }

    IEnumerator MoveTrap()
    {
        while (true)
        {
            if (movingToTarget1)
            {
                transform.position = Vector3.MoveTowards(transform.position, target1.position, trapSpeed * Time.deltaTime); //���������� � 1 �����
                if (Vector2.Distance(transform.position, target1.position) < 0.01f)
                {
                    movingToTarget1 = false;
                }
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, target2.position, trapSpeed * Time.deltaTime); //���������� � 2 �����
                if (Vector2.Distance(transform.position, target2.position) < 0.01f)
                {
                    movingToTarget1 = true;
                }
            }
            yield return null;
        }
    }

    private void Start()
    {
        StartCoroutine(MoveTrap());
    }
}
