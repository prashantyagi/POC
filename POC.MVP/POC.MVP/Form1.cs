using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POC.MVP
{
    public partial class Form1 : Form, ICalculate
    {
        private CalculatePresenter _presenter;

        public Form1()
        {
            InitializeComponent();
            _presenter = new CalculatePresenter(this);
        }

        public string Output {
            set
            {
                lblActualOutput.Text = value;
            }
        }

        public string X { get { return this.txtX.Text; } }

        public string Y { get { return this.txtY.Text; } }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            _presenter.CalculateOutput();
        }
    }

    public interface ICalculate
    {
        string X { get; }
        string Y { get; }
        string Output { set; }
    }

    public class CalculatePresenter
    {
        private ICalculate _view;

        public CalculatePresenter(ICalculate view)
        {
            _view = view;
        }

        public void CalculateOutput()
        {
            int x, y;
            int.TryParse(_view.X, out x);
            int.TryParse(_view.Y, out y);
            _view.Output = (x + y).ToString();
        }
    }
}
