using UnityEngine;
using Oculus.Voice;
using Meta.WitAi.Requests;

public class ContinuousVoiceActivation : MonoBehaviour
{
    private AppVoiceExperience appVoiceExperience;

    void Start()
    {
        appVoiceExperience = GetComponent<AppVoiceExperience>();
        appVoiceExperience.VoiceEvents.OnComplete.AddListener(OnRequestComplete);
        appVoiceExperience.Activate(); // kick off the first listen automatically
    }

    private void OnRequestComplete(VoiceServiceRequest request)
    {
        appVoiceExperience.Activate(); // immediately start listening again
    }
}