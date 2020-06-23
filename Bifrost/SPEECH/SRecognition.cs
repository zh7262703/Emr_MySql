using System;
using System.Speech.Recognition;
using System.Globalization;
using System.Windows.Forms;

namespace Bifrost.Speech
{
    public class SRecognition
    {
        public SpeechRecognitionEngine recognizer = null;//����ʶ������  
        public DictationGrammar dictationGrammar = null; //��Ȼ�﷨  
        public string cDisplayStr; //��ʾ�ַ��� 

        public SRecognition(string[] fg) //�����ؼ������б�  
        {
            CultureInfo myCIintl = new CultureInfo("zh-CN");//en-US 
            foreach (RecognizerInfo config in SpeechRecognitionEngine.InstalledRecognizers())//��ȡ������������  
            {
                if (config.Culture.Equals(myCIintl) && config.Id == "MS-2052-80-DESK")//MS-1033-80-DESK MS-2052-80-DESK
                {
                    recognizer = new SpeechRecognitionEngine(config);
                    break;
                }//ѡ��ʶ������
            }
            if (recognizer != null)
            {
                InitializeSpeechRecognitionEngine(fg);//��ʼ������ʶ������  
                dictationGrammar = new DictationGrammar();
            }
            else
            {
                MessageBox.Show("��������ʶ��ʧ��");
            }
        }
        private void InitializeSpeechRecognitionEngine(string[] fg)
        {
            recognizer.SetInputToDefaultAudioDevice();//ѡ��Ĭ�ϵ���Ƶ�����豸  
            Grammar customGrammar = CreateCustomGrammar(fg);
            //���ݹؼ������齨���﷨  
            recognizer.UnloadAllGrammars();
            recognizer.LoadGrammar(customGrammar);
            //�����﷨  
            recognizer.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(recognizer_SpeechRecognized);
            //recognizer.SpeechHypothesized += new EventHandler <SpeechHypothesizedEventArgs>(recognizer_SpeechHypothesized);  
        }
        public void BeginRec()//�������ڿؼ�  
        {
            TurnSpeechRecognitionOn();
            TurnDictationOn();
            //cDisplayStr = App.SpeechStr;
        }
        public void over()//ֹͣ����ʶ������  
        {
            TurnSpeechRecognitionOff();
        }

        public void RcDispose()
        {
            recognizer.Dispose();
        }

        public virtual Grammar CreateCustomGrammar(string[] fg) //�����Զ����﷨  
        {
            GrammarBuilder grammarBuilder = new GrammarBuilder();
            grammarBuilder.Append(new Choices(fg));
            return new Grammar(grammarBuilder);
        }
        private void TurnSpeechRecognitionOn()//��������ʶ����  
        {
            try
            {
                if (recognizer != null)
                {
                    recognizer.RecognizeAsync(RecognizeMode.Multiple);
                    //ʶ��ģʽΪ����ʶ��  
                }
                else
                {
                    MessageBox.Show("��������ʶ��ʧ��");
                }
            }
            catch
            { }
        }
        private void TurnSpeechRecognitionOff()//�ر�����ʶ����  
        {
            if (recognizer != null)
            {
                recognizer.RecognizeAsyncStop();
                TurnDictationOff();
            }
            else
            {
                MessageBox.Show("��������ʶ��ʧ��");
            }
        }




        private void recognizer_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            //ʶ��������ɵĶ�����ͨ����ʶ��������ĳһ���ؼ�  
            string text = e.Result.Text;
            //cDisplay.Text += text;
            // cDisplayStr = text;
            App.SpeechStr = text;
        }
        private void TurnDictationOn()
        {
            if (recognizer != null)
            {
                recognizer.LoadGrammar(dictationGrammar);
                //������Ȼ�﷨  
            }
            else
            {
                MessageBox.Show("��������ʶ��ʧ��");
            }
        }
        private void TurnDictationOff()
        {
            try
            {
                if (dictationGrammar != null)
                {
                    recognizer.UnloadGrammar(dictationGrammar);
                    //ж����Ȼ�﷨  
                }
                else
                {
                    MessageBox.Show("��������ʶ��ʧ��");
                }
            }
            catch
            { }
        }
    }
}