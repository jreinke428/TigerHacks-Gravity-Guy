using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    private AudioSource _audioSource;
    public AudioClip _gondolla;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.clip = _gondolla;
        _audioSource.Play();
    }

    public void LoadLevelSelect()
    {
        SceneManager.LoadScene(1);
    }
}
