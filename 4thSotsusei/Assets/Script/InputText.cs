using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InputText : MonoBehaviour
{
    [SerializeField] public TMP_InputField inputText;
    [SerializeField]public TextMeshProUGUI text;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Inputtext()
    {
        text.text = inputText.text;
    }
}
