using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelComplete : MonoBehaviour
{
    [Header("Окно победы")]
    [SerializeField] private GameObject levelCompleteImage;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Cursor.visible = true;
            levelCompleteImage.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        levelCompleteImage.SetActive(false);
    }
}
