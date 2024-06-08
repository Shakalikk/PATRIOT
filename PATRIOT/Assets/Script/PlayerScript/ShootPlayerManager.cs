using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootPlayerManager : AudionController
{
    [Header("����")]
    public GameObject bullet;  
    [Header("������� ����")]
    [SerializeField] private Transform bulletPosition;
    [Header("�������� ����� ����������")]
    private float time;
    [SerializeField] private float startTimer = 0.3f;
    

    IEnumerator ShootCoroutine()
    {
        while (true)
        {
            Shoot();
            yield return null;
        }
    }

    public void Shoot()
    {
        if (time <= 0) //�������� �������� �� �������� ���-��
        {
            if (Input.GetMouseButton(0))
            {
                PlaySounds(sounds[0], p1: 1, p2: 1.2f);
                Debug.Log("Shoot");
                Instantiate(bullet, bulletPosition.transform.position, transform.rotation); //����� ���� � �������� ������� �� ������� ����
                time = startTimer;
            }
        }
        else
        {
            time -= Time.deltaTime;
        }        
    }

    private void Start()
    {
        StartCoroutine(ShootCoroutine());
    }
}
