
# FileMoverWpf

A simple **WPF (Windows Presentation Foundation)** desktop application built with **C#** and **.NET** to move files from multiple subfolders into a single destination folder, with automatic cleanup of empty folders. The app provides a graphical interface to select source and destination folders and displays progress logs.

---

## Features

- Select source folder containing multiple subfolders/files.
- Select destination folder where all files will be moved.
- Automatically handles file name conflicts by renaming duplicates.
- Deletes empty folders after files are moved.
- Simple and clean WPF GUI with folder browsing dialogs.
- Logs progress of file moves and folder deletions.

---

## Screenshots

*(Add screenshots of your application UI here if available)*

---

## Getting Started

### Prerequisites

- [.NET 6.0 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/6.0) or later
- Windows OS (WPF apps run on Windows)

### Build and Run

Clone the repository:

```bash
git clone https://github.com/yourusername/FileMoverWpf.git
cd FileMoverWpf
````

Restore dependencies and run:

```bash
dotnet restore
dotnet run
```

---

## Usage

1. Click **Browse** next to **Source Folder** and select the folder containing your files and subfolders.
2. Click **Browse** next to **Destination Folder** to select or create a folder where all files will be consolidated.
3. Click **Move Files** to start the process.
4. Watch the progress log for moved files and deleted folders.
5. Once done, all files will be in the destination folder, and empty source subfolders will be removed.

---

## How It Works

The application scans all subdirectories inside the source folder, moves files to the destination folder while avoiding name conflicts by appending a counter, and deletes any subfolders left empty after moving files.

---

## Project Structure

* `MainWindow.xaml` — Defines the WPF user interface.
* `MainWindow.xaml.cs` — Contains the event handlers and business logic for moving files.
* `FileMoverWpf.csproj` — Project file with dependencies.

---

## Future Improvements

* Add progress bar to indicate file move progress.
* Add option to copy instead of move files.
* Filter files by extension or size.
* Add multi-threading to improve performance for large file sets.

---

## License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.

---

## Contact

Created by [Abhinand Krishna]([https://github.com/yourusername](https://github.com/abhinandkrishna20)). Feel free to open issues or submit pull requests!


