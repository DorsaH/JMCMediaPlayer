using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



//Dorsa Hemmati
//ID : 30004895 
// AT3 Project

namespace JMCMediaPLayer
{
    public partial class LoginRegister : Form
    {
        public LoginRegister()
        {
            InitializeComponent();

            if (database.Connect() != true)
            {
                MessageBox.Show("Could not connect to the server!");
            }
            //Admin user
            User adminUser = new User("JMCAdmin", "JMC2019");
            users.Add(adminUser);
            database.AddUser(adminUser);
        }

        Database database = new Database();
        //List for saving the users data
        private List<User> users = new List<User>();
        //properties for dragging the form without borders
        private bool dragging = false;
        private Point startPoint = new Point(0, 0);

        private HashComputer HashComputer = new HashComputer();
        private ASCIIEncoding encoder = new ASCIIEncoding();




        /// <summary>
        /// Method to find the user object form the users list by given User Id
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        public object GetUser(string userid)
        {
            object user = users.SingleOrDefault(u => u.UserName == userid);
            if (user == null)
            {
                return null;
            }
            else
                return user;
        }

        #region Form Methods

        //Method for showing or hiding the password
        private void checkBoxShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxShowPassword.Checked)
            {
                txbPassword.UseSystemPasswordChar = false;
            }
            else
            {
                txbPassword.UseSystemPasswordChar = true;
            }
        }
        //Method for showing or hiding the password
        private void checkBoxShowPasswordCreate_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxShowPassword.Checked)
            {
                txbPasswordCreate.UseSystemPasswordChar = false;
            }
            else
            {
                txbPasswordCreate.UseSystemPasswordChar = true;
            }
        }

        //Method for login button
        private void btnLogIn_Click(object sender, EventArgs e)
        {
            if (!(string.IsNullOrEmpty(txbUserName.Text)) && !(string.IsNullOrEmpty(txbPassword.Text)))
            {
                string validateMessage;
                if(database.ValidateUser(txbUserName.Text, txbPassword.Text, out validateMessage))
                {
                    MessageBox.Show(validateMessage);
                    this.Hide();
                    JMCAudioPlayer audioPlayerform = new JMCAudioPlayer();
                    audioPlayerform.Show();

                }
                else
                {
                    MessageBox.Show(validateMessage);
                }
            }
            else
            {
                MessageBox.Show("Please fill the username and password textboxes!");
            }
                txbUserName.Clear();
                txbPassword.Clear();
            
        }
        //Method to create an account 
        private void btnCreateAccount_Click(object sender, EventArgs e)
        {
            
            string tempUserId = txbUserNameCreate.Text;
            User tempUser = (User)GetUser(tempUserId);
            if (tempUser != null)
            {
                MessageBox.Show("This user already exist!");
            }
            else
            {
                User user = new User(txbUserNameCreate.Text, txbPasswordCreate.Text);
                users.Add(user);
                txbPasswordCreate.Clear();
                txbUserNameCreate.Clear();
                MessageBox.Show("Account Created!");
            }
        }
        //Method to close the form
        private void btnCloseForm_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //Methods for moving the form by mouse
        private void topPanel_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            startPoint = new Point(e.X, e.Y);
        }

        private void topPanel_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }

        private void topPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point p = PointToScreen(e.Location);
                Location = new Point(p.X - this.startPoint.X, p.Y - this.startPoint.Y);
            }
        }



        #endregion

    }//end of class
}//end of namespace

/*
 * 
                //validate the data

                User tempUser = (User)GetUser(tempUserId);
                string tempUserId = txbUserName.Text;
                if (tempUser == null)
                {
                    MessageBox.Show("User : " + tempUserId + " does not exist! ");

                }
                else if (tempUser != null)
                {
                    string tempPassword = txbPassword.Text;
                    bool passwordValidate = HashComputer.isPasswordMatch(tempPassword, tempUser.Salt, tempUser.PasswordHash);

                    if (passwordValidate)
                    {
                        MessageBox.Show("Password Matched" + "\n" + "Login as " + tempUser.UserName + "\r\n");
                        this.Hide();
                        JMCAudioPlayer audioPlayerform = new JMCAudioPlayer();
                        audioPlayerform.Show();
                    }
                    else
                    {
                        MessageBox.Show("Password did not match!" + "\n" + "Please try again!\n");
                    }
                    */