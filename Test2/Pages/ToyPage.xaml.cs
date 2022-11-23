using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
using Test2.Components;

namespace Test2.Pages
{
    /// <summary>
    /// Логика взаимодействия для ToyPage.xaml
    /// </summary>
    public partial class ToyPage : Page
    {
        int actualPage = 0;
        public ToyPage()
        {
            InitializeComponent();
            

            ToyList.ItemsSource = DBConnect.db.Toy.Where(x => x.IsAvailable == true || x.IsAvailable == null).ToList();
            GeneralCount.Text = DBConnect.db.Toy.Where(x => x.IsAvailable != true).Count().ToString();
        }

        public static List<Toy> ItemSource { get; private set; }
        private void Refresh()
        {
            IEnumerable<Toy> filterToy = DBConnect.db.Toy.Where(x => x.IsAvailable == true);
            if (SortCostCb.SelectedIndex > 0)
            {
                if (SortCostCb.SelectedIndex == 1)
                    filterToy = filterToy.OrderBy(x => x.Cost);
                else
                    filterToy = filterToy.OrderByDescending(x => x.Cost);
            }


            

            

            ToyList.ItemsSource = filterToy.ToList();
            FoundCount.Text = filterToy.Count().ToString() + " из ";

        }
        //ToyList.ItemsSource = filterToy.ToList();



        private void DiscountSortCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            Refresh();
        }

        private void AddToyBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CreateBtn_Click(object sender, RoutedEventArgs e)
        {
            var selToy = (sender as Button).DataContext as Toy;
           // Navigation.NextPage(new Navigate("Редактирование игрушки", new AddToyPage(selToy)));
        }

        

        



        private void LeftBtn_Click(object sender, RoutedEventArgs e)
        {
            actualPage--;
            if (actualPage < 0)
                actualPage = 0;
            Refresh();


        }

        private void RightBtn_Click(object sender, RoutedEventArgs e)
        {
            actualPage++;
            Refresh();
        }

        private void CountCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            actualPage = 0;
            Refresh();
        }



       

        private void SortCostCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

       

        private void CreateBtn_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        

        private void AddToyBtn_Click_1(object sender, RoutedEventArgs e)
        {
            //Navigation.NextPage(new Navigate("Добавление игрушки", new AddToyPage(new Toy())));
        }
    }
    
}
