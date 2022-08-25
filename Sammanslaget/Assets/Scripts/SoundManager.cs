using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private static SoundManager _instance;
    public static SoundManager INSTANCE { get { return _instance; } }

    private void Awake() // Sets the Audio Service
    {
        if (_instance == null)
        {
            _instance = this;
        }
        else
            Destroy(this);

        DontDestroyOnLoad(this);
        ServiceLocator.SetAudioService(new NormalAudioService());
    }

    private void Start() // Starts the background music
    {
        ServiceLocator.sound.StartLoop("Background");
    }
}