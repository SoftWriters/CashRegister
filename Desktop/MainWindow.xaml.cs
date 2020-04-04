using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Desktop.ViewModels;
using static CashRegister.Main;

namespace Desktop
{
    public class MainWindow : Window
    {
        CashRegisterViewModel ViewModel = new CashRegisterViewModel();
        public MainWindow()
        {
            InitializeComponent();
            DataContext = ViewModel;
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
            this.FindControl<Button>("OpenFile").Click += async delegate
            {
                OpenFileDialog dialog = new OpenFileDialog();
                
                string[] result = await dialog.ShowAsync(this);
                string fileContents = File.ReadAllText(result.First());
                string[] items = fileContents.Split("\n");

                List<string> changeOutput = items.Select(item =>
                {
                    string[] input = item.Split(",");
                    decimal cost = decimal.Parse(input[0]);
                    decimal given = decimal.Parse(input[1]);

                    return GetChange(cost, given);
                }).ToList();

                ViewModel.Input = string.Join("\n", items);;
                ViewModel.Output = string.Join("\n", changeOutput);
                
            };
        }
    }
}