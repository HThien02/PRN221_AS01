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
    /// Interaction logic for MemberManagement.xaml
    /// </summary>
    public partial class MemberManagement : Window
    {
        private readonly IProductRepository _productRepository;
        private readonly IMemberRepository _memberRepository;
        private readonly IOrderRepository _orderRepository;
        
        public MemberManagement(IProductRepository productRepository, IMemberRepository memberRepository, IOrderRepository orderRepository)
        {
            _productRepository = productRepository;
            _memberRepository = memberRepository;
            _orderRepository = orderRepository;
            InitializeComponent();
        }

        private Member getMemberInfo()
        {
            Member member = null;
            try
            {
                member = new Member
                {
                    MemberId = String.IsNullOrEmpty(txtMemberId.Text) ? 0 : int.Parse(txtMemberId.Text),
                    Email = txtEmail.Text,
                    CompanyName = txtCompanyName.Text,
                    City = txtCity.Text,
                    Country = txtCountry.Text,
                    Password = txtPassword.Text
                };
            }
            catch (Exception ex)
            {
                throw new Exception("Error getting member: " + ex.Message);
            }
            return member;
        }

        private void LoadMemberList()
        {
            lvMembers.ItemsSource = _memberRepository.GetAllMembers();
        }

        private void btnLoad_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                LoadMemberList();
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
                Member member = getMemberInfo();
                _memberRepository.AddMember(member);
                LoadMemberList();
                MessageBox.Show($"Add account {member.Email} successfully");
            }
            catch (Exception ex)
            {
                throw new Exception("Error adding member: " + ex.Message);
            }

        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Member member = getMemberInfo();
                _memberRepository.UpdateMember(member);
                LoadMemberList();
                MessageBox.Show("Edit member successfully");
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating member: " + ex.Message);
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Member member = getMemberInfo();
                _memberRepository.DeleteMember(member);
                LoadMemberList();
                MessageBox.Show($"Deletee member #{member.MemberId} successfully");
            }
            catch (Exception ex)
            {
                throw new Exception("Error deleting member" + ex.Message);
            }
        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            Login login = new Login(_productRepository, _memberRepository, _orderRepository);
            login.Show();
            this.Close();
        }

        private void btnLoadOrders_Click(object sender, RoutedEventArgs e)
        {
            OrderManagement orderManagement = new OrderManagement(_productRepository, _memberRepository, _orderRepository);
            orderManagement.Show();
            this.Close();
        }

        private void btnLoadProducts_Click(object sender, RoutedEventArgs e)
        {
            ProductManagement productManagement = new ProductManagement(_productRepository, _memberRepository, _orderRepository);
            productManagement.Show();
            this.Close();
        }
    }
}
