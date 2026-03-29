using System;
using System.Linq;
using System.Windows.Forms;

namespace BinaryConverter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnConvert_Click(object sender, EventArgs e)
        {
            if (rbDtoB.Checked)
            {
                int decimalNumber;
                if (int.TryParse(txtFrom.Text, out decimalNumber))
                {
                    string binaryNumber = Convert.ToString(decimalNumber, 2).PadLeft(8, '0');
                    txtTo.Text = string.Join(" ", Enumerable.Range(0, binaryNumber.Length / 8)
                    .Select(i => binaryNumber.Substring(i * 8, 8)));
                }
                else
                {
                    MessageBox.Show("Please enter a valid decimal number.");
                }
            }
            else if (rbBtoD.Checked)
            {
                try
                {
                    int decimalNumber = Convert.ToInt32(txtFrom.Text, 2);
                    txtTo.Text = decimalNumber.ToString();
                }
                catch (FormatException)
                {
                    MessageBox.Show("Please enter a valid binary number.");
                }
            }
        }
    }
}
