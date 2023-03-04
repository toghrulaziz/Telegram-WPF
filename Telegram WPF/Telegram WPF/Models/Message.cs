using System;
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
    public class Message : INotifyPropertyChanged
    {
        
        private string? text;
        
        private DateTime dateTime;
        

        [JsonProperty]
        public string? Text { get => text; set { text = value; OnPropertyChanged(); } }
        [JsonProperty]
        public DateTime DateTime { get => dateTime; set { dateTime = value; OnPropertyChanged(); } }
       

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string? name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public Message()
        {

        }

        public Message(string? text,DateTime dateTime)
        {
            Text = text;
            DateTime = dateTime;
        }
    }
}
