using System;
using System.IO;
using System.Windows;
using Microsoft.Win32;
// Remove or comment out this line: using WinForms = System.Windows.Forms;
using Microsoft.WindowsAPICodePack.Dialogs; // Add this using statement

namespace FileMoverWpf
{
    public partial class MainWindow : Window
    {
        public MainWindow() => InitializeComponent();

        private void BrowseSource_Click(object sender, RoutedEventArgs e)
        {
            // Replace WinForms.FolderBrowserDialog with CommonOpenFileDialog
            using (var dialog = new CommonOpenFileDialog())
            {
                dialog.IsFolderPicker = true; // This makes it a folder picker
                if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
                {
                    SourceFolderBox.Text = dialog.FileName; // Use FileName for selected path
                }
            }
        }

        private void BrowseDestination_Click(object sender, RoutedEventArgs e)
        {
            // Replace WinForms.FolderBrowserDialog with CommonOpenFileDialog
            using (var dialog = new CommonOpenFileDialog())
            {
                dialog.IsFolderPicker = true; // This makes it a folder picker
                if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
                {
                    DestinationFolderBox.Text = dialog.FileName; // Use FileName for selected path
                }
            }
        }

        private void MoveFiles_Click(object sender, RoutedEventArgs e)
        {
            string source = SourceFolderBox.Text.Trim();
            string destination = DestinationFolderBox.Text.Trim();

            if (!Directory.Exists(source) || string.IsNullOrWhiteSpace(destination))
            {
                Log("Invalid folder paths.");
                return;
            }

            Directory.CreateDirectory(destination);

            foreach (var root in Directory.GetDirectories(source, "*", SearchOption.AllDirectories))
            {
                foreach (var file in Directory.GetFiles(root))
                {
                    string fileName = Path.GetFileName(file);

                    // Skip if file is already in destination
                    if (Path.GetFullPath(Path.GetDirectoryName(file)) == Path.GetFullPath(destination))
                        continue;

                    string destFile = Path.Combine(destination, fileName);

                    // Handle duplicates
                    if (File.Exists(destFile))
                    {
                        string baseName = Path.GetFileNameWithoutExtension(fileName);
                        string ext = Path.GetExtension(fileName);
                        int counter = 1;

                        while (File.Exists(destFile))
                        {
                            destFile = Path.Combine(destination, $"{baseName}_{counter}{ext}");
                            counter++;
                        }
                    }

                    File.Move(file, destFile);
                    Log($"Moved: {file} → {destFile}");
                }

                // Remove empty folders
                if (root != source && Directory.GetFiles(root).Length == 0 && Directory.GetDirectories(root).Length == 0)
                {
                    Directory.Delete(root);
                    Log($"Deleted empty folder: {root}");
                }
            }

            Log("✅ File move complete.");
        }

        private void Log(string message)
        {
            LogBox.AppendText(message + Environment.NewLine);
            LogBox.ScrollToEnd();
        }
    }
}