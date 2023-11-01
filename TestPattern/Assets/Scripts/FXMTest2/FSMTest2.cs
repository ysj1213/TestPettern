using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class FSMTest2 : MonoBehaviour
{
    public BattleFSM m_BattleFSM = new BattleFSM();

    public Button m_BtnStart = null;
    public Button m_BtnStop = null;
    public Button m_BtnAttack = null;

    public Text m_TextHp = null;
    public Text m_TextTime = null;
    public Text m_Text = null;

    float time = 10f;
    int hp = 100;

    void Start()
    {
        m_BattleFSM.Initialize(CB_Ready, CB_Game, CB_Wave, CB_Result);

        m_BtnStart.onClick.AddListener(OnClick_Start);
        m_BtnAttack.onClick.AddListener(OnClick_Attack);
        m_BtnStop.onClick.AddListener(OnClick_Stop);
    }

    void Update()
    {
        if(m_BattleFSM != null)
            m_BattleFSM.OnUpdate();
    }

    void Initialize()
    {
        time = 10f;
        hp = 100;
    }

    void CB_Ready()
    {
        m_Text.text = "Ready";
        StartCoroutine(ReadyCorou());

        
    }

    IEnumerator ReadyCorou()
    {
        yield return new WaitForSeconds(1f);
        m_BattleFSM.SetGameState();
    }

    void CB_Game()
    {
        m_Text.text = "Game";
        m_TextHp.text = $"Monster HP = {hp}";
        m_TextTime.text = $"Time : {time}";
        StartCoroutine(GameTimeCorou());
    }

    IEnumerator GameTimeCorou()
    {
        while(m_BattleFSM.IsGameState())
        {

            yield return new WaitForSeconds(1f);
            time -= 1;
            m_TextTime.text = $"Time : {time}";

            if (time == 0)
                m_BattleFSM.SetResultState();
            yield return null;
        }
    }

    void CB_Wave()
    {

    }

    void CB_Result()
    {
        if(hp == 0)
            m_Text.text = "½Â¸®";

        if (time == 0)
            m_Text.text = "ÆÐ¹è";
    }

    void OnClick_Start()
    {
        Initialize();
        m_BattleFSM.SetReadyState();
    }

    void OnClick_Attack()
    {
        hp -= 10;
        m_TextHp.text = $"Monster HP = {hp}";

        if (hp == 0)
            m_BattleFSM.SetResultState();
    }

    void OnClick_Stop()
    {
        if (m_BattleFSM.IsGameState())
            m_BattleFSM.SetWaveState();
        else
            m_BattleFSM.SetGameState();
    }
}
