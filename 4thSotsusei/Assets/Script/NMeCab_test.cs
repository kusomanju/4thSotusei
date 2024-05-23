using NMeCab.Specialized;
using UnityEngine;
using TMPro;

public class NMeCab_test : MonoBehaviour
{
    [Header("��͂����镶��")]
    [SerializeField]private TextMeshProUGUI m_InputField;
    [Header("��͌���")]
    [SerializeField]private TextMeshProUGUI m_TextMeshPro;
    private string mecab_text;
    [HideInInspector]
    public bool NMeCab_ParseFlag = false;
    void Start()
    {
        mecab_text = "";
        //string sentence = "���킢�������ڂ����Ă����";

        ////�����p�X
        //var dicDir = @"Assets/NMeCab-0.10.2/dic/ipadic";

        //using (var tagger = MeCabIpaDicTagger.Create(dicDir))
        //{
        //    var nodes = tagger.Parse(sentence);

        //    foreach (var item in nodes)
        //    {
        //        //�ǂݕ��A�i���A��A���p�������Ă����
        //        Debug.Log($"{item.Surface}, {item.PartsOfSpeech}, {item.PartsOfSpeechSection1}, {item.PartsOfSpeechSection2}");
        //        if(item.PartsOfSpeech == "�`�e��")
        //        {
        //            Debug.Log(item.Surface + "���Č���ꂽ");//���̂悤�Ɍ`�e��������������
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
            //�����p�X
            var dicDir = @"Assets/NMeCab-0.10.2/dic/ipadic";

            using (var tagger = MeCabIpaDicTagger.Create(dicDir))
            {
                var nodes = tagger.Parse(mecab_text);

                foreach (var item in nodes)
                {
                    //�ǂݕ��A�i���A��A���p�������Ă����
                    Debug.Log($"{item.Surface}, {item.PartsOfSpeech}, {item.PartsOfSpeechSection1}, {item.PartsOfSpeechSection2}");
                    if (item.PartsOfSpeech == "�`�e��")
                    {
                        m_TextMeshPro.text += item.Surface;
                    }
                    if (item.Surface == "�Ȃ�")
                    {
                        m_TextMeshPro.text += "�Ȃ�";
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