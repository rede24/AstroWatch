using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstroWatch.Model
{
    public class SearchModel
    {
        BL.Bl bl;

        public SearchModel()
        {
            bl = new BL.Bl();
        }
        public async Task<Dictionary<string, string>> GetSearchResult(string search)
        {
            return await bl.GetSearchResult(search);
        }
    }
}
