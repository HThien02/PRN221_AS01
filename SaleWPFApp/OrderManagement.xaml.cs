using BusinessObject.DataAccess;
using DataAccess.Repository;
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
using System.Windows.Shapes;

namespace SaleWPFApp
{
    /// <summary>
    /// Interaction logic for OrderManagement.xaml
    /// </summary>
    public partial class OrderManagement : Window
    {
        private readonly IProductRepository _productRepository;
        private readonly IMemberRepository _memberRepository;
        private readonly IOrderRepository _orderRepository;

        public OrderManagement(IProductRepository productRepository, IMemberRepository memberRepository, IOrderRepository orderRepository)
        {
            _productRepository = productRepository;
            _memberRepository = memberRepository;
            _orderRepository = orderRepository;
            InitializeComponent();
        }

        private Order getOrderInfo()
        {
            Order order = null;
            try
            {
                order = new Order
                {
                    OrderId = String.IsNullOrEmpty(txtOrderId.Text) ? 0 : int.Parse(txtOrderId.Text),
                    MemberId = int.Parse(txtMemberId.Text),
                    OrderDate = DateTime.Parse(txtOrderDate.Text),
                    RequiredDate = DateTime.Parse(txtRequiredDate.Text),
                    ShippedDate = DateTime.Parse(txtShippedDate.Text),
                    Freight = decimal.Parse(txtFreight.Text)
                };
            }
            catch (Exception ex)
            {
                throw new Exception("Error getting order: " + ex.Message);
            }
            return order;
        }

        private void LoadOrderList()
        {
            lvOrders.ItemsSource = _orderRepository.GetAllOrders();
        }

        private void btnLoad_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                LoadOrderList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void btnInsert_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Order order = getOrderInfo();
                _orderRepository.AddOrder(order);
                LoadOrderList();
                MessageBox.Show($"Add order #{order.OrderId} successfully");
            }
            catch (Exception ex)
            {
                throw new Exception("Error adding order: " + ex.Message);
            }

        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Order order = getOrderInfo();
                _orderRepository.UpdateOrder(order);
                LoadOrderList();
                MessageBox.Show($"Edit order successfully");
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating order: " + ex.Message);
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Order order = getOrderInfo();
                _orderRepository.DeleteOrder(order);
                LoadOrderList();
                MessageBox.Show($"Deletee order #{order.OrderId} successfully");
            }
            catch (Exception ex)
            {
                throw new Exception("Error deleting order" + ex.Message);
            }
        }
        private void btnSearchByDate_Click(object sender, RoutedEventArgs e)
        {
            if (txtStartDate.Text == "" || txtEndDate.Text == "")
            {
                MessageBox.Show("Please enter start and end date");
            }
            else
            {
                string startDate = txtStartDate.SelectedDate.Value.ToString("yyyy-MM-dd");
                string endDate = txtEndDate.SelectedDate.Value.ToString("yyyy-MM-dd");

                lvOrders.ItemsSource = _orderRepository.GetOrdersByDate(
                    DateTime.Parse(startDate), DateTime.Parse(endDate));
            }

        }

        private void btnLoadProducts_Click(object sender, RoutedEventArgs e)
        {
            ProductManagement productManagement = new ProductManagement(_productRepository, _memberRepository, _orderRepository);
            productManagement.Show();
            this.Close();
        }
        private void btnLoadMembers_Click(object sender, RoutedEventArgs e)
        {
            MemberManagement member = new MemberManagement(_productRepository, _memberRepository, _orderRepository);
            member.Show();
            this.Close();
        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            Login login = new Login(_productRepository, _memberRepository, _orderRepository);
            login.Show();
            this.Close();
        }

    }
}
