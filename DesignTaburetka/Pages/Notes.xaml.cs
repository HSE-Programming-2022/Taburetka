using DesignTaburetka;
using DesignTaburetka.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Input;

namespace TaburetkaProject
{
    /// <summary>
    /// Логика взаимодействия для Notes.xaml
    /// </summary>
    public partial class Notes : Page
    {
        private string folderImages = "../../NotesData/Images/";

        private string folderFiles = "../../NotesData/Files/";
        
        private string fullFilePath;

        private string fullImagePath;

        List<ToDoItem> tdl = new List<ToDoItem>();
        public Notes()
        {
            StorageNotes.ReadItems();
            InitializeComponent();
            tdl = StorageNotes.items;
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
            txtNote.Focus();
        }

        private void txtNote_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtNote.Text) && txtNote.Text.Length > 0)
            {
                lblNote.Visibility = Visibility.Collapsed;
            }
            else
            {
                lblNote.Visibility = Visibility.Visible;
            }
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtNote.Text))
            {
                ToDoItem item = new ToDoItem(txtNote.Text, imagePath.Text, fileName.Text);

                tdl.Insert(0, item);

                StorageNotes.SaveItem(tdl);
                if (!string.IsNullOrEmpty(imagePath.Text)) File.Copy(fullImagePath, Path.Combine(folderImages, imagePath.Text));
                if (!string.IsNullOrEmpty(fileName.Text)) File.Copy(fullFilePath, Path.Combine(folderFiles, fileName.Text));
            
            }

            txtNote.Text = "";
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
                    fullImagePath = openDialog.FileName;        
                    System.Windows.MessageBox.Show($"Изображение загружено", "Successfully Upoladed", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
        }

        private void FileUpload_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
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
                    fullFilePath = openFileDialog.FileName;
                    System.Windows.MessageBox.Show($"Файл {fileName.Text} загружен", "Successfully Upoladed", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
        }

        private void chkShowNotDone_Unchecked(object sender, RoutedEventArgs e)
        {
            lvToDo.ItemsSource = tdl;
        }

        private void DeleteItem_Click(object sender, RoutedEventArgs e)
        {
            if (lvToDo.SelectedItem != null)
            {
                MessageBoxResult del = System.Windows.MessageBox.Show("Удалить это задание?", "Delete?", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No);
                if (del == MessageBoxResult.Yes)
                {
                    tdl.Remove(lvToDo.SelectedItem as ToDoItem);
                    StorageNotes.DeleteItem(lvToDo.SelectedItem as ToDoItem);
                }
                lvToDo.Items.Refresh();

            }
        }

        private void EditItem_Click(object sender, RoutedEventArgs e)
        {
            if (lvToDo.SelectedItem != null)
            {
                string description = (lvToDo.SelectedItem as ToDoItem).Description;
                string filmsource = (lvToDo.SelectedItem as ToDoItem).FileSource;
                string imagesource = (lvToDo.SelectedItem as ToDoItem).ImageSource;
                EditNote ep = new EditNote(lvToDo.SelectedItem as ToDoItem, description, filmsource, imagesource);

                ep.ShowDialog();


                lvToDo.ItemsSource = tdl;
                lvToDo.Items.Refresh();
                StorageNotes.SaveItem(tdl);
            }
        }

        private void OpenImage_Click(object sender, RoutedEventArgs e)
        {
            string path = @"NotesData\Images\" + (lvToDo.SelectedItem as ToDoItem).ImageSource;
            string imagePath = Path.GetFullPath(path);
            imagePath = imagePath.Replace(@"\bin\Debug", "");
            Process.Start(imagePath);

        }

        private void OpenFile_Click(object sender, RoutedEventArgs e)
        {
            string path = @"NotesData\Files\" + (lvToDo.SelectedItem as ToDoItem).FileSource;
            string filePath = Path.GetFullPath(path);
            filePath = filePath.Replace(@"\bin\Debug", "");
            Process.Start(filePath);
        }

    }

}
