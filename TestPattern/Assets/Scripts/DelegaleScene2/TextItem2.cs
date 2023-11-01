using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextItem2 : MonoBehaviour
{
    public Button m_BtnStart = null;

    public delegate void DelegateFunc(TextItem2 item, bool kBool);
    private DelegateFunc m_onClickFunc = null; 

    void Start()
    {
        m_BtnStart.onClick.AddListener(OnClick);
    }
    
    public void AddLinstener(DelegateFunc func)
    {
        m_onClickFunc = func;
    }
    void OnClick()
    {
        if (m_onClickFunc != null)
            m_onClickFunc(this, true);
    }

    void Update()
    {
        
    }
}
