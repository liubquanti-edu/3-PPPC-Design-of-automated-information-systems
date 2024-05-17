using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PR_Store
{
    /// <summary>
    /// Interaction logic for Manage.xaml
    /// </summary>
    public partial class Manage : Window
    {
        public Manage()
        {
            context = new DataContext();
            InitializeComponent();
            UpdateData();
        }

        private void Button_Click_Create_Categories(object sender, RoutedEventArgs e)
        {
            context.Categories.Add(new Category
            {
                Name = NameTextBox.Text
            });
            context.SaveChanges();
            UpdateData();
        }

        private DataContext context { get; set; }

        public void UpdateData()
        {
            List<Product> DatabaseProducts = context.Products.Include(product =>
            product.Category).ToList();
            ProductsItemList.ItemsSource = DatabaseProducts;

            List <Category> DatabaseCategories = context.Categories.ToList();
            CategoryItemList.ItemsSource = DatabaseCategories;

            CategoryComboBox.ItemsSource = DatabaseCategories;
        }

        private void Button_Click_Update_Categories(object sender, RoutedEventArgs e)
        {
            Category selectedCategory = CategoryItemList.SelectedItem as Category;

            selectedCategory.Name = NameTextBox.Text;

            context.SaveChanges();

            UpdateData();
        }

        private void Button_Click_Delete_Categories(object sender, RoutedEventArgs e)
        {
            if (CategoryItemList.SelectedItem is Category selectedCategory)
            {
                context.Categories.Remove(selectedCategory);
                context.SaveChanges();
                UpdateData();
            }
            else
            {
                MessageBox.Show("Select some row", "Error", MessageBoxButton.OK,
                MessageBoxImage.Error);
            }
        }

        private void Button_Click_Delete_Product(object sender, RoutedEventArgs e)
        {
            if (ProductsItemList.SelectedItem is Product selectedProduct)
            {
                context.Products.Remove(selectedProduct);
                context.SaveChanges();
                UpdateData();
            }
            else
            {
                MessageBox.Show("Select some row", "Error", MessageBoxButton.OK,
                MessageBoxImage.Error);
            }
        }

        private void Button_Click_Create_Products(object sender, RoutedEventArgs e)
        {
            var quantity = ProductQuantityTextBox.Text;
            var price = ProductPriceTextBox.Text;

            int.TryParse(quantity, out int intQuantity);
            int.TryParse(price, out int intPrice);

            context.Products.Add(new Product
            {
                Name = ProductNameTextBox.Text,
                Quantity = intQuantity,
                Price = intPrice,
                Category = CategoryComboBox.SelectedItem as Category
            });

            context.SaveChanges();
            UpdateData();
        }

        private void Button_Click_Update_Products(object sender, RoutedEventArgs e)
        {
            if (ProductsItemList.SelectedItem is Product selectedProduct)
            {
                var quantity = ProductQuantityTextBox.Text;
                var price = ProductPriceTextBox.Text;
                int.TryParse(quantity, out int intQuantity);
                int.TryParse(price, out int intPrice);
                selectedProduct.Name = NameTextBox.Text;
                selectedProduct.Price = intPrice;
                selectedProduct.Quantity = intQuantity;

                selectedProduct.Category = CategoryComboBox.SelectedItem as Category;
                context.SaveChanges();
                UpdateData();
            }
            else
            {
                MessageBox.Show("Select some row", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        
    }
}