﻿using Xamarin.Forms;

namespace ToDoList
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new ToDoListViewModel();
        }
    }
}