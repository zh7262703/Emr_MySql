using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Net.Sockets;

namespace Bifrost
{
    public class TcpClientWithTimeout
    {

        protected string _hostname;

        protected int _port;

        protected int _timeout_milliseconds;

        protected TcpClient connection;

        protected bool connected;

        protected Exception exception;



        public TcpClientWithTimeout(string hostname, int port, int timeout_milliseconds)
        {
            _hostname = hostname;
            _port = port;
            _timeout_milliseconds = timeout_milliseconds;
        }

        public TcpClient Connect()
        {

            // kick off the thread that tries to connect

            connected = false;

            exception = null;

            Thread thread = new Thread(new ThreadStart(BeginConnect));

            thread.IsBackground = true; // ��Ϊ��̨�̴߳���ͷ�
            // ����ռ�û�е̫����ʱ��
            thread.Start();



            // �غ����µ�ʱ��
            thread.Join(_timeout_milliseconds);
            if (connected == true)
            {
                // ���ǳɹ��ͷ���TcpClient����

                thread.Abort();

                return connection;

            }

            if (exception != null)
            {

                // ����ʧ�ܾ���ʧ����

                thread.Abort();

                throw exception;

            }

            else
            {

                // ͬ������ʧ����

                thread.Abort();

                string message = string.Format("TcpClient connection to {0}:{1} timed out", _hostname, _port);

                throw new TimeoutException(message);

            }

        }

        protected void BeginConnect()
        {

            try
            {

                connection = new TcpClient(_hostname, _port);

                // ��ʶ��Ǳ��ĳɹ������ص�����

                connected = true;

            }

            catch (Exception ex)
            {

                // ��ʶ��Ǳ���ʧ��

                exception = ex;

            }

        }

    }
}
