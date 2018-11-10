using UnityEngine;

public class ListenPcInputEvent : MonoBehaviour
{
    void Start()
    {
        //响应pcvr的按键消息.
        InputEventCtrl.GetInstance().ClickPcvrBtEvent07 += ClickSetEnterBt;
        InputEventCtrl.GetInstance().ClickPcvrBtEvent08 += ClickSetMoveBt;
        InputEventCtrl.GetInstance().ClickPcvrBtEvent10 += ClickCloseDongGanBt;
    }

    #region TV Button Event
    /// <summary>
    /// 电视遥控器按键消息.
    /// </summary>
    public delegate void EventHandelTV(InputEventCtrl.ButtonState val);
    public event EventHandelTV ClickTVYaoKongExitBtEvent;
    /// <summary>
    /// 电视遥控器退出按键响应.
    /// </summary>
    public void ClickTVYaoKongExitBt(InputEventCtrl.ButtonState val)
    {
        if (ClickTVYaoKongExitBtEvent != null)
        {
            ClickTVYaoKongExitBtEvent(val);
        }
    }

    public event EventHandelTV ClickTVYaoKongEnterBtEvent;
    /// <summary>
    /// 电视遥控器确定按键响应.
    /// </summary>
    public void ClickTVYaoKongEnterBt(InputEventCtrl.ButtonState val)
    {
        if (ClickTVYaoKongEnterBtEvent != null)
        {
            ClickTVYaoKongEnterBtEvent(val);
        }
    }

    public event EventHandelTV ClickTVYaoKongLeftBtEvent;
    /// <summary>
    /// 电视遥控器方向左按键响应.
    /// </summary>
    public void ClickTVYaoKongLeftBt(InputEventCtrl.ButtonState val)
    {
        if (ClickTVYaoKongLeftBtEvent != null)
        {
            ClickTVYaoKongLeftBtEvent(val);
        }
    }

    public event EventHandelTV ClickTVYaoKongRightBtEvent;
    /// <summary>
    /// 电视遥控器方向右按键响应.
    /// </summary>
    public void ClickTVYaoKongRightBt(InputEventCtrl.ButtonState val)
    {
        if (ClickTVYaoKongRightBtEvent != null)
        {
            ClickTVYaoKongRightBtEvent(val);
        }
    }

    public event EventHandelTV ClickTVYaoKongUpBtEvent;
    /// <summary>
    /// 电视遥控器方向上按键响应.
    /// </summary>
    public void ClickTVYaoKongUpBt(InputEventCtrl.ButtonState val)
    {
        if (ClickTVYaoKongUpBtEvent != null)
        {
            ClickTVYaoKongUpBtEvent(val);
        }
    }

    public event EventHandelTV ClickTVYaoKongDownBtEvent;
    /// <summary>
    /// 电视遥控器方向下按键响应.
    /// </summary>
    public void ClickTVYaoKongDownBt(InputEventCtrl.ButtonState val)
    {
        if (ClickTVYaoKongDownBtEvent != null)
        {
            ClickTVYaoKongDownBtEvent(val);
        }
    }

    class KeyCodeTV
    {
        /// <summary>
        /// 遥控器确定键的键值.
        /// </summary>
        public static KeyCode PadEnter01 = (KeyCode)10;
        public static KeyCode PadEnter02 = (KeyCode)66;
    }
    #endregion

    #region Click Button Event
    /// <summary>
    /// 关闭/打开动感按键.
    /// </summary>
    public event InputEventCtrl.EventHandel ClickCloseDongGanBtEvent;
    public void ClickCloseDongGanBt(InputEventCtrl.ButtonState val)
    {
        if (ClickCloseDongGanBtEvent != null)
        {
            ClickCloseDongGanBtEvent(val);
        }
    }

    /// <summary>
    /// 设置按键.
    /// </summary>
    public event InputEventCtrl.EventHandel ClickSetEnterBtEvent;
    public void ClickSetEnterBt(InputEventCtrl.ButtonState val)
    {
        if (ClickSetEnterBtEvent != null)
        {
            ClickSetEnterBtEvent(val);
        }
    }

    /// <summary>
    /// 移动按键.
    /// </summary>
    public event InputEventCtrl.EventHandel ClickSetMoveBtEvent;
    public void ClickSetMoveBt(InputEventCtrl.ButtonState val)
    {
        if (ClickSetMoveBtEvent != null)
        {
            ClickSetMoveBtEvent(val);
        }
    }
    #endregion

    void Update()
    {
		if (pcvr.IsTestNoInput)
		{
			return;
		}

        if (pcvr.bIsHardWare)
        {
            return;
        }

        //(KeyCode)10 -> acbox虚拟机的遥控器确定键消息.
        if (Input.GetKeyDown(KeyCode.KeypadEnter)
            || Input.GetKeyDown(KeyCode.Return)
            || Input.GetKeyDown(KeyCodeTV.PadEnter01)
            || Input.GetKeyDown(KeyCodeTV.PadEnter02)
            || Input.GetKeyDown(KeyCode.JoystickButton0))
        {
            //遥控器的确定键消息.
            ClickTVYaoKongEnterBt(InputEventCtrl.ButtonState.DOWN);
        }

        if (Input.GetKeyUp(KeyCode.KeypadEnter)
            || Input.GetKeyUp(KeyCode.Return)
            || Input.GetKeyUp(KeyCodeTV.PadEnter01)
            || Input.GetKeyUp(KeyCodeTV.PadEnter02)
            || Input.GetKeyUp(KeyCode.JoystickButton0))
        {
            //遥控器的确定键消息.
            ClickTVYaoKongEnterBt(InputEventCtrl.ButtonState.UP);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //接收遥控器的返回键/键盘上的Esc按键信息.
            ClickTVYaoKongExitBt(InputEventCtrl.ButtonState.DOWN);
        }

        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (false)//SSGameDataCtrl.GetInstance().m_SSUIRoot.m_ExitGameUI == null)
            {
                //创建退出游戏的窗口.
                //SSGameDataCtrl.GetInstance().m_SSUIRoot.SpawnExitGameDlg();
            }
            else
            {
                //接收遥控器的返回键/键盘上的Esc按键信息.
                ClickTVYaoKongExitBt(InputEventCtrl.ButtonState.UP);
            }
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.Keypad4))
        {
            //接收遥控器/键盘上的向左按键信息.
            ClickTVYaoKongLeftBt(InputEventCtrl.ButtonState.DOWN);
        }

        if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.Keypad4))
        {
            //接收遥控器/键盘上的向左按键信息.
            ClickTVYaoKongLeftBt(InputEventCtrl.ButtonState.UP);
        }

        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.Keypad6))
        {
            //接收遥控器/键盘上的向右按键信息.
            ClickTVYaoKongRightBt(InputEventCtrl.ButtonState.DOWN);
        }

        if (Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.Keypad6))
        {
            //接收遥控器/键盘上的向右按键信息.
            ClickTVYaoKongRightBt(InputEventCtrl.ButtonState.UP);
        }

        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Keypad2))
        {
            //接收遥控器/键盘上的向上按键信息.
            ClickTVYaoKongUpBt(InputEventCtrl.ButtonState.DOWN);
        }

        if (Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.Keypad2))
        {
            //接收遥控器/键盘上的向上按键信息.
            ClickTVYaoKongUpBt(InputEventCtrl.ButtonState.UP);
        }

        if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.Keypad8))
        {
            //接收遥控器/键盘上的向下按键信息.
            ClickTVYaoKongDownBt(InputEventCtrl.ButtonState.DOWN);
        }

        if (Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKeyUp(KeyCode.Keypad8))
        {
            //接收遥控器/键盘上的向下按键信息.
            ClickTVYaoKongDownBt(InputEventCtrl.ButtonState.UP);
        }

        if (Input.GetKeyUp(KeyCode.P)
            || Input.GetKeyUp(KeyCode.G)
            || Input.GetKeyUp(KeyCode.K)
            || Input.GetKeyUp(KeyCode.Return))
        {
            ClickCloseDongGanBt(InputEventCtrl.ButtonState.UP);
        }

        if (Input.GetKeyDown(KeyCode.P)
            || Input.GetKeyDown(KeyCode.G)
            || Input.GetKeyDown(KeyCode.K)
            || Input.GetKeyDown(KeyCode.Return))
        {
            ClickCloseDongGanBt(InputEventCtrl.ButtonState.DOWN);
        }

        //setPanel enter button
        //if (Input.GetKeyUp(KeyCode.F4))
        //{
        //    ClickSetEnterBt(InputEventCtrl.ButtonState.UP);
        //}

        //if (Input.GetKeyDown(KeyCode.F4))
        //{
        //    ClickSetEnterBt(InputEventCtrl.ButtonState.DOWN);
        //}

        //setPanel move button
        if (Input.GetKeyUp(KeyCode.F5))
        {
            ClickSetMoveBt(InputEventCtrl.ButtonState.UP);
            //FramesPerSecond.GetInstance().ClickSetMoveBtEvent( ButtonState.UP );
        }

        if (Input.GetKeyDown(KeyCode.F5))
        {
            ClickSetMoveBt(InputEventCtrl.ButtonState.DOWN);
            //FramesPerSecond.GetInstance().ClickSetMoveBtEvent( ButtonState.DOWN );
        }
    }
}