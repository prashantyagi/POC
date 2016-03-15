using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
using System.Windows.Shapes;

namespace WpfApplication
{
    /// <summary>
    /// Interaction logic for ProductsWindow.xaml
    /// </summary>
    public partial class ProductsWindow : Window
    {
        private IRepository<Product> _productRepository;
        private bool _isInsert;
        private bool _isEdit;

        private List<Product> _products;

        public ProductsWindow()
        {
            InitializeComponent();

            InitializeProductRepository();
        }

        private void InitializeProductRepository()
        {
            _productRepository = new ProductLocalRepository();

            _productRepository.Add(new Product { Id = 1, Name = "First", Unit = "CASE", Rate = 10, VatPercent = 5 });
            _productRepository.Add(new Product { Id = 2, Name = "Second", Unit = "PCS", Rate = 5, VatPercent = 12.5 });
            _productRepository.Add(new Product { Id = 3, Name = "Third", Unit = "PKT", Rate = 7, VatPercent = 12.5 });
            _productRepository.Add(new Product { Id = 4, Name = "Fourth", Unit = "MTR", Rate = 6.5, VatPercent = 5 });
            _productRepository.Add(new Product { Id = 5, Name = "Fifth", Unit = "KG", Rate = 9.94, VatPercent = 12.5 });
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            dataGrid.ItemsSource = ResetProducts();
        }

        //private ObservableCollection<Product> GetProducts()
        //{
        //    return new ObservableCollection<Product>(_productRepository.FindAll().ToList());
        //}

        private IEnumerable<Product> ResetProducts()
        {
            _products = _productRepository.FindAll().ToList();
            return _products;
        }

        private void dataGrid_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {
            Product product = e.Row.DataContext as Product;
            
            if (product != null)
            {
                if (_isInsert)
                {
                    e.Row.Background = Brushes.Green;
                    //_productRepository.Add(product);
                    _isInsert = false;
                }
                else if (_isEdit)
                {
                    if (_productRepository.FindByID(product.Id) != null)
                    {
                        if (!product.Equals(_productRepository.FindByID(product.Id)))
                        {
                            e.Row.Background = Brushes.Orange;
                            //_productRepository.Update(product);
                            _isEdit = false;
                        }
                    }
                }
            }
        }

        private void dataGrid_AddingNewItem(object sender, AddingNewItemEventArgs e)
        {
            _isInsert = true;
        }

        private void dataGrid_BeginningEdit(object sender, DataGridBeginningEditEventArgs e)
        {
            _isEdit = true;
        }

        private void txtName_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            string filter = textBox.Text;
            ICollectionView collectionView = CollectionViewSource.GetDefaultView(dataGrid.ItemsSource);
            if (string.IsNullOrEmpty(filter))
            {
                collectionView.Filter = null;
            }
            else
            {
                collectionView.Filter = o => 
                {
                    Product a = o as Product;
                    if (textBox.Name == "txtName")
                    {
                        return a.Name.ToUpper().IndexOf(filter.ToUpper()) > -1;
                    }
                    else
                    {
                        return false;
                    }
                };
            }
        }
    }
}
