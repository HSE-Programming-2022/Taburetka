using System;
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
using DesignTaburetka.Models;
using System.IO;
using System.Windows.Forms;

namespace DesignTaburetka
{
    /// <summary>
    /// Логика взаимодействия для EditItem.xaml
    /// </summary>
    public partial class EditItem : Window
    {
        public ToDoItem editItem = new ToDoItem();

        string fullImagePath;
        string oldDescription;
        string oldDeadline;
        string fullFilePath;
        string oldFileFource;
        string oldImageSource;
        string folderFiles = "../../ToDoData/Files/";
        string folderImages = "../../ToDoData/Images/";
        public EditItem(ToDoItem item, string olddescription, string olddeadline, string oldfilesource, string oldimagesource)
        {
            InitializeComponent();
            editItem = item;
            oldDescription = olddescription;
            oldDeadline = olddeadline;
            oldFileFource = oldfilesource;
            oldImageSource = oldimagesource;
            DataContext = item;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if ((!string.IsNullOrEmpty(Description.Text)) && (!string.IsNullOrEmpty(Deadline.Text)))
            {

                if ((!string.IsNullOrEmpty(ImageSource.Text)) && (oldImageSource != ImageSource.Text))
                {
                    editItem.ImageSource = ImageSource.Text;
                    File.Copy(fullImagePath, Path.Combine(folderImages, ImageSource.Text));
                }


                if (!(string.IsNullOrEmpty(FileSource.Text)) && (oldFileFource != FileSource.Text))
                {

                    editItem.FileSource = FileSource.Text;
                    File.Copy(fullFilePath, Path.Combine(folderFiles, FileSource.Text));
                }


                if ((!string.IsNullOrEmpty(oldImageSource)) && (oldImageSource != ImageSource.Text))
                {
                    File.Delete(folderImages + oldImageSource);
                }

                if ((!string.IsNullOrEmpty(oldFileFource)) && (oldFileFource != FileSource.Text))
                    File.Delete(folderFiles + oldFileFource);

                System.Windows.MessageBox.Show("Изменения сохранены", "Edit Page", MessageBoxButton.OK);
            }
            else
            {
                editItem.Description = oldDescription;
                editItem.Deadline = oldDeadline;
                editItem.FileSource = oldFileFource;
                editItem.ImageSource = oldImageSource;
                System.Windows.MessageBox.Show("Нет данных для поля «описание» или «срок», поэтому изменения не могут быть сохранены.", "Edit Page", MessageBoxButton.OK, MessageBoxImage.Error);

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
            openFileDialog.Filter = "Text files (*.txt)|*.txt|Pdf files (*.pdf)|*.pdf|Docx files (*.docx)|*.docx|Pptx files (*.pptx)|*.pptx|Xlsx files (*.xlsx)|*.xlsx";
            openFileDialog.Multiselect = true;
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (File.Exists(Path.Combine(folderFiles, Path.GetFileName(openFileDialog.FileName))))
                {
                    System.Windows.MessageBox.Show($"Файл с названием {Path.GetFileName(openFileDialog.FileName)} существует. Переименуйте его и загрузите снова.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    fullFilePath = openFileDialog.FileName;
                    FileSource.Text = Path.GetFileName(openFileDialog.FileName);
                    System.Windows.MessageBox.Show($"Файл {FileSource.Text} загружен", "Successfully Upoladed", MessageBoxButton.OK, MessageBoxImage.Information);
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
                    System.Windows.MessageBox.Show($"Изображение с названием {Path.GetFileName(openDialog.FileName)} существует. Переименуйте его и загрузите снова.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    fullImagePath = openDialog.FileName;
                    ImageSource.Text = Path.GetFileName(openDialog.FileName);
                    System.Windows.MessageBox.Show($"Изображение загружено", "Successfully Upoladed", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
        }
    }
}
