using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    [Header("����� �����")]
    public int scene;
    public void Scene()
    {
        SceneManager.LoadScene(scene); //����� �����
    }
}
