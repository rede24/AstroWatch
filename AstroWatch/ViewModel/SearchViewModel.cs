using AstroWatch.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstroWatch.ViewModel
{
    public class SearchViewModel
    {
        SearchModel searchModel;
        public SearchViewModel()
        {
            searchModel = new SearchModel();            
        }

        public void GetSearchResult(string search)
        {
            collectionUrlImages = searchModel.GetSearchResult(search).Result;            
        }

        public List<string> collectionUrlImages { get; set; }

    }
}
