using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Oculus.Voice;
using Cysharp.Threading.Tasks;

public class VoiceScript : MonoBehaviour
{
    public AppVoiceExperience voiceExperience;
    private bool listen_endFlag = false;

    // Start is called before the first frame update
    void Start()
    {
        var token = this.GetCancellationTokenOnDestroy();
    }

    // Update is called once per frame
    async void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.One))
        {
            Debug.Log("Input");
            await Test();
            NMeCab_test.NMeCab_ParseFlag = true;
        }
    }

    public async UniTask Test()
    {
        voiceExperience.Activate();
        await UniTask.DelayFrame(1);
    }
}