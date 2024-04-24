using System;

namespace BookShop.Model
{
    /// <summary>
    /// 图书信息表
    /// </summary>
    [Serializable]
    public class BooksInfo
    {
        public BooksInfo()
        { }
        #region Model
        private int _id;
        private string _title;
        private string _author;
        private PublishersInfo _publishers;
        private DateTime _publishdate;
        private string _isbn;
        private int _wordscount;
        private decimal _unitprice;
        private string _contentdescription;
        private string _authordescription;
        private string _editorcomment;
        private string _toc;
        private CategoriesInfo _categories;
        private int _clicks = 0;
        private string _imgurl;
        private int _deleteflag = 0;
        /// <summary>
        /// 
        /// </summary>
        public int Id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Title
        {
            set { _title = value; }
            get { return _title; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Author
        {
            set { _author = value; }
            get { return _author; }
        }
        /// <summary>
        /// 
        /// </summary>
        public PublishersInfo Publishers
        {
            set {_publishers = value; }
            get { return _publishers; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime PublishDate
        {
            set { _publishdate = value; }
            get { return _publishdate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ISBN
        {
            set { _isbn = value; }
            get { return _isbn; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int WordsCount
        {
            set { _wordscount = value; }
            get { return _wordscount; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal UnitPrice
        {
            set { _unitprice = value; }
            get { return _unitprice; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ContentDescription
        {
            set { _contentdescription = value; }
            get { return _contentdescription; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string AuthorDescription
        {
            set { _authordescription = value; }
            get { return _authordescription; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string EditorComment
        {
            set { _editorcomment = value; }
            get { return _editorcomment; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string TOC
        {
            set { _toc = value; }
            get { return _toc; }
        }
        /// <summary>
        /// 
        /// </summary>
        public CategoriesInfo Categories
        {
            set { _categories = value; }
            get { return _categories; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int Clicks
        {
            set { _clicks = value; }
            get { return _clicks; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ImgUrl
        {
            set { _imgurl = value; }
            get { return _imgurl; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int DeleteFlag
        {
            set { _deleteflag = value; }
            get { return _deleteflag; }
        }
        #endregion Model

    }
}
