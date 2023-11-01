using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SingletonTest : MonoBehaviour
{
    public Button m_BtnStart = null;
    public Button m_BtnClear = null;
    public Text m_Text = null;

    static SingletonTest _inst = null;

    public int m_Score = 1000;

    public static SingletonTest Inst
    {
        get
        {
            if(_inst == null)
            {
                _inst = new SingletonTest();
            }
            return _inst;
        }

        set { _inst = value; }
    }

    void Start()
    {
        m_Text.text = "";
        m_BtnStart.onClick.AddListener(OnClick_Start);
    }

    void OnClick_Start()
    {
        Test00 test = new Test00(m_Score);
        m_Text.text += $"점수 : {Test00.tot}";
    }
}

public class Test00
{
    public int m_Score = 0;
    public static int tot = 100;

    public Test00(int score)
    {
        m_Score = score;
        tot += m_Score;


        //SingletonTest single = new SingletonTest();
        //single.m_Text.text += $"전 : {single.m_Score}";
        //single.m_Score = 1000;
        //single.m_Text.text += $"후 : {single.m_Score}";

        ////SingletonTest.Inst.m_Score = 200;
    }
}
