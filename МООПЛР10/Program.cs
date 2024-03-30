using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace МООПЛР10
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }

    // Интерфейс для наблюдателя
    interface IObserver
    {
        void Update(ISubject subject);
    }

    // Интерфейс для субъекта
    interface ISubject
    {
        void Attach(IObserver observer);
        void Detach(IObserver observer);
        void Notify();
    }

    // Реализация субъекта
    class Subject : ISubject
    {
        private List<IObserver> observers = new List<IObserver>();
        private bool state;
        private DateTime activationTime;

        public bool State
        {
            get { return state; }
            set
            {
                if (value != state)
                {
                    state = value;
                    Notify();
                }
            }
        }

        public DateTime ActivationTime
        {
            get { return activationTime; }
        }

        public void Attach(IObserver observer)
        {
            observers.Add(observer);
        }

        public void Detach(IObserver observer)
        {
            observers.Remove(observer);
        }

        public void Notify()
        {
            foreach (IObserver observer in observers)
            {
                observer.Update(this);
            }
        }

        public void Activate()
        {
            state = true;
            activationTime = DateTime.Now;
            Notify();
        }
    }

    // Реализация наблюдателя для отображения времени активации субъекта
    class TimeObserver : IObserver
    {
        private Label label;

        public TimeObserver(Label label)
        {
            this.label = label;
        }

        public void Update(ISubject subject)
        {
            if (subject is Subject)
            {
                Subject realSubject = (Subject)subject;
                label.Text = "Activation Time: " + realSubject.ActivationTime.ToString();
            }
        }
    }

    // Реализация наблюдателя для отображения текущего состояния субъекта
    class StateObserver : IObserver
    {
        private Label label;

        public StateObserver(Label label)
        {
            this.label = label;
        }

        public void Update(ISubject subject)
        {
            if (subject is Subject)
            {
                Subject realSubject = (Subject)subject;
                label.Text = "Current State: " + (realSubject.State ? "Active" : "Inactive");
            }
        }
    }

}