using System;
using System.IO;
using System.Windows;
using System.Windows.Forms;
using TaburetkaProject.Models;

namespace TaburetkaProject
{
    /// <summary>
    /// Логика взаимодействия для EditItem.xaml
    /// </summary>
    public partial class EditItem : Window
    {
        public ToDoItem editItem = new ToDoItem();

        string fullImagePath;
        string fullFilePath;
        string oldFileFource;
        string oldImageSource;
        string folderFiles = "../../ToDoData/Files/";
        string folderImages = "../../ToDoData/Images/";
        public EditItem(ToDoItem item, string oldfilesource, string oldimagesource)
        {
            InitializeComponent();
            editItem = item;
            oldFileFource = oldfilesource;
            oldImageSource = oldimagesource;
            DataContext = item;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (Description.Text != "" && Deadline.Text != "")
            {

                if ((!string.IsNullOrEmpty(ImageSource.Text)) && (oldImageSource != ImageSource.Text))
                {
                    editItem.ImageSource = ImageSource.Text;
                    File.Copy(fullImagePath, System.IO.Path.Combine(folderImages, ImageSource.Text));
                }


                if (!(string.IsNullOrEmpty(FileSource.Text)) && (oldFileFource != FileSource.Text))
                {
                    editItem.FileSource = FileSource.Text;
                    File.Copy(fullFilePath, System.IO.Path.Combine(folderFiles, FileSource.Text));
                }


                if ((!string.IsNullOrEmpty(oldFileFource)) && (oldFileFource != FileSource.Text))
                {
                    File.Delete(folderFiles + oldFileFource);
                }

                if ((!string.IsNullOrEmpty(oldImageSource)) && (oldImageSource != ImageSource.Text))
                    File.Delete(folderImages + oldImageSource);

                System.Windows.MessageBox.Show("Saved successfully", "Edit Page", MessageBoxButton.OK);
            }
            Close();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }


        private void FileUpload_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = true;
            openFileDialog.Filter = "Text files (*.txt)|*.txt|Pdf files (*.pdf)|*.pdf";
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (File.Exists(Path.Combine(folderFiles, Path.GetFileName(openFileDialog.FileName))))
                {
                    System.Windows.MessageBox.Show($"File with name {Path.GetFileName(openFileDialog.FileName)} exists. Rename it and try again to upload", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    fullFilePath = openFileDialog.FileName;
                    FileSource.Text = Path.GetFileName(openFileDialog.FileName);
                    System.Windows.MessageBox.Show($"File {FileSource.Text} uploaded", "Successfully Upoladed", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
        }

        private void ImageUpload_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.Filter = "Image files|*.bmp;*jpg;*.png";
            openDialog.FilterIndex = 1;
            if (openDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (File.Exists(Path.Combine(folderImages, Path.GetFileName(openDialog.FileName))))
                {
                    System.Windows.MessageBox.Show($"Image with name {System.IO.Path.GetFileName(openDialog.FileName)} exists. Rename it and try again to upload", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    fullImagePath = openDialog.FileName;
                    ImageSource.Text = Path.GetFileName(openDialog.FileName);
                    MessageBoxResult done = System.Windows.MessageBox.Show($"Image uploaded", "Successfully Upoladed", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
        }
    }
}
