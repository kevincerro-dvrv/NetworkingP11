using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public OpenAIApi openAIApi1;
    
    private AudioSource audioSource;

    void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        openAIApi1.TextToSpeech("Hola Mundo");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Play(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }
}
