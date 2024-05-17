using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Microsoft.EntityFrameworkCore;

namespace Store
{
    public partial class Manage : Window
    {
        private DataContext context { get; set; }


        public Manage()
        {
            context = new DataContext();
            InitializeComponent();
            UpdateData();
        }

        public void UpdateData()
        {
            List<Product> DatabaseProducts = context.Products.Include(product => product.Category).ToList();
            ProductsItemList.ItemsSource = DatabaseProducts;
            List<Category> DatabaseCategories = context.Categories.ToList();
            CategoryItemList.ItemsSource = DatabaseCategories;
            CategoryComboBox.ItemsSource = DatabaseCategories;
        }

        private void CreateCategory_Click(object sender, RoutedEventArgs e)
        {
            context.Categories.Add(new Category
            {
                Name = NameTextBox.Text
            });
            context.SaveChanges();
            UpdateData();
        }

        private void UpdateCategory_Click(object sender, RoutedEventArgs e)
        {
            if (CategoryItemList.SelectedItem is Category selectedCategory)
            {
                selectedCategory.Name = NameTextBox.Text;
                context.SaveChanges();
                UpdateData();
            }
            else
            {
                MessageBox.Show("Select some row", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void DeleteCategory_Click(object sender, RoutedEventArgs e)
        {
            if (CategoryItemList.SelectedItem is Category selectedCategory)
            {
                context.Categories.Remove(selectedCategory);
                context.SaveChanges();
                UpdateData();
            }
            else
            {
                MessageBox.Show("Select some row", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void CreateProduct_Click(object sender, RoutedEventArgs e)
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

        private void UpdateProduct_Click(object sender, RoutedEventArgs e)
        {
            if (ProductsItemList.SelectedItem is Product selectedProduct)
            {
                var quantity = ProductQuantityTextBox.Text;
                var price = ProductPriceTextBox.Text;
                int.TryParse(quantity, out int intQuantity);
                int.TryParse(price, out int intPrice);

                selectedProduct.Name = ProductNameTextBox.Text;
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

        private void DeleteProduct_Click(object sender, RoutedEventArgs e)
        {
            if (ProductsItemList.SelectedItem is Product selectedProduct)
            {
                context.Products.Remove(selectedProduct);
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
