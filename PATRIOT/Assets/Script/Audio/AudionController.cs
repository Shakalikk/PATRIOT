using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudionController : MonoBehaviour
{
    public AudioClip[] sounds;

    private AudioSource audioSrc => GetComponent<AudioSource>();

    public void PlaySounds(AudioClip clip, float p1 = 1f, float p2 = 1.2f)//Инициализация компонента звука, громкости между двумя параметрами.
    {
        audioSrc.pitch = Random.Range(p1, p2);
        audioSrc.PlayOneShot(clip);
    }
}
