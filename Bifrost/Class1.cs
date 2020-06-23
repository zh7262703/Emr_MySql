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

            thread.IsBackground = true; // 作为后台线程处理惩罚
            // 不会占用机械太长的时候
            thread.Start();



            // 守候如下的时候
            thread.Join(_timeout_milliseconds);
            if (connected == true)
            {
                // 若是成功就返回TcpClient对象

                thread.Abort();

                return connection;

            }

            if (exception != null)
            {

                // 若是失败就抛失足误

                thread.Abort();

                throw exception;

            }

            else
            {

                // 同样地抛失足误

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

                // 标识表记标帜成功，返回调用者

                connected = true;

            }

            catch (Exception ex)
            {

                // 标识表记标帜失败

                exception = ex;

            }

        }

    }
}
