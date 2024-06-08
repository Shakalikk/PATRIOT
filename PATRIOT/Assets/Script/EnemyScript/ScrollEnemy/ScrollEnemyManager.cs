using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollEnemyManager : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform shootPosition;
    private float time;
    [SerializeField] private float startTimer = 0.8f;

    IEnumerator Shoot()
    {
        while (true)
        {
            if (time <= 0)
            {
                Instantiate(bullet, shootPosition.position, transform.rotation);//Спавн пули
                time = startTimer;
            }
            else
            {
                time -= Time.deltaTime;
            }
            yield return null;
        }
    }

    private void Start()
    {
        StartCoroutine(Shoot());
    }
}
