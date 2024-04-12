using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MOOP_Lab11
{
    public partial class Form1 : Form
    {
        private Sandwich _sandwich;

        public Form1()
        {
            InitializeComponent();
            _sandwich = new Bread();
        }

        

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            _sandwich = new Bread();

            if (checkBoxCheese.Checked)
                _sandwich = new Cheese(_sandwich);
            if (checkBoxMushrooms.Checked)
                _sandwich = new Mushrooms(_sandwich);
            if (checkBoxVegetables.Checked)
                _sandwich = new Vegetables(_sandwich);
            if (checkBoxSauces.Checked)
                _sandwich = new Sauces(_sandwich);
            if (checkBoxBacon.Checked)
                _sandwich = new Bacon(_sandwich);
            if (checkBoxSalami.Checked)
                _sandwich = new Salami(_sandwich);
            if (checkBoxHam.Checked)
                _sandwich = new Ham(_sandwich);
            if (checkBoxBeef.Checked)
                _sandwich = new Beef(_sandwich);
            if (checkBoxChicken.Checked)
                _sandwich = new Chicken(_sandwich);
            if (checkBoxFish.Checked)
                _sandwich = new Fish(_sandwich);

            textBoxPrice.Text = _sandwich.Price.ToString("C");
            textBoxDescription.Text = _sandwich.Description;
        }
    }

}
