using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Input;
using DesignTaburetka;
using DesignTaburetka.Models;
using System.Windows.Media.Imaging;
using System.Text;

namespace TaburetkaProject
{
    /// <summary>
    /// Логика взаимодействия для ToDo.xaml
    /// </summary>
    public partial class ToDo : Page
    {
        private string folderImages = "../../ToDoData/Images/";

        private string folderFiles = "../../ToDoData/Files/";

        List<ToDoItem> tdl = new List<ToDoItem>();
        public ToDo()
        {
            Storage.ReadItems();
            InitializeComponent();
            tdl = Storage.items;
            DataContext = tdl;
            lvToDo.ItemsSource = tdl;
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        private void DragMove()
        {
            throw new NotImplementedException();
        }

        private void lblNote_MouseDown(object sender, MouseButtonEventArgs e)
        {
            textNote.Focus();
        }

        private void txtNote_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(textNote.Text) && textNote.Text.Length > 0)
            {
                leblNote.Visibility = Visibility.Collapsed;
            }
            else
            {
                leblNote.Visibility = Visibility.Visible;
            }
        }

        private void lvToDo_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            MarkAsDone_Click(sender, e);
        }


        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(textNote.Text) && (!string.IsNullOrEmpty(datePicker1.SelectedDate.ToString())))
            {
                ToDoItem item = new ToDoItem(textNote.Text, datePicker1.SelectedDate.Value.ToShortDateString(), imagePath.Text, fileName.Text, "Не выполнено");

                tdl.Insert(0, item);

                Storage.SaveItem(tdl);
            }

            textNote.Text = "";
            datePicker1.Text = "";
            imagePath.Text = "";
            fileName.Text = "";
            lvToDo.ItemsSource = tdl;
            lvToDo.Items.Refresh();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.Filter = "Image files|*.bmp;*jpg;*.png";
            openDialog.FilterIndex = 1;
            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                if (File.Exists(Path.Combine(folderImages, Path.GetFileName(openDialog.FileName))))
                {
                    System.Windows.MessageBox.Show($"Изображение с названием {Path.GetFileName(openDialog.FileName)} существует. Переименуйте его и загрузите снова.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {

                    imagePath.Text = Path.GetFileName(openDialog.FileName);
                    File.Copy(openDialog.FileName, Path.Combine(folderImages, imagePath.Text));
                    System.Windows.MessageBox.Show($"Изображение загружено", "Successfully Upoladed", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
        }

        private void FileUpload_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = true;
            openFileDialog.Filter = "Text files (*.txt)|*.txt|Pdf files (*.pdf)|*.pdf|Docx files (*.docx)|*.docx|Pptx files (*.pptx)|*.pptx|Xlsx files (*.xlsx)|*.xlsx";
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (File.Exists(Path.Combine(folderFiles, Path.GetFileName(openFileDialog.FileName))))
                {
                    System.Windows.MessageBox.Show($"Файл с названием {Path.GetFileName(openFileDialog.FileName)} существует. Переименуйте его и загрузите снова.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    fileName.Text = Path.GetFileName(openFileDialog.FileName);
                    File.Copy(openFileDialog.FileName, Path.Combine(folderFiles, fileName.Text));
                    System.Windows.MessageBox.Show($"Файл {fileName.Text} загружен", "Successfully Upoladed", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
        }

        private void chkShowNotDone_Checked(object sender, RoutedEventArgs e)
        {
            lvToDo.ItemsSource = tdl.Where(item => item.IsDone == "Не выполнено");
        }

        private void chkShowNotDone_Unchecked(object sender, RoutedEventArgs e)
        {
            lvToDo.ItemsSource = tdl;
        }

        private void MarkAsDone_Click(object sender, RoutedEventArgs e)
        {
            if (lvToDo.SelectedItem != null)
            {
                MessageBoxResult done = System.Windows.MessageBox.Show("Отметить как выполненное?", "Выполнено?", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No);
                if (done == MessageBoxResult.Yes)
                {
                    (lvToDo.SelectedItem as ToDoItem).IsDone = "Выполнено";
                    lvToDo.ItemsSource = tdl;
                    lvToDo.Items.Refresh();
                    Storage.SaveItem(tdl);

                }
            }
        }

        private void DeleteItem_Click(object sender, RoutedEventArgs e)
        {
            if (lvToDo.SelectedItem != null)
            {
                MessageBoxResult del = System.Windows.MessageBox.Show("Удалить это задание?", "Delete?", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No);
                if (del == MessageBoxResult.Yes)
                {
                    if (!string.IsNullOrEmpty((lvToDo.SelectedItem as ToDoItem).ImageSource))
                        File.Delete(folderImages + (lvToDo.SelectedItem as ToDoItem).ImageSource);

                    if (!string.IsNullOrEmpty((lvToDo.SelectedItem as ToDoItem).FileSource))
                        File.Delete(folderFiles + (lvToDo.SelectedItem as ToDoItem).FileSource);

                    tdl.Remove(lvToDo.SelectedItem as ToDoItem);
                    Storage.DeleteItem(lvToDo.SelectedItem as ToDoItem);

                }
                lvToDo.Items.Refresh();

            }
        }

        private void EditItem_Click(object sender, RoutedEventArgs e)
        {
            if (lvToDo.SelectedItem != null)
            {
                string description = (lvToDo.SelectedItem as ToDoItem).Description;
                string deadline = (lvToDo.SelectedItem as ToDoItem).Deadline;
                string filmsource = (lvToDo.SelectedItem as ToDoItem).FileSource;
                string imagesource = (lvToDo.SelectedItem as ToDoItem).ImageSource;
                EditItem ep = new EditItem(lvToDo.SelectedItem as ToDoItem, description, deadline, filmsource, imagesource);

                ep.ShowDialog();


                lvToDo.ItemsSource = tdl;
                lvToDo.Items.Refresh();
                Storage.SaveItem(tdl);
            }
        }

        private void OpenImage_Click(object sender, RoutedEventArgs e)
        {
            string path = @"ToDoData\Images\" + (lvToDo.SelectedItem as ToDoItem).ImageSource;
            string imagePath = Path.GetFullPath(path);
            imagePath = imagePath.Replace(@"\bin\Debug", "");
            Process.Start(imagePath);

        }

        private void OpenFile_Click(object sender, RoutedEventArgs e)
        {
            string path = @"ToDoData\Files\" + (lvToDo.SelectedItem as ToDoItem).FileSource;
            string filePath = Path.GetFullPath(path);
            filePath = filePath.Replace(@"\bin\Debug", "");
            Process.Start(filePath);
        }
    }
}
