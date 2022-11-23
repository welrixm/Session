using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Test2.Pages;

namespace Test2.Components
{
    class Navigate
    {

        public string Title { get; set; }
        public Page Page { get; set; }
        public Navigate(string Title, Page Page)
        {
            this.Title = Title;
            this.Page = Page;
        }


    }
    internal class Navigation
    {
       
        public static MainWindow main; 
        public static List<Navigate> navs = new List<Navigate>(); 
        



        public static void NextPage(Navigate nav)
        {
            navs.Add(nav);
            Update(nav);
        }
        public static void BackPage()
        {
            if (navs.Count > 1)
                navs.RemoveAt(navs.Count - 1);
            Update(navs[navs.Count - 1]);

        }
        private static void Update(Navigate nav)
        {
            main.TitlePage.Text = nav.Title;
            main.BackBtn.Visibility = navs.Count > 2 ? System.Windows.Visibility.Visible : System.Windows.Visibility.Collapsed;
            main.MyFrame.Navigate(nav.Page);
        }
    }
    
}
