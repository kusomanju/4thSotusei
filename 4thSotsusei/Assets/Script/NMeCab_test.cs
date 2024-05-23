using NMeCab.Specialized;
using UnityEngine;
using TMPro;

public class NMeCab_test : MonoBehaviour
{
    [Header("解析させる文章")]
    [SerializeField]private TextMeshProUGUI m_InputField;
    [Header("解析結果")]
    [SerializeField]private TextMeshProUGUI m_TextMeshPro;
    private string mecab_text;
    [HideInInspector]
    public bool NMeCab_ParseFlag = false;
    void Start()
    {
        mecab_text = "";
        //string sentence = "かわいい見た目をしているね";

        ////辞書パス
        //var dicDir = @"Assets/NMeCab-0.10.2/dic/ipadic";

        //using (var tagger = MeCabIpaDicTagger.Create(dicDir))
        //{
        //    var nodes = tagger.Parse(sentence);

        //    foreach (var item in nodes)
        //    {
        //        //読み方、品詞、語、活用を教えてくれる
        //        Debug.Log($"{item.Surface}, {item.PartsOfSpeech}, {item.PartsOfSpeechSection1}, {item.PartsOfSpeechSection2}");
        //        if(item.PartsOfSpeech == "形容詞")
        //        {
        //            Debug.Log(item.Surface + "って言われた");//このように形容詞だけ抜き取れる
        //        }
        //    }


        //}
    }

    private void Update()
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
                    if (item.PartsOfSpeech == "形容詞")
                    {
                        m_TextMeshPro.text += item.Surface;
                    }
                    if (item.Surface == "ない")
                    {
                        m_TextMeshPro.text += "ない";
                    }
                }
            }
            NMeCab_ParseFlag = false;
        }
    }

    public void InputText()
    {

        NMeCab_ParseFlag = true;
    }
}