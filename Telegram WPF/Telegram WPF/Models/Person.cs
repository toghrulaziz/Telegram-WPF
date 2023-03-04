using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Newtonsoft.Json;

namespace Telegram_WPF.Models
{
    [JsonObject(MemberSerialization.OptIn)]
    public class Person : INotifyPropertyChanged
    {

        private string? name;

        private string? surname;

        private string? avatar;

        private string? lastMessage;
        private List<Message>? messages { get; set; }


        [JsonProperty]
        public string? Name { get => name; set { name = value; OnPropertyChanged(); } }
        [JsonProperty]
        public string? Surname { get => surname; set { surname = value; OnPropertyChanged(); } }
        [JsonProperty]
        public string? Avatar { get => avatar; set { avatar = value; OnPropertyChanged(); } }
        [JsonProperty]
        public string? LastMessage { get => lastMessage; set { lastMessage = value; OnPropertyChanged(); } }

        [JsonProperty]
        public List<Message>? Messages { get => messages; set { messages = value; OnPropertyChanged(); } }
       



        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string? name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public Person()
        {

        }

        public Person(string? name, string? surname,string? avatar, string? lastMessage){ 
            Name = name;
            Surname = surname;
            Avatar = avatar;
            LastMessage = lastMessage;
        }

        public override string ToString()
        {
            return $"{Name} {Surname}";
        }
    }
}
