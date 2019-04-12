using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Data;

namespace WPFUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public static readonly Player Player = new Player();
        
        public MainWindow()
        {
            InitializeComponent();
            Loaded += OnLoaded;
        }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            
        }
    }

    public class Player
    {
        private readonly Random _rand = new Random();
        
        private readonly Prop<int> _hp = new Prop<int>();
        public int HP
        {
            get => _hp.Value;
            set => _hp.Value = value;
        }

        private readonly Prop<int> _mp = new Prop<int>();
        public int MP
        {
            get => _mp.Value;
            set => _mp.Value = value;
        }
        private readonly Prop<int> _san = new Prop<int>();
        public int SAN
        {
            get => _san.Value;
            set => _san.Value = value;
        }

        public List<Item> _inventory = new List<Item>
        {
            new Item {ID = "apple", Count = 4, Name = "Apple"},
            new Item {ID = "orange", Count = 2, Name = "Orange"},
            new Item {ID = "taco", Count = int.MaxValue, Name = "Taco"},
        };

        private readonly ObservableCollection<Item> _inv;
        public ObservableCollection<Item> Inventory => _inv;
        

        public Player()
        {
            HP = _rand.Next(15) + 5;
            MP = _rand.Next(15) + 5;
            SAN = 100;
            _inv = new ObservableCollection<Item>(_inventory);
        }
    }

    public class Item
    {
        private readonly Prop<string> _name = new Prop<string>();
        public string Name
        {
            get => _name.Value;
            set => _name.Value = value;
        }

        private readonly Prop<string> _id = new Prop<string>();
        public string ID
        {
            get => _id.Value;
            set => _id.Value = value;
        }
        
        private readonly Prop<int> _count = new Prop<int>();
        public int Count
        {
            get => _count.Value;
            set => _count.Value = value;
        }
    }
    
    public class Prop<T> : INotifyPropertyChanged
    {
        private T _value;

        public T Value
        {
            get => _value; 
            set { _value = value; NotifyPropertyChanged(nameof(_value)); }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(String propertyName) => 
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}