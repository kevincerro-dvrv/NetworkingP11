using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class OpenAIApi : MonoBehaviour
{
    private const string API_KEY = "changeme";

    private const string TTS_ENDPOINT = "https://api.openai.com/v1/audio/speech";
    private const string TTS_MODEL = "tts-1";

    // Start is called before the first frame update
    public void TextToSpeech(string voice, string text)
    {
        StartCoroutine(CallTextToSpeech(voice, text));
    }

    private IEnumerator CallTextToSpeech(string voice, string text)
    {
        // Create body
        RequestBody requestBody = new RequestBody {
            model = TTS_MODEL,
            input = text,
            voice = voice,
        };
        string requestBodyJson = JsonUtility.ToJson(requestBody);

        using (UnityWebRequest webRequest = UnityWebRequest.Post(TTS_ENDPOINT, requestBodyJson, "application/json"))
        {
            // Set headers
            webRequest.SetRequestHeader("Authorization", "Bearer " + API_KEY);

            // Request and wait for the desired page.
            webRequest.downloadHandler = new DownloadHandlerAudioClip(TTS_ENDPOINT, AudioType.MPEG);
            yield return webRequest.SendWebRequest();

            if (webRequest.result == UnityWebRequest.Result.Success) {
                AudioClip clip = DownloadHandlerAudioClip.GetContent(webRequest);
                GameManager.instance.Play(clip);
            }
        }
    }

    [System.Serializable]
    public class RequestBody
    {
        public string model;
        public string input;
        public string voice;
    }
}
