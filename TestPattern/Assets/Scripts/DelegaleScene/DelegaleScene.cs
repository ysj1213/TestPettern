using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DelegaleScene : MonoBehaviour
{
    public Button m_BtnItem1 = null;
    public Button m_BtnItem2 = null;
    public Button m_BtnItem3 = null;
    public Text m_Text = null;
    public Button m_BtnStart = null;
    public Button m_BtnClear = null;

    void Start()
    {
        m_BtnItem1.onClick.AddListener(OnClick_Item1);
        m_BtnItem2.onClick.AddListener(OnClick_Item2);
        m_BtnItem3.onClick.AddListener(OnClick_Item3);

        m_BtnStart.onClick.AddListener(OnClick_Start);
        m_BtnStart.onClick.AddListener(OnClick_Clear);
    }

    void Update()
    {
        
    }

    void OnClick_Item1()
    {

    }

    void OnClick_Item2()
    {

    }

    void OnClick_Item3()
    {

    }

    void OnClick_Start()
    {

    }

    void OnClick_Clear()
    {

    }
}

public class TextItem
{

}