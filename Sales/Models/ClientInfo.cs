using Sales.Helpers;
using System.ComponentModel.DataAnnotations;

namespace Sales.Models
{
    public class ClientInfo : ValidatableBindableBase
    {
        private int _id;
        public int ID
        {
            get { return _id; }
            set { SetProperty(ref _id, value); }
        }

        private int _categoryID;
        public int CategoryID
        {
            get { return _categoryID; }
            set { SetProperty(ref _categoryID, value); }
        }

        private int _clientID;
        public int ClientID
        {
            get { return _clientID; }
            set { SetProperty(ref _clientID, value); }
        }

        private decimal? _price;
        [Required(ErrorMessage = "السعر مطلوب")]
        [Range(0, double.MaxValue)]
        public decimal? Price
        {
            get { return _price; }
            set { SetProperty(ref _price, value); }
        }

        private string _color;
        public string Color
        {
            get { return _color; }
            set { SetProperty(ref _color, value); }
        }

        private string _notes;
        public string Notes
        {
            get { return _notes; }
            set { SetProperty(ref _notes, value); }
        }

        public virtual Client Client { get; set; }
        public virtual Category Category { get; set; }

    }
    public class ClientInfoVM : ValidatableBindableBase
    {
        private int _categoryID;
        public int CategoryID
        {
            get { return _categoryID; }
            set { SetProperty(ref _categoryID, value); }
        }

        private int _clientID;
        public int ClientID
        {
            get { return _clientID; }
            set { SetProperty(ref _clientID, value); }
        }

        private string _category;
        public string Category
        {
            get { return _category; }
            set { SetProperty(ref _category, value); }
        }

        private string _color;
        public string Color
        {
            get { return _color; }
            set { SetProperty(ref _color, value); }
        }

        private decimal? _price;
        public decimal? Price
        {
            get { return _price; }
            set { SetProperty(ref _price, value); }
        }

        private string _notes;
        public string Notes
        {
            get { return _notes; }
            set { SetProperty(ref _notes, value); }
        }
    }
}
