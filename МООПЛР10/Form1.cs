using System;
using System.Windows.Forms;

namespace МООПЛР10
{
    public partial class Form1 : Form
    {
        private Subject subject = new Subject();
        private TimeObserver timeObserver;
        private StateObserver stateObserver;

        public Form1()
        {
            InitializeComponent();

            timeObserver = new TimeObserver(labelTime);
            stateObserver = new StateObserver(labelState);

            subject.Attach(timeObserver);
            subject.Attach(stateObserver);

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void labelSubjectState_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                subject.Attach(timeObserver);
            }
            else
            {
                labelTime.Text = "";
                subject.Detach(timeObserver);
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                subject.Attach(stateObserver);
            }
            else
            {
                labelTime.Text = "";
                subject.Detach(stateObserver);
            }

        }

        private void labelObserverState_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked && checkBox2.Checked)
            {
                // Если оба CheckBox'а выбраны
                subject.Attach(timeObserver);
                subject.Attach(stateObserver);
            }
            else if (checkBox1.Checked)
            {
                // Если выбран только CheckBox для времени активации
                subject.Attach(timeObserver);
                subject.Detach(stateObserver);
            }
            else if (checkBox2.Checked)
            {
                // Если выбран только CheckBox для текущего состояния
                subject.Attach(stateObserver);
                subject.Detach(timeObserver);
            }
            else
            {
                // Если ни один CheckBox не выбран
                subject.Detach(timeObserver);
                subject.Detach(stateObserver);
            }
            subject.Activate(); // Активация субъекта при нажатии на кнопку
            UpdateObserversIndicators(); // Обновление индикаторов состояния наблюдателей
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
        private void UpdateObserversIndicators()
        {
            if (checkBox1.Checked && checkBox2.Checked)
            {
                // Если оба CheckBox'а выбраны
                timeObserver.Update(subject);
                stateObserver.Update(subject);
            }
            else if (checkBox1.Checked)
            {
                // Если выбран только CheckBox для времени активации
                timeObserver.Update(subject);
            }
            else if (checkBox2.Checked)
            {
                // Если выбран только CheckBox для текущего состояния
                stateObserver.Update(subject);
            }
           
        }

        private void checkBox1_CheckStateChanged(object sender, EventArgs e)
        {

        }
    }
}


