using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public OpenAIApi openAIApi1;

    public Dropdown voiceSelector;
    public InputField textInput;
    
    private AudioSource audioSource;

    void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        textInput.onSubmit.AddListener(OnSubmitText);
    }

    public void OnSubmitText(string text)
    {   
        string voice = voiceSelector.options[voiceSelector.value].text;
        openAIApi1.TextToSpeech(voice, text);
    }

    public void Play(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }
}
