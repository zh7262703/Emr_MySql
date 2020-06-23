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

        //ȫ�ֵ��¼� 
        public event KeyEventHandler OnKeyDownEvent;
        public event KeyEventHandler OnKeyUpEvent;
        public event KeyPressEventHandler OnKeyPressEvent;
        static int hKeyboardHook = 0;   //���̹��Ӿ�� 
        //��곣�� 
        public const int WH_KEYBOARD_LL = 13;   //keyboard   hook   constant   
        HookProc KeyboardHookProcedure;   //�������̹����¼�����. 
        //�������̹��ӵķ��ͽṹ���� 
        [StructLayout(LayoutKind.Sequential)]
        public class KeyboardHookStruct
        {
            public int vkCode;   //��ʾһ����1��254������Ƽ����� 
            public int scanCode;   //��ʾӲ��ɨ���� 
            public int flags;
            public int time;
            public int dwExtraInfo;
        }
        //װ�ù��ӵĺ��� 
        [DllImport("user32.dll ", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        //int idHook Ҫ��װ�Ĺ������� (�ο������IdHookȡֵ)
        //HOOKPROC lpfn ���ӹ��̵�ָ�� ,Ҳ�����ص�ָ��ϵͳ��Ϣ���Ԥ�������,�붨����DLL��
        //HINSTANCE hMod Ӧ�ó���ʵ���ľ�� �����ȫ�ֹ��ӣ� hInstance��DLL�����DllMain�и���ģ���ַ�����ǰ���HookProc�Ķ�̬����ص�ַ�������0�Ϳ����ˣ������Լ��� 
        //ThreadId Ҫ��װ���ӵ��߳�ID ,ָ�������ӵ��̣߳������ȷָ����ĳ���̵߳�ID��ֻ���Ӹ��̣߳���ʱ�Ĺ��Ӽ�Ϊ�̹߳��ӣ�����ò���������Ϊ0�����ʾ�˹���Ϊ����ϵͳ�����̵߳�ȫ�ֹ��ӡ�);
        public static extern int SetWindowsHookEx(int idHook, HookProc lpfn, IntPtr hInstance, int threadId);
        //ж�¹��ӵĺ��� 
        [DllImport("user32.dll ", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern bool UnhookWindowsHookEx(int idHook);

        //��һ�����ҵĺ��� 
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
        ///   ī�ϵĹ��캯�����쵱ǰ���ʵ�����Զ�����������. 
        ///   </summary> 
        public KeyBordHook()
        {
        }
        //��������. 
        ~KeyBordHook()
        {
            Stop();
        }
        public void Start()
        {
            //��װ���̹���   
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
            //���ж�¹���ʧ�� 
            if (!(retKeyboard)) throw new Exception("UnhookWindowsHookEx   failed. ");
        }
        private int KeyboardHookProc(int nCode, Int32 wParam, IntPtr lParam)
        {
            if ((nCode >= 0) && (OnKeyDownEvent != null || OnKeyUpEvent != null || OnKeyPressEvent != null))
            {
                KeyboardHookStruct MyKeyboardHookStruct = (KeyboardHookStruct)Marshal.PtrToStructure(lParam, typeof(KeyboardHookStruct));
                //����OnKeyDownEvent 
                if (OnKeyDownEvent != null && (wParam == WM_KEYDOWN || wParam == WM_SYSKEYDOWN))
                {
                    Keys keyData = (Keys)MyKeyboardHookStruct.vkCode;
                    KeyEventArgs e = new KeyEventArgs(keyData);
                    OnKeyDownEvent(this, e);
                }

                //����OnKeyPressEvent 
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

                //����OnKeyUpEvent 
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
