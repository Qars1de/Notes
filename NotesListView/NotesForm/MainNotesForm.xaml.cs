using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
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

namespace NotesListView.NotesForm
{
    /// <summary>
    /// Логика взаимодействия для MainNotesForm.xaml
    /// </summary>
    public partial class MainNotesForm : Window
    {
        public MainNotesForm()
        {
            InitializeComponent();
            Update();
        }

        private void Update()
        {
            var note = App.Context.Notes.ToList();
            LViewNotes.ItemsSource = note;
        }

        private void insertButton_Click(object sender, RoutedEventArgs e)
        {
            InsertForm.InsertFormNotes insert = new InsertForm.InsertFormNotes();
            if (insert.ShowDialog() == true)
            {
                
                DB db = new DB();

                SqlCommand command = new SqlCommand("insert into Notes (Name, Content) values (@name, @cont)", db.getConnection());
                command.Parameters.Add("@name", SqlDbType.VarChar).Value = insert.NameBox.Text;
                command.Parameters.Add("@cont", SqlDbType.VarChar).Value = insert.contentBox.Text;

                db.openConnection();
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                command.ExecuteNonQuery();
                Update();
                db.closeConnection();

            }
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            var notesDelete = LViewNotes.SelectedItems.Cast<Notes>().ToList();
            if (MessageBox.Show($"Вы точно хотите удалить следующие {notesDelete.Count()} элементов?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    App.Context.Notes.RemoveRange(notesDelete);
                    App.Context.SaveChanges();
                    Update();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void ListViewItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
