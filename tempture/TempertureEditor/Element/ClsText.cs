namespace TempertureEditor.Element
{
    /// <summary>
    ///  文字元素
    /// </summary>
    public class ClsText: ClsBase
    {
        //文字的内容
        private string _vtext;
        private string _fontid;
        private string _tdirection;

        public string Vtext
        {
            get
            {
                return _vtext;
            }

            set
            {
                _vtext = value;
            }
        }

        public string Fontid
        {
            get
            {
                return _fontid;
            }
            set
            {
                _fontid = value;
            }
        }

        /// <summary>
        /// 文字方向
        /// </summary>
        public string Tdirection
        {
            get
            {
                return _tdirection;
            }

            set
            {
                _tdirection = value;
            }
        }
    }
}
