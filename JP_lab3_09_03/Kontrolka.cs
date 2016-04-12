using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;

namespace JP_lab3_09_03
{
    public partial class Kontrolka : UserControl
    {
        private int _checkedControl;
        /// <summary>
        /// Sets which RadioButton is Checked. Can assign only 0 to 2
        /// </summary>
        public int checkedControl
        {
            get
            {
                return _checkedControl;
            }

            set
            {
                if (value >= 0 && value <= 2)
                {
                    _checkedControl = value;
                    checkedRB();
                }
            }
        }

        private List<object> _listBoxCollection;
        /// <summary>
        /// Returns list witch listbox items
        /// </summary>
        public List<object> listBoxCollection
        {
            get
            {
                _listBoxCollection.Clear();
                foreach (var item in listBox1.Items)
                {
                    _listBoxCollection.Add(item);
                }

                if (listBox1.Items.Count == 0)
                {
                    return _listBoxCollection = null;
                }
                return _listBoxCollection;
            }
            set
            {
                listBox1.Items.Clear();
                _listBoxCollection = value;
                if (_listBoxCollection != null)
                    foreach (var item in _listBoxCollection)
                    {
                        listBox1.Items.Add(item);
                    }
            }
        }

        /// <summary>
        /// Returns listbox items count
        /// </summary>
        public int listBoxCount
        {
            get
            {
                return listBox1.Items.Count;
            }
        }

        public Kontrolka()
        {
            InitializeComponent();
            _listBoxCollection = new List<object>();
            checkedRB();
        }

        private void checkedRB()
        {
            switch (_checkedControl)
            {
                case 0:
                    radioButton1.Checked = true;
                    break;
                case 1:
                    radioButton2.Checked = true;
                    break;
                case 2:
                    radioButton3.Checked = true;
                    break;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                int temp;
                if (int.TryParse(textBox1.Text, out temp))
                {
                    listBox1.Items.Add(temp.ToString());
                    textBox1.Text = "";
                }
                else
                {
                    MessageBox.Show("Liczba nie jest całkowita! Popraw dane.");
                }

            }
            else if (radioButton2.Checked)
            {
                double temp;
                if (double.TryParse(textBox1.Text, out temp))
                {
                    listBox1.Items.Add(temp.ToString());
                    textBox1.Text = "";
                }
                else
                {
                    MessageBox.Show("Liczba nie jest całkowita! Popraw dane.");
                }
            }
            else if (radioButton3.Checked)
            {
                listBox1.Items.Add(textBox1.Text);
                textBox1.Text = "";
            }
        }

        private void radioButton1_Click(object sender, EventArgs e)
        {
            if (checkedControl == 0)
            {
                if (radioButton2.Checked)
                {
                    if (MessageBox.Show("Zmiana typu spowoduje utratę danych w liście. Czy napewno chcesz to zrobić?", "Zmiana",
                        MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        listBox1.Items.Clear();
                        checkedControl = 1;
                    }
                }
                else if (sender.Equals(radioButton3))
                {
                    if (MessageBox.Show("Zmiana typu spowoduje utratę danych w liście. Czy napewno chcesz to zrobić?", "Zmiana",
                        MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        listBox1.Items.Clear();
                        checkedControl = 2;
                    }
                }
            }
            else if (checkedControl == 1)
            {
                if (sender.Equals(radioButton1))
                {
                    if (MessageBox.Show("Zmiana typu spowoduje utratę danych w liście. Czy napewno chcesz to zrobić?", "Zmiana",
                        MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        listBox1.Items.Clear();
                        checkedControl = 0;
                    }
                }
                else if (sender.Equals(radioButton3))
                {
                    if (MessageBox.Show("Zmiana typu spowoduje utratę danych w liście. Czy napewno chcesz to zrobić?", "Zmiana",
                        MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        listBox1.Items.Clear();
                        checkedControl = 2;
                    }
                }
            }
            else if (checkedControl == 2)
            {
                if (sender.Equals(radioButton1))
                {
                    if (MessageBox.Show("Zmiana typu spowoduje utratę danych w liście. Czy napewno chcesz to zrobić?", "Zmiana",
                        MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        listBox1.Items.Clear();
                        checkedControl = 0;
                    }
                }
                else if (sender.Equals(radioButton2))
                {
                    if (MessageBox.Show("Zmiana typu spowoduje utratę danych w liście. Czy napewno chcesz to zrobić?", "Zmiana",
                        MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        listBox1.Items.Clear();
                        checkedControl = 1;
                    }
                }
            }
            
            checkedRB();
        }
    }
}
