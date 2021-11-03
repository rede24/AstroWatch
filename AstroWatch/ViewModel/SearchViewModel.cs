using AstroWatch.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AstroWatch.ViewModel
{
    public class SearchViewModel : INotifyPropertyChanged
    {
        SearchModel searchModel;
        public SearchViewModel()
        {
            searchModel = new SearchModel();
        }
        public void GetSearchResult(string search)
        {
            CollectionUrlImages = searchModel.GetSearchResult(search).Result;
        }

        Dictionary<string, string> collectionUrlImages;
        public Dictionary<string, string> CollectionUrlImages
        {
            get
            {
                if (collectionUrlImages == null)
                    collectionUrlImages = new Dictionary<string, string>();
                return collectionUrlImages;
            }
            set
            {
                collectionUrlImages = value;
                OnPropertyChanged("CollectionUrlImages");
            }

        }
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}