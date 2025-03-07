﻿using MoneyCeeper.Model;
using System;
using System.Windows;

namespace MoneyCeeper.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddWindow.xaml
    /// </summary>
    public partial class AddWindow : Window, IMainWindowsCodeBehind
    {
        public AddWindow()
        {
            InitializeComponent();
        }

        public void ShowMessage(string message)
        {
            throw new NotImplementedException();
        }

        public void LoadView(ViewType typeView)
        {
            throw new NotImplementedException();
        }

        private void TextBox_Error(object sender, System.Windows.Controls.ValidationErrorEventArgs e)
        {
            MessageBox.Show(e.Error.ErrorContent.ToString());
        }
    }
}
