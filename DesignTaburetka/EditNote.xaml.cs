using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using DesignTaburetka.Models;

namespace DesignTaburetka
{
    /// <summary>
    /// Логика взаимодействия для EditNote.xaml
    /// </summary>
    public partial class EditNote : Window
    {
        public ToDoItem editItem = new ToDoItem();

        private string fullImagePath;
        private string fullFilePath;

        private string oldDescription;
        private string oldFileFource;
        private string oldImageSource;
        private string folderFiles = "../../NotesData/Files/";
        private string folderImages = "../../NotesData/Images/";

        public string FullImagePath { get => fullImagePath; set => fullImagePath = value; }
        public string FullFilePath { get => fullFilePath; set => fullFilePath = value; }
        public string OldDescription { get => oldDescription; set => oldDescription = value; }
        public string OldFileFource { get => oldFileFource; set => oldFileFource = value; }
        public string OldImageSource { get => oldImageSource; set => oldImageSource = value; }
        public string FolderFiles { get => folderFiles; set => folderFiles = value; }
        public string FolderImages { get => folderImages; set => folderImages = value; }


        public EditNote(ToDoItem item, string olddescription, string oldfilesource, string oldimagesource)
        {
            InitializeComponent();
            OldDescription = olddescription;
            editItem = item;
            OldFileFource = oldfilesource;
            OldImageSource = oldimagesource;
            DataContext = item;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(Description.Text))
            {

                if ((!string.IsNullOrEmpty(ImageSource.Text)) && (OldImageSource != ImageSource.Text))
                {
                    editItem.ImageSource = ImageSource.Text;
                    File.Copy(FullImagePath, Path.Combine(FolderImages, ImageSource.Text));
                }


                if (!(string.IsNullOrEmpty(FileSource.Text)) && (OldFileFource != FileSource.Text))
                {
                    editItem.FileSource = FileSource.Text;
                    File.Copy(FullFilePath, Path.Combine(FolderFiles, FileSource.Text));
                }


                if ((!string.IsNullOrEmpty(OldFileFource)) && (OldFileFource != FileSource.Text))
                {
                    File.Delete(FolderFiles + OldFileFource);
                }

                if ((!string.IsNullOrEmpty(OldImageSource)) && (OldImageSource != ImageSource.Text))
                    File.Delete(FolderImages + OldImageSource);

                System.Windows.MessageBox.Show("Изменения сохранены", "Edit Page", MessageBoxButton.OK);
            }
            else
            {
                editItem.Description = OldDescription;
                editItem.FileSource = OldFileFource;
                editItem.ImageSource = OldImageSource;
                System.Windows.MessageBox.Show("Нет данных для поля «описание», поэтому изменения не могут быть сохранены.", "Edit Page", MessageBoxButton.OK, MessageBoxImage.Error);
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
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (File.Exists(Path.Combine(FolderFiles, Path.GetFileName(openFileDialog.FileName))))
                {
                    System.Windows.MessageBox.Show($"Файл с названием {Path.GetFileName(openFileDialog.FileName)} существует. Переименуйте его и загрузите снова.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    FullFilePath = openFileDialog.FileName;
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
                if (File.Exists(Path.Combine(FolderImages, Path.GetFileName(openDialog.FileName))))
                {
                    System.Windows.MessageBox.Show($"Изображение с названием {Path.GetFileName(openDialog.FileName)} существует. Переименуйте его и загрузите снова.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    FullImagePath = openDialog.FileName;
                    ImageSource.Text = Path.GetFileName(openDialog.FileName);
                    System.Windows.MessageBox.Show($"Изображение загружено", "Successfully Upoladed", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
        }
    }
}
