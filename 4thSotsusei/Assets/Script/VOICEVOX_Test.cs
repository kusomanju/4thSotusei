using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VoicevoxBridge;
using TMPro;

public class VOICEVOX_Test : MonoBehaviour
{
    [SerializeField] VOICEVOX voicevox;
    [SerializeField] TextMeshProUGUI _text;

    async void Start()
    {
        int speaker = 1;
        string text = "�{�C�X�{�b�N�X���g���čĐ����Ă��܂�";
        await voicevox.PlayOneShot(speaker, text);
        Debug.Log("�{�C�X�Đ��I��");
    }
}
