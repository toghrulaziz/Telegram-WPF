using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Telegram_WPF.Models;


namespace Telegram_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {

        public ObservableCollection<Person> People { get; set; } = new ObservableCollection<Person>();
        public ObservableCollection<Message> Messages { get; set; } = new ObservableCollection<Message>();

        public MainWindow()
        {



            Person p1 = new() { Name = "Elon", Surname = "Musk", Avatar = @"https://upload.wikimedia.org/wikipedia/commons/thumb/3/34/Elon_Musk_Royal_Society_%28crop2%29.jpg/1200px-Elon_Musk_Royal_Society_%28crop2%29.jpg", LastMessage = "hi" };

            Person p2 = new() { Name = "Donald", Surname = "Trump", Avatar = @"https://upload.wikimedia.org/wikipedia/commons/5/56/Donald_Trump_official_portrait.jpg", LastMessage = "hi" };



            Message m1 = new Message() { Text = "Salam", DateTime = DateTime.Now };

            Message m2 = new Message() { Text = "Necesen?", DateTime = DateTime.Now };


            List<Message> messagesP1 = new List<Message>() { m1, m2 };
            List<Message> messagesP2 = new List<Message>() { m1, m2 };


            p1.Messages = messagesP1;
            p2.Messages = messagesP2;

            People.Add(p1);
            People.Add(p2);

            Messages.Add(m1);
            Messages.Add(m2);

            var people = People.ToArray();
            var json = JsonConvert.SerializeObject(people, Formatting.Indented);
            File.WriteAllText("people.txt", json);

            var message = Messages.ToArray();
            var jsonmessage = JsonConvert.SerializeObject(message, Formatting.Indented);
            File.WriteAllText("messages.txt", jsonmessage);



            InitializeComponent();


            DataContext = this;
        }


        ////////////////////////
        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string? name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        ////////////////////////////


        private void PeopleList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            textblock_name.Text = PeopleList.SelectedItem.ToString();
            textblock_online.Text = "online";
        }

        private void btn_sendMessage_Click(object sender, RoutedEventArgs e)
        {
            var message = textbox_writeAMessage.Text;
            Messages.Add(new Message() { Text = "you: " + message, DateTime = DateTime.Now });
            textbox_writeAMessage.Text = null;
        }

        private void btn_search_Click(object sender, RoutedEventArgs e)
        {
            var message = textbox_writeAMessage.Text;
            var result = Messages.FirstOrDefault(x => x.Text == message);

            if (result != null)
            {
                MessageBox.Show("Message found!");
            }
            else
                MessageBox.Show("Message don't exist!");
        }

        private void btn_contactsearch_Click(object sender, RoutedEventArgs e)
        {
            var result = People.FirstOrDefault(x => x.Name == textbox_search.Text);

            if (result != null)
            {
                MessageBox.Show("Contact is exist!");
            }
            else
                MessageBox.Show("Contact don't exist!");
        }
    }
}
