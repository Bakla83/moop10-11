using NUnit.Framework;
using System;
using МООПЛР10;
using System.Windows.Forms;

namespace LAB10_Tests
{
    [TestFixture]
    public class Tests
    {
        private Subject subject;
        private Label timeLabel;
        private Label stateLabel;
        private TimeObserver timeObserver;
        private StateObserver stateObserver;

        [SetUp]
        public void Setup()
        {
            subject = new Subject();
            timeLabel = new Label();
            stateLabel = new Label();
            timeObserver = new TimeObserver(timeLabel);
            stateObserver = new StateObserver(stateLabel);
        }

        [Test]
        public void TestAttachTimeObserver()
        {
            subject.Attach(timeObserver);
            subject.Activate();
            Assert.That(timeLabel.Text, Does.StartWith("Activation Time: "));
        }

        [Test]
        public void TestDetachTimeObserver()
        {
            subject.Attach(timeObserver);
            subject.Activate();
            subject.Detach(timeObserver);
            subject.Activate();
            Assert.That(timeLabel.Text, Is.Empty);
        }

        [Test]
        public void TestAttachStateObserver()
        {
            subject.Attach(stateObserver);
            subject.Activate();
            Assert.That(stateLabel.Text, Does.StartWith("Current State: Active"));
        }

        [Test]
        public void TestDetachStateObserver()
        {
            subject.Attach(stateObserver);
            subject.Activate();
            subject.Detach(stateObserver);
            subject.State = false; // Deactivate the subject
            Assert.That(stateLabel.Text, Is.Empty);
        }

        [Test]
        public void TestActivate()
        {
            subject.Attach(timeObserver);
            subject.Attach(stateObserver);
            subject.Activate();
            Assert.That(subject.State, Is.True);
            Assert.That(timeLabel.Text, Does.StartWith("Activation Time: "));
            Assert.That(stateLabel.Text, Does.StartWith("Current State: Active"));
            Assert.That(subject.ActivationTime, Is.EqualTo(DateTime.Now).Within(1).Seconds);
        }
    }

}
