using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Reflection;
using System.Diagnostics;
using System.Threading;

namespace Bifrost
{
    public class KeyBordHook
    {
        private const int WM_KEYDOWN = 0x100;
        private const int WM_KEYUP = 0x101;
        private const int WM_SYSKEYDOWN = 0x104;
        private const int WM_SYSKEYUP = 0x105;

        //全局的事件 
        public event KeyEventHandler OnKeyDownEvent;
        public event KeyEventHandler OnKeyUpEvent;
        public event KeyPressEventHandler OnKeyPressEvent;
        static int hKeyboardHook = 0;   //键盘钩子句柄 
        //鼠标常量 
        public const int WH_KEYBOARD_LL = 13;   //keyboard   hook   constant   
        HookProc KeyboardHookProcedure;   //声明键盘钩子事件类型. 
        //声明键盘钩子的封送结构类型 
        [StructLayout(LayoutKind.Sequential)]
        public class KeyboardHookStruct
        {
            public int vkCode;   //表示一个在1到254间的虚似键盘码 
            public int scanCode;   //表示硬件扫描码 
            public int flags;
            public int time;
            public int dwExtraInfo;
        }
        //装置钩子的函数 
        [DllImport("user32.dll ", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        //int idHook 要安装的钩子类型 (参考下面的IdHook取值)
        //HOOKPROC lpfn 钩子过程的指针 ,也即拦截到指定系统消息后的预处理过程,须定义在DLL中
        //HINSTANCE hMod 应用程序实例的句柄 如果是全局钩子， hInstance是DLL句柄（DllMain中给的模块地址。就是包含HookProc的动态库加载地址。否则给0就可以了，即勾自己。 
        //ThreadId 要安装钩子的线程ID ,指定被监视的线程，如果明确指定了某个线程的ID就只监视该线程，此时的钩子即为线程钩子；如果该参数被设置为0，则表示此钩子为监视系统所有线程的全局钩子。);
        public static extern int SetWindowsHookEx(int idHook, HookProc lpfn, IntPtr hInstance, int threadId);
        //卸下钩子的函数 
        [DllImport("user32.dll ", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern bool UnhookWindowsHookEx(int idHook);

        //下一个钩挂的函数 
        [DllImport("user32.dll ", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern int CallNextHookEx(int idHook, int nCode, Int32 wParam, IntPtr lParam);
        [DllImport("user32 ")]
        public static extern int ToAscii(int uVirtKey, int uScanCode, byte[] lpbKeyState, byte[] lpwTransKey, int fuState);
        [DllImport("user32 ")]
        public static extern int GetKeyboardState(byte[] pbKeyState);
        public delegate int HookProc(int nCode, Int32 wParam, IntPtr lParam);
        [DllImport("kernel32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr GetModuleHandle(string lpModuleName);
        
        [DllImport("kernel32.dll")]
        static extern int GetCurrentThreadId(); 
        ///   <summary> 
        ///   墨认的构造函数构造当前类的实例并自动的运行起来. 
        ///   </summary> 
        public KeyBordHook()
        {
        }
        //析构函数. 
        ~KeyBordHook()
        {
            Stop();
        }
        public void Start()
        {
            //安装键盘钩子   
            if (hKeyboardHook == 0)
            {
                KeyboardHookProcedure = new HookProc(KeyboardHookProc);
                Process cProcess = Process.GetCurrentProcess();
                ProcessModule cModule = cProcess.MainModule;
                IntPtr mh = GetModuleHandle(cModule.ModuleName);
                hKeyboardHook = SetWindowsHookEx(WH_KEYBOARD_LL, KeyboardHookProcedure, mh, 0);
                if (hKeyboardHook == 0)
                {
                    Stop();
                    throw new Exception("SetWindowsHookEx   ist   failed. ");
                }
            }
        }
        public void Stop()
        {
            bool retKeyboard = true;

            if (hKeyboardHook != 0)
            {
                retKeyboard = UnhookWindowsHookEx(hKeyboardHook);
                hKeyboardHook = 0;
            }
            //如果卸下钩子失败 
            if (!(retKeyboard)) throw new Exception("UnhookWindowsHookEx   failed. ");
        }
        private int KeyboardHookProc(int nCode, Int32 wParam, IntPtr lParam)
        {
            if ((nCode >= 0) && (OnKeyDownEvent != null || OnKeyUpEvent != null || OnKeyPressEvent != null))
            {
                KeyboardHookStruct MyKeyboardHookStruct = (KeyboardHookStruct)Marshal.PtrToStructure(lParam, typeof(KeyboardHookStruct));
                //引发OnKeyDownEvent 
                if (OnKeyDownEvent != null && (wParam == WM_KEYDOWN || wParam == WM_SYSKEYDOWN))
                {
                    Keys keyData = (Keys)MyKeyboardHookStruct.vkCode;
                    KeyEventArgs e = new KeyEventArgs(keyData);
                    OnKeyDownEvent(this, e);
                }

                //引发OnKeyPressEvent 
                if (OnKeyPressEvent != null && wParam == WM_KEYDOWN)
                {
                    byte[] keyState = new byte[256];
                    GetKeyboardState(keyState);
                    byte[] inBuffer = new byte[2];
                    if (ToAscii(MyKeyboardHookStruct.vkCode,
                      MyKeyboardHookStruct.scanCode,
                      keyState,
                      inBuffer,
                      MyKeyboardHookStruct.flags) == 1)
                    {
                        KeyPressEventArgs e = new KeyPressEventArgs((char)inBuffer[0]);
                        OnKeyPressEvent(this, e);
                    }
                }

                //引发OnKeyUpEvent 
                if (OnKeyUpEvent != null && (wParam == WM_KEYUP || wParam == WM_SYSKEYUP))
                {
                    Keys keyData = (Keys)MyKeyboardHookStruct.vkCode;
                    KeyEventArgs e = new KeyEventArgs(keyData);
                    OnKeyUpEvent(this, e);
                }
            }
            return CallNextHookEx(hKeyboardHook, nCode, wParam, lParam);
        }
    }
}
