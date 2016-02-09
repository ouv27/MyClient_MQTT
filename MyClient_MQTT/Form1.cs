using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;

namespace MyClient_MQTT
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                MqttClient client = new MqttClient("m20.cloudmqtt.com:18478");
                byte code = client.Connect("MyClient_MQTT", "xzofiqbg", "igNpeCm_8j6f");
                client.MqttMsgPublished += client_MqttMsgPublished;
                ushort msgId = client.Publish("/my_topic", // topic
                              Encoding.UTF8.GetBytes("MyMessageBody"), // message body
                              MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, // QoS level
                              false); // retained

            }
            catch
            {
                textBox1.Text = "Erreur catch";
            }
        }

        void client_MqttMsgPublished(object sender, MqttMsgPublishedEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("MessageId = " + e.MessageId + " Published = " + e.IsPublished);
        }


    }
}
