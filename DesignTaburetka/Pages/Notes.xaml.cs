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

        private void txtNote_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
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
                ToDoItem item = new ToDoItem(txtNote.Text, imagePath.Text, fileName.Text, "Not done");

                tdl.Insert(0, item);

                StorageNotes.SaveItem(tdl);
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
                if (File.Exists(System.IO.Path.Combine(folderImages, System.IO.Path.GetFileName(openDialog.FileName))))
                {
                    System.Windows.MessageBox.Show($"Image with name {System.IO.Path.GetFileName(openDialog.FileName)} exists. Rename it and try again to upload", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {

                    imagePath.Text = System.IO.Path.GetFileName(openDialog.FileName);
                    File.Copy(openDialog.FileName, System.IO.Path.Combine(folderImages, imagePath.Text));
                    MessageBoxResult done = System.Windows.MessageBox.Show($"Image uploaded", "Successfully Upoladed", MessageBoxButton.OK, MessageBoxImage.Information);
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
                if (File.Exists(System.IO.Path.Combine(folderFiles, System.IO.Path.GetFileName(openFileDialog.FileName))))
                {
                    System.Windows.MessageBox.Show($"File with name {System.IO.Path.GetFileName(openFileDialog.FileName)} exists. Rename it and try again to upload", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    fileName.Text = System.IO.Path.GetFileName(openFileDialog.FileName);
                    File.Copy(openFileDialog.FileName, System.IO.Path.Combine(folderFiles, fileName.Text));
                    System.Windows.MessageBox.Show($"File {fileName.Text} uploaded", "Successfully Upoladed", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
        }

        private void chkShowNotDone_Checked(object sender, RoutedEventArgs e)
        {
            lvToDo.ItemsSource = tdl.Where(item => item.IsDone == "Not done");
        }

        private void chkShowNotDone_Unchecked(object sender, RoutedEventArgs e)
        {
            lvToDo.ItemsSource = tdl;
        }


        private void DeleteItem_Click(object sender, RoutedEventArgs e)
        {
            if (lvToDo.SelectedItem != null)
            {
                MessageBoxResult del = System.Windows.MessageBox.Show("Delete this item?", "Delete?", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No);
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
                string filmsource = (lvToDo.SelectedItem as ToDoItem).FileSource;
                string imagesource = (lvToDo.SelectedItem as ToDoItem).ImageSource;
                EditNote ep = new DesignTaburetka.EditNote(lvToDo.SelectedItem as ToDoItem, filmsource, imagesource);

                ep.ShowDialog();


                lvToDo.ItemsSource = tdl;
                lvToDo.Items.Refresh();
                StorageNotes.SaveItem(tdl);
            }
        }

        private void OpenImage_Click(object sender, RoutedEventArgs e)
        {
            string path = @"NotesData\Images\" + (lvToDo.SelectedItem as ToDoItem).FileSource;
            string imagePath = Path.GetFullPath(path);
            imagePath = imagePath.Replace(@"\bin\Debug", "");
            System.Windows.MessageBox.Show(imagePath);
            Process.Start(imagePath);

        }

        private void OpenFile_Click(object sender, RoutedEventArgs e)
        {
            string path = @"NotesData\Files\" + (lvToDo.SelectedItem as ToDoItem).FileSource;
            string filePath = Path.GetFullPath(path);
            filePath = filePath.Replace(@"\bin\Debug", "");
            System.Windows.MessageBox.Show(filePath);
            Process.Start(filePath);
        }

    }

    
}
