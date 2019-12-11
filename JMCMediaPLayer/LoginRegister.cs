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

            //Checks the connection to the database. without connection users cannot use the application
            if (database.Connect() != true)
            {
                MessageBox.Show("Could not connect to the server!" + "/r/n"+ "Please connect to the server and restart the application.");
                btnLogIn.Enabled = false;
                btnCreateAccount.Enabled = false;
                txbUserName.Enabled = false;
                txbPassword.Enabled = false;
                txbUserNameCreate.Enabled = false;
                txbPasswordCreate.Enabled = false;

            }    
        }

        Database database = new Database();
        //List for saving the users data
        private List<User> users = new List<User>();
        //properties for dragging the form without borders
        private bool dragging = false;
        private Point startPoint = new Point(0, 0);

        
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
            if (checkBoxShowPasswordCreate.Checked)
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
                //finds the user in the database
                if(database.ValidateUser(txbUserName.Text, txbPassword.Text, out validateMessage))
                {
                    MessageBox.Show(validateMessage);
                    this.Hide();
                    JMCAudioPlayer audioPlayerform = new JMCAudioPlayer();
                    audioPlayerform.Show();

                }
                //shows the response message
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
            if (!(string.IsNullOrEmpty(txbUserNameCreate.Text)) && !(string.IsNullOrEmpty(txbPasswordCreate.Text)))
            {
                string tempUserId = txbUserNameCreate.Text;
                User tempUser = database.GetUserFromDatabase(tempUserId);
                // If method to prevent duplicate users
                if (tempUser != null)
                {
                    MessageBox.Show("This user already exist!");
                }
                else
                {
                    User user = new User(txbUserNameCreate.Text, txbPasswordCreate.Text);
                    users.Add(user);
                    database.AddUser(user);
                    txbPasswordCreate.Clear();
                    txbUserNameCreate.Clear();
                    MessageBox.Show("Account Created!");
                }
            }
            else
            {
                MessageBox.Show("Please fill the username and password textboxes!");
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
        //Methods for moving the form by mouse
        private void topPanel_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }
        //Methods for moving the form by mouse
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

