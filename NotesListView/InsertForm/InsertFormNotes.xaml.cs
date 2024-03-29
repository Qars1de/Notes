﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace NotesListView.InsertForm
{
    /// <summary>
    /// Логика взаимодействия для InsertFormNotes.xaml
    /// </summary>
    /// 
    public partial class InsertFormNotes : Window
    {

        private Notes _currentNotes;

        public InsertFormNotes(Notes selectedNotes)
        {
            InitializeComponent();
            if (selectedNotes != null)
            {
                _currentNotes = selectedNotes;
            }
            DataContext = _currentNotes;
        }

        private void okButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult= false;
        }
    }
}
