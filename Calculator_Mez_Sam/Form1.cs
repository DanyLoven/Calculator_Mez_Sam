using System;
using System.Data;
using System.Windows.Forms;

namespace Calculator_Mez_Sam
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            txtDisplay.Multiline = false; // Ensure Multiline is false
            txtDisplay.ScrollBars = ScrollBars.Horizontal; // Enable horizontal scrolling
        }

        // Event handler for number button clicks
        private void Number_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            txtDisplay.Text += button.Text;
            txtDisplay.SelectionStart = txtDisplay.Text.Length; // Move cursor to the end
            txtDisplay.ScrollToCaret(); // Auto-scroll to the end
        }

        // Event handler for operation button clicks
        private void Operation_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            txtDisplay.Text += " " + button.Text + " ";
            txtDisplay.SelectionStart = txtDisplay.Text.Length; // Move cursor to the end
            txtDisplay.ScrollToCaret(); // Auto-scroll to the end
        }

        // Event handler for point button click
        private void btnPoint_Click(object sender, EventArgs e)
        {
            if (!txtDisplay.Text.EndsWith("."))
            {
                txtDisplay.Text += ".";
                txtDisplay.SelectionStart = txtDisplay.Text.Length; // Move cursor to the end
                txtDisplay.ScrollToCaret(); // Auto-scroll to the end
            }
        }

        // Event handler for equals button click
        private void btnEquals_Click(object sender, EventArgs e)
        {
            try
            {
                string expression = txtDisplay.Text;

                // Replace multiplication and division symbols to be compatible with DataTable
                expression = expression.Replace("×", "*").Replace("÷", "/");

                // Use DataTable to evaluate the expression
                DataTable table = new DataTable();
                var result = table.Compute(expression, string.Empty);

                txtDisplay.Text = result.ToString();
                txtDisplay.SelectionStart = txtDisplay.Text.Length; // Move cursor to the end
                txtDisplay.ScrollToCaret(); // Auto-scroll to the end
            }
            catch (Exception)
            {
                txtDisplay.Text = "Error!";
                txtDisplay.SelectionStart = txtDisplay.Text.Length; // Move cursor to the end
                txtDisplay.ScrollToCaret(); // Auto-scroll to the end
            }
        }

        // Event handler for clear button click
        private void btnClear_Click(object sender, EventArgs e)
        {
            txtDisplay.Clear();
        }

        // Event handler for square root button click
        private void btnSqrt_Click(object sender, EventArgs e)
        {
            try
            {
                double value = double.Parse(txtDisplay.Text);
                txtDisplay.Text = Math.Sqrt(value).ToString();
                txtDisplay.SelectionStart = txtDisplay.Text.Length; // Move cursor to the end
                txtDisplay.ScrollToCaret(); // Auto-scroll to the end
            }
            catch (Exception)
            {
                txtDisplay.Text = "Error!";
                txtDisplay.SelectionStart = txtDisplay.Text.Length; // Move cursor to the end
                txtDisplay.ScrollToCaret(); // Auto-scroll to the end
            }
        }

        // Event handler for backspace button click
        private void btnBackspace_Click(object sender, EventArgs e)
        {
            if (txtDisplay.Text.Length > 0)
            {
                txtDisplay.Text = txtDisplay.Text.Substring(0, txtDisplay.Text.Length - 1);
                txtDisplay.SelectionStart = txtDisplay.Text.Length; // Move cursor to the end
                txtDisplay.ScrollToCaret(); // Auto-scroll to the end
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Initialization code, if any
        }

        private void txtDisplay_TextChanged(object sender, EventArgs e)
        {
            // Handle text changed event if needed
        }
    }
}
