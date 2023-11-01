using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CState
{
    public virtual void OnEnter() { }
    public virtual void OnUpdate() { }
    public virtual void OnExit() { }
}

public class BattleFSM
{
    public delegate void DelegateFunc();

    public class CState
    {
        public DelegateFunc m_OnEnterFunc = null;
        public DelegateFunc m_OnExitFunc = null;

        public virtual void Initalize(DelegateFunc func)
        {
            m_OnEnterFunc = new DelegateFunc(func);
        }

        public virtual void OnEnter()
        {
            if(m_OnEnterFunc != null)
            {
                m_OnEnterFunc();
            }
        }

        public virtual void OnUpdate()
        {

        }

        public virtual void OnExit()
        {
            if(m_OnExitFunc != null)
            {
                m_OnExitFunc();
            }
        }
    }

    public class CReadyState : CState { }
    public class CWaveState : CState { }
    public class CGameState : CState { }
    public class CResultState : CState { }

    private CState m_curState = null;
    private CState m_newState = null;

    private CState m_kReady = new CReadyState();
    private CState m_kWave = new CWaveState();
    private CState m_kGame = new CGameState();
    private CState m_kResult = new CResultState();


    public void Initialize(DelegateFunc kReady, DelegateFunc kGame, DelegateFunc kWave, DelegateFunc kResult)
    {
        m_kReady.Initalize(kReady);
        m_kWave.Initalize(kWave);
        m_kGame.Initalize(kGame);
        m_kResult.Initalize(kResult);
    }

    public void SetState(CState kState)
    {
        m_newState = kState;
    }

    public void OnUpdate()
    {
        if(m_newState != null)
        {
            if(m_curState != null)
            {
                m_curState.OnExit();
            }

            m_curState = m_newState;
            m_newState = null;
            m_curState.OnEnter();
        }

        if(m_curState != null)
        {
            m_curState.OnUpdate();
        }
    }

    public void SetReadyState() { SetState(m_kReady); }
    public void SetWaveState() { SetState(m_kWave); }
    public void SetGameState() { SetState(m_kGame); }
    public void SetResultState() { SetState(m_kResult); }

    public void SetResult() { SetState(m_kResult); }

    public bool IsCurState(CState kState)
    {
        if(m_curState == null)
        {
            return false;
        }

        return (m_curState == kState) ? true : false;
    }

    public CState GetCurState() { return m_curState; }

    public void SetNoneState()
    {
        m_newState = null;
        m_curState = null;
    }

    public bool IsResultState() { return (m_curState == m_kResult); }
    public bool IsGameState() { return (m_curState == m_kGame); }
    public bool IsNoneState() { return (m_curState == null); }
}
