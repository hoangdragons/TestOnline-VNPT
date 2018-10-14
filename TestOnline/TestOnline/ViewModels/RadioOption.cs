using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TestOnline.ViewModels
{
    public class RadioOption : INotifyPropertyChanged
    {
        public int IdCategory { get; set; }

        public string Content { get; }

        public string TitleCategory { get; }

        public int IdContent { get; set; }

        private bool _isSelected { get; set; }

        public bool IsSelected 
        {
            get => _isSelected;
            set
            {
                if(value != _isSelected)
                {
                    this._isSelected = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public RadioOption(int idcategory, string titleCategory, int idcontent, string content, bool isSelected = false)
        {

            this.IdCategory = idcategory;
            this.TitleCategory = titleCategory;
            this.IdContent = idcontent;
            this.Content = content;
            this.IsSelected = isSelected;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        // This method is called by the Set accessor of each property.
        // The CallerMemberName attribute that is applied to the optional propertyName
        // parameter causes the property name of the caller to be substituted as an argument.
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
