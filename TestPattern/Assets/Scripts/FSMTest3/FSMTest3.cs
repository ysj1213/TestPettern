using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FSMTest3 : MonoBehaviour
{
    public BattleFSM m_BattleFSM = new BattleFSM();

    public Text m_TextKey = null;
    public Text m_TextResult = null;
    public Text m_TextScore = null;
    public Text m_TextTime = null;
    public Text m_Text = null;

    public Button m_BtnStart = null;
    public Button m_BtnStop = null;

    float time = 20f;
    int score = 0;
    int count = 0;

    bool isBool = false;

    int m_RandomNumber = -1;

    void Start()
    {
        m_BattleFSM.Initialize(CB_Ready, CB_Game, CB_Wave, CB_Result);

        m_BtnStart.onClick.AddListener(OnClick_Start);
        m_BtnStop.onClick.AddListener(OnClick_Stop);

        m_TextScore.text = $"score";
        m_TextTime.text = $"time";
        m_Text.text = $"";
        m_TextKey.text = $"Key";
        m_TextResult.text = $"상태";
    }

    void Initialize()
    {
        time = 20f;
        score = 0;
        count = 0;

        isBool = false;

        m_RandomNumber = -1;

        m_TextScore.text = $"score";
        m_TextTime.text = $"time";
        m_Text.text = $"";
        m_TextKey.text = $"Key";
        m_TextResult.text = $"상태";
    }

    void Update()
    {

        if (isBool == true)
        {
            CheckKeyNumber();

            m_TextTime.text = $"time : {string.Format("{0:0.0}", time)}";
            time -= Time.deltaTime;

            if(time <= 0f)
            {
                isBool = false;
                m_BattleFSM.SetResultState();
            }
        }

        if (m_BattleFSM != null)
            m_BattleFSM.OnUpdate();
    }

    void CB_Ready()
    {
        m_Text.text = $"Ready";
        StartCoroutine(ReadyCorou());
    }

    IEnumerator ReadyCorou()
    {
        yield return new WaitForSeconds(1f);

        m_BattleFSM.SetGameState();
    }

    void CB_Game()
    {
        m_Text.text = $"Game";
        m_RandomNumber = Random.Range(0, 10);
        m_TextKey.text = $"Key : {m_RandomNumber}";
        isBool = true;
    }

    void CB_Wave()
    {
        StartCoroutine(WaveCorou());
    }

    IEnumerator WaveCorou()
    {
        yield return new WaitForSeconds(0.8f);
        m_TextResult.text = $"상태";
        m_BattleFSM.SetGameState();
    }

    void CB_Result()
    {
        if(time <= 0f)
            m_Text.text = $"점수 : {score}";

        if (count == 3)
            m_Text.text = $"패배";
    }

    void CheckKeyNumber()
    {
        for (int i = 0; i <= 9; i++)
        {
            if(Input.GetKeyDown(KeyCode.Alpha0 + i))
            {
                if(m_RandomNumber == i)
                {
                    m_TextResult.text = $"성공";
                    score += 10;
                    m_TextScore.text = $"score = {score}";
                    m_BattleFSM.SetWaveState();
                }
                else
                {
                    count += 1;
                    m_TextResult.text = $"실패";
                    m_BattleFSM.SetWaveState();
                }

                if(count == 3)
                {
                    isBool = false;
                    m_BattleFSM.SetResultState();
                }
            }
        }
    }

    void OnClick_Start()
    {
        Initialize();
        m_BattleFSM.SetReadyState();
    }

    void OnClick_Stop()
    {
        Initialize();
    }
}
