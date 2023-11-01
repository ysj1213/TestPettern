using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DelegaleScene2 : MonoBehaviour
{
    public List<TextItem2> TextItems = new List<TextItem2>();
    TextItem2 item = null;

    public Button m_BtnStart = null;
    public Text m_Text = null;

    void Start()
    {
        m_BtnStart.onClick.AddListener(OnClick_Start);

        for (int i = 0; i < TextItems.Count; i++)
        {
            TextItems[i].AddLinstener(OnClick_TextItem);
        }
    }

    public void OnClick_TextItem(TextItem2 textitem, bool kBool)
    {
        for (int i = 0; i < TextItems.Count; i++)
        {
            TextItem2 item = TextItems[i];
            item.GetComponent<Image>().color = Color.white;
        }
        textitem.GetComponent<Image>().color = Color.green;

        item = textitem;
    }

    public void OnClick_Start()
    {
        m_Text.text = $"{item}";
    }

    void Update()
    {
        
    }
}
