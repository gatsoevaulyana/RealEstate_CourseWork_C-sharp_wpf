﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RealEstate
{
    public partial class AddNewClient : Form
    {
        private readonly RealEstate _realEstate;
        public AddNewClient()
        {
            InitializeComponent();
        }
        public AddNewClient(RealEstate realEstate)
        {
            _realEstate = realEstate;
            InitializeComponent();
        }


        private void AddNewClient_Load(object sender, EventArgs e)
        {
            this.clientName.Text = "Name";
            this.clientSurname.Text = "LastName";
            this.phoneNumber.Text = "123456";
            this.bankAccount.Text = "123456";
            this.status.Text = "Closed";
            this.price.Text = "123456";
        }
         
        public List<string> realClientsComponents = new List<string>();
        const string REQUIRED_FIELDS = "All Fields are required!";
        public bool isHandled = false;

      

        private void closeForm_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /**
         * Validates user input
         * Populate List that will be used for initialisation
         * set its status to handled
         * and trigger event to the parent component
         * 
         * @throw Exception
         */


        /**
         * Data Handler that will add every value to the List<object> realEstateComponents
         * further used for class Initialisation and DataGrid visualisation
         */
        private void HandleData(List<TextBox> inputData)
        {
            foreach (TextBox textBox in inputData)
            {
                this.realClientsComponents.Add(textBox.Text);
               
            }
        }

        /**
         * Boolean Check for empty TextBox
         */
        private bool IsEmpty(TextBox tx)
        {
            return tx.TextLength == 0;
        }

        /**
         * Validates all inputs so there wont be any empty values
         * That will break Class Initialisation
         */
        private void ValidateInput(List<TextBox> textBoxes)
        {
            foreach (TextBox textBox in textBoxes)
            {
                if (this.IsEmpty(textBox))
                {
                    throw new Exception(REQUIRED_FIELDS);
                }
            }
        }

        private void AddNewRealEstate_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void saveEntry_Click(object sender, EventArgs e)
        {
            _realEstate.comboBox1.SelectedIndex = 0;


            List<TextBox> inputData = new List<TextBox> {
                clientName,phoneNumber,clientSurname,bankAccount,status, price
            };
            List<string> inputData1 = new List<string> {
                clientName.Text,phoneNumber.Text,clientSurname.Text,bankAccount.Text,status.Text, price.Text
            };
            //try
            //{
            this.ValidateInput(inputData);
            this.HandleData(inputData);
            this.isHandled = true;

            BL.Client.AddClient(inputData1);
            RealEstate parent = (RealEstate)this.Owner;
            parent.handledClientForm(this);
            this.Close();
            //}
            //catch (Exception ex)
            //{
            //    string msg = ex.Message;

            //    MessageBox.Show(msg);
            //}
        }

            private void closeForm_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void clientName_TextChanged(object sender, EventArgs e)
        {

        }

        private void phoneNumber_TextChanged(object sender, EventArgs e)
        {


        }

        private void clientSurname_TextChanged(object sender, EventArgs e)
        {


        }

        private void bankAccount_TextChanged(object sender, EventArgs e)
        {
 


        }

        private void status_TextChanged(object sender, EventArgs e)
        {


        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
