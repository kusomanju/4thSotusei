using NMeCab.Specialized;
using UnityEngine;
using TMPro;
using VoicevoxBridge;
using Cysharp.Threading.Tasks;


public class NMeCab_test : MonoBehaviour
{
    [Header("解析させる文章")]
    [SerializeField]private TextMeshProUGUI m_InputField;
    [Header("解析結果")]
    [SerializeField]private TextMeshProUGUI m_TextMeshPro;
    [SerializeField] private VOICEVOX voicevox;
    private string mecab_text;
    public static bool NMeCab_ParseFlag = false;
    bool TVFlag;
    bool drinkFlag;
    public static bool TV_On = false;
    public static bool TV_OFF = false;
    public static bool Take_Drink = false;
    public static bool Put_Drink = false;

    public static bool NoticeFlag = false;

    private bool[] beforeOBJ = new bool[2];
    void Start()
    {
        var token = this.GetCancellationTokenOnDestroy();
        NMeCab_ParseFlag = false;
        mecab_text = "";
        beforeOBJ[0] = false;
        beforeOBJ[1] = false;

        TV_On = false;
        TV_OFF = false;
        Take_Drink = false;
        Put_Drink = false;
    }

    async private void Update()
    {
        if (NMeCab_ParseFlag == true)
        {
            m_TextMeshPro.text = "";
            mecab_text = m_InputField.text;

            //辞書パス
            var dicDir = @"Assets/NMeCab-0.10.2/dic/ipadic";

            using (var tagger = MeCabIpaDicTagger.Create(dicDir))
            {
                var nodes = tagger.Parse(mecab_text);
                foreach (var item in nodes)
                {
                    //読み方、品詞、語、活用を教えてくれる
                    Debug.Log($"{item.Surface}, {item.PartsOfSpeech}, {item.PartsOfSpeechSection1}, {item.PartsOfSpeechSection2}");
                    m_TextMeshPro.text += item.Surface;
                    //if (item.PartsOfSpeech == "形容詞")
                    //{
                    //    m_TextMeshPro.text += item.Surface;
                    //}
                    //if (item.Surface == "ない")
                    //{
                    //    m_TextMeshPro.text += "ない";
                    //}
                    if (item.Surface == "テレビ"||item.Surface=="液晶")
                    {
                        TVFlag = true;
                        beforeOBJ[0] = true;
                        beforeOBJ[1] = false;
                    }
                    if(item.Surface == "飲み物" || item.Surface == "ジュース")
                    {
                        drinkFlag = true;
                        beforeOBJ[0] = false;
                        beforeOBJ[1] = true;
                    }
                    if (item.Surface == "ありがとう")
                    {
                        Put_Drink = true;
                    }

                    if (item.Surface == "それ" && item.PartsOfSpeech == "名詞")
                    {
                        Debug.Log("before[0]=" + beforeOBJ[0]);
                        Debug.Log("before[1]=" + beforeOBJ[1]);
                        if (beforeOBJ[0]) { TVFlag = true; }
                        if (beforeOBJ[1]) { drinkFlag = true; }
                    }

                    if (TVFlag)
                    {
                        if(item.Surface == "つけ")
                        {
                            NoticeFlag = true;
                        }
                        if (item.Surface == "消し")
                        {
                            TV_OFF = true;
                        }
                    }

                    if (drinkFlag)
                    {
                        if (item.Surface == "取っ" || item.Surface == "欲し")
                        {
                            Take_Drink = true;
                        }
                        if (item.Surface == "置い")
                        {
                            Put_Drink = true;
                        }
                    }

                    if (NoticeFlag)
                    {
                        if (item.Surface == "ない")
                        {
                            TV_OFF= true;
                            NoticeFlag = false;
                        }
                        else if(item.Surface == "て")
                        {
                            TV_On = true;
                            NoticeFlag = false;
                        }
                    }
                }
            }
            NMeCab_ParseFlag = false;
            TVFlag = false;
            drinkFlag = false;
        }

        if (OVRInput.GetDown(OVRInput.Button.Two))
        {
            int speaker = 1;
            string text = m_TextMeshPro.text;
            await voicevox.PlayOneShot(speaker, text);
            Debug.Log("ボイス再生終了");
        }
    }

    public void InputText()
    {
        NMeCab_ParseFlag = true;
    }
}