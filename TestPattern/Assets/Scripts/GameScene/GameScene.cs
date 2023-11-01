using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameScene : MonoBehaviour
{
    public Button m_BtnStart = null;
    public Button m_BtnClear = null;
    public Text m_Text = null;

    void Start()
    {
        m_BtnStart.onClick.AddListener(OnClick_Start);
    }

    void Update()
    {
        
    }

    void OnClick_Start()
    {
        Information First = new Information(90);
        m_Text.text = $"Score = {First.Hp}, Total = {Information.tot}\n";

        Information Two = new Information(90);
        m_Text.text += $"Score = {Two.Hp}, Total = {Information.tot}\n";

        Information Third = new Information(95);
        m_Text.text += $"Score = {Third.Hp}, Total = {Information.tot}";
    }
}

public class Information
{
    public int Hp = 0;
    public static int tot = 0;

    public Information(int hp)
    {
        Hp = hp;
        tot += Hp;
    }
}