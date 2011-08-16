using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Text;
using System.Windows.Forms;
using Apache.NMS;
using Apache.NMS.Util;
using Apache.NMS.ActiveMQ;
using Apache.NMS.ActiveMQ.Commands;

namespace ActiveMQ_Test
{
    public partial class Form1 : Form
    {
        //private const int TICKS_SCALE = 10000;
        private const int SECOND_PER_ROUND = 30;
        private const string Broker_Name = "tcp://apc889:61616";
        private const string Client_Name = "Test_Leo1";
        private IConnection connection;
        private ISession session;
        private IMessageConsumer msg_consumer;
        private const String QUEUE_ADVISORY_DESTINATION = "ActiveMQ.Advisory.TWFE_TFHTF";
        private const String TOPIC_ADVISORY_DESTINATION = "ActiveMQ.Advisory.Topic";
        private const String TEMPQUEUE_ADVISORY_DESTINATION = "ActiveMQ.Advisory.TempQueue";
        private const String TEMPTOPIC_ADVISORY_DESTINATION = "ActiveMQ.Advisory.TempTopic";

        private const String ALLDEST_ADVISORY_DESTINATION = QUEUE_ADVISORY_DESTINATION + "," +
                                                           TOPIC_ADVISORY_DESTINATION + "," +
                                                           TEMPQUEUE_ADVISORY_DESTINATION + "," +
                                                           TEMPTOPIC_ADVISORY_DESTINATION;

        //public delegate void UIThreadDelegate();
        //private readonly Dispatcher uiThreadDispatcher = Dispatcher.CurrentDispatcher;

        public Form1()
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            IMessageProducer Msgproducer = session.CreateProducer(session.GetQueue(QUEUE_ADVISORY_DESTINATION));
            Msgproducer.DeliveryMode= MsgDeliveryMode.Persistent;
            ITextMessage message = session.CreateTextMessage("Hello World!" + listBox2.Items.Count.ToString());
            message.Properties.SetLong("Ticks", DateTime.Now.Ticks);
            listBox2.Items.Add("Hello World!" + listBox2.Items.Count.ToString());
            Msgproducer.Send(message);
            Msgproducer.Dispose();
            listBox1.Items.Add("Msg Send out");

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                int intCount = 1;
                long lStartTicks = DateTime.Parse(DateTime.Now.ToString("yyyy/MM/dd") + " 08:45:00").Ticks;
                while ((lStartTicks + TimeSpan.TicksPerSecond * SECOND_PER_ROUND) < DateTime.Now.Ticks)
                {
                    IQueueBrowser queueBrowser = session.CreateBrowser(session.GetQueue(QUEUE_ADVISORY_DESTINATION), "Ticks >= " + lStartTicks + " and Ticks < " + (lStartTicks + TimeSpan.TicksPerSecond * SECOND_PER_ROUND));
                    IEnumerator emuQueue = queueBrowser.GetEnumerator();
                    while (emuQueue.MoveNext())
                    {
                        IObjectMessage txt_msg = (IObjectMessage)emuQueue.Current;
                        listBox1.Items.Add("(" + intCount.ToString() + ")" + txt_msg.NMSMessageId + "_" + txt_msg.ToString() + "_" + txt_msg.NMSTimestamp);
                        listBox1.Items.Add(txt_msg.ToString());
                        listBox1.Items.Add(txt_msg.NMSTimestamp);
                        //listBox3.Items.Add(txt_msg.Text);
                        intCount++;
                    }
                    lStartTicks = lStartTicks + TimeSpan.TicksPerSecond * SECOND_PER_ROUND;
                    queueBrowser.Close();
                    queueBrowser.Dispose();
                }
                /*msg_consumer = session.CreateConsumer(session.GetQueue(QUEUE_ADVISORY_DESTINATION));
                while ((IMessage advisory = msg_consumer.Receive(TimeSpan.FromMilliseconds(2000))) != null)
                {
                    ITextMessage amqMsg = advisory as ITextMessage;
                    listBox1.Items.Add(amqMsg.NMSMessageId.ToString());
                    listBox1.Items.Add(amqMsg.Text);
                }
                msg_consumer.Dispose();*/
                listBox1.Items.Add("Msg Received");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "," + ex.StackTrace);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (msg_consumer != null)
            {
                msg_consumer.Dispose();
            }
            session.Close();
            session.Dispose();
            connection.Close();
            listBox1.Items.Add("Disconnect from Broker:");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            IConnectionFactory factory = new ConnectionFactory(Broker_Name, Client_Name);
            connection = factory.CreateConnection();
            connection.Start();
            session = connection.CreateSession();
            listBox1.Items.Add("Connect to Broker:");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            session.DeleteQueue(QUEUE_ADVISORY_DESTINATION);
            listBox1.Items.Add("Queue Delete");

            /*
            msg_consumer = session.CreateConsumer(session.GetQueue(QUEUE_ADVISORY_DESTINATION));
            msg_consumer.Receive();
            msg_consumer.Close();
            msg_consumer.Dispose();*/
        }


    }
}
