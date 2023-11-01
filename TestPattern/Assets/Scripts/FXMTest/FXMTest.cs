using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FXMTest : MonoBehaviour
{
    public Button m_BtnStart = null;
    public Button m_BtnStop = null;
    public Button m_BtnAttack = null;

    public Text m_TextHp = null;
    public Text m_TextTime = null;
    public Text m_Text = null;

    bool AllBool = true;

    float starttime = 0;
    bool startBool = false;

    int Hp = 100;
    float time = 10f;
    bool isBool = false;

    void Start()
    {
        m_BtnStart.onClick.AddListener(OnClick_Start);
        m_BtnAttack.onClick.AddListener(OnClick_Attack);
        m_BtnStop.onClick.AddListener(OnClick_Stop);
    }

    void Update()
    {
        if(AllBool == true)
        {
            starttime += Time.deltaTime;
            m_Text.text = "Ready";
            if (starttime >= 3)
            {
                startBool = true;
                m_Text.text = "Start";
            }

            if (startBool == true)
            {
                m_TextHp.text = $"Monster HP = {Hp}";

                if (isBool == true)
                    time -= Time.deltaTime;

                m_TextTime.text = $"time : {Mathf.CeilToInt(time)}";
                if (time <= 0f)
                {
                    m_Text.text = "ÆÐ¹è";
                    isBool = false;
                    AllBool = false;
                }


                if (Hp <= 0)
                {
                    m_Text.text = "½Â¸®";
                    isBool = false;
                    AllBool = false;
                }
            }
        }
    }

    void OnClick_Start()
    {
        StartTime();
    }

    void StartTime()
    {
        AllBool = true;
        isBool = true;
    }

    void OnClick_Attack()
    {
        Hp -= 10;
    }

    void OnClick_Stop()
    {
        AllBool = false;

        starttime = 0;
        startBool = false;

        Hp = 100;
        time = 10f;
        isBool = false;
    }
}
