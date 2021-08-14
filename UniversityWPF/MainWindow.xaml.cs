using Service;
using Service.Interfaces;
using System.Windows;
using Telerik.Windows.Controls;
using UniversityWPF.ViewModels;

namespace UniversityWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IStudentService _studentService;
        private readonly ITeacherService _teacherService;
        private readonly IPowerPoleService _powerPoleService;

        public MainWindow(IStudentService studentService,
                          ITeacherService teacherService,
                          IPowerPoleService powerPoleService)
        {
            _studentService = studentService;
            _teacherService = teacherService;
            _powerPoleService = powerPoleService;

            StyleManager.ApplicationTheme = new MaterialTheme();
            InitializeComponent();

            DataContext = new InputsViewModel(_studentService, _teacherService, _powerPoleService);
        }

        private void RadTreeView_ItemClick(object sender, Telerik.Windows.RadRoutedEventArgs e)
        {
            string header = (e.OriginalSource as RadTreeViewItem).Header as string;

            switch (header)
            {
                case "Inputs":
                    DataContext = new InputsViewModel(_studentService, _teacherService, _powerPoleService);
                    break;
                case "Chart":
                    DataContext = new ChartViewModel(_studentService);
                    break;
                case "Spreadsheet":
                    DataContext = new SpreadsheetViewModel();
                    break;
                case "Grid":
                    DataContext = new GridViewModel(_studentService);
                    break;
                case "Scheduler":
                    DataContext = null;
                    break;
                case "Report":
                    DataContext = new ReportViewModel();
                    break;
                default:
                    break;
            }
        }
    }
}
