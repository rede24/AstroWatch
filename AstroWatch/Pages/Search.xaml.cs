using AstroWatch.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AstroWatch.Pages
{
    /// <summary>
    /// Interaction logic for Search.xaml
    /// </summary>
    public partial class Search : Page
    {
        SearchViewModel searchViewModel = null;
        public Search()
        {
            InitializeComponent();
            searchViewModel = new SearchViewModel();
            DataContext = searchViewModel;







            
        }

        private void btSearch_Click(object sender, RoutedEventArgs e)
        {
            var text = txtSearch.Text;
            progressBar.Visibility = Visibility.Visible;
            var thread = new Thread(() =>
            {
                searchViewModel.GetSearchResult(text);
                this.Dispatcher.BeginInvoke(new Action(() => {

                Resources["CollectionUrlImages"] = searchViewModel.collectionUrlImages;
                    progressBar.Visibility = Visibility.Collapsed;
                }));
            });
            thread.Start();
        }
    }
}
