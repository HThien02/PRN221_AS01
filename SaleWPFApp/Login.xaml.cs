using BusinessObject.DataAccess;
using DataAccess.Repository;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
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
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        private readonly IProductRepository _productRepository;
        private readonly IMemberRepository _memberRepository;
        private readonly IOrderRepository _orderRepository;

        public Login(IProductRepository productRepository, IMemberRepository memberRepository, IOrderRepository orderRepository)
        {
            _productRepository = productRepository;
            _memberRepository = memberRepository;
            _orderRepository = orderRepository;
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            String email = txtEmail.Text;
            String password = txtPassword.Password;
            var account = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("account");

            if (email != null && password != null)
            {
                // admin access
                if (email.Equals(account["email"]) && password.Equals(account["password"]))
                {
                    Hide();
                    ProductManagement productManagement = new ProductManagement(_productRepository, _memberRepository, _orderRepository);
                    productManagement.Show();

                }
                // normal access
                else
                {
                    //Member member = _memberRepository.getMemberByEmail(email, password);
                    //if (member != null)
                    //{
                    //    Hide();
                    //    ProfileManagement profileManagement = new ProfileManagement(_productRepository, _memberRepository, _orderRepository, email, password);
                    //    profileManagement.Show();
                    //}
                    //else
                    //{
                    //    MessageBox.Show("Email or password is incorrect");
                    //}

                }
            }
            else
            {
                MessageBox.Show("Please enter email and password");
            }
        }
    }
}
