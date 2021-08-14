﻿using Service;
using Service.Interfaces;
using System;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using Unity;
using UniversityWPF.Commands;

namespace UniversityWPF.ViewModels
{
    public class InputsViewModel : INotifyPropertyChanged
    {
        private IStudentService _studentService;
        private ITeacherService _teacherService;
        private IPowerPoleService _powerPoleService;

        private string _studentName;
        private string _studentEmail;
        private string _studentSpecialty;
        private string _studentCourse;

        private string _teacherName;
        private string _teacherEmail;
        private string _teacherRank;

        private string _powerPoleAddress;
        private string _powerPolePowerWire;
        private string _powerPoleLatitude;
        private string _powerPoleStreetLight;

        private ICommand _addStudentCommand;
        private ICommand _addTeacherCommand;
        private ICommand _addPowerPoleCommand;

        private UnityContainer _unityContainer;

        public event PropertyChangedEventHandler PropertyChanged;

        public InputsViewModel(IStudentService studentService,
                               ITeacherService teacherService,
                               IPowerPoleService powerPoleService)
        {
            _studentService = studentService;
            _teacherService = teacherService;
            _powerPoleService = powerPoleService;
        }

        public string StudentName
        {
            get
            {
                return this._studentName;
            }
            set
            {
                this._studentName = value;
                NotifyPropertyChanged();
            }
        }
        public string StudentEmail
        {
            get
            {
                return this._studentEmail;
            }
            set
            {
                this._studentEmail = value;
                NotifyPropertyChanged();
            }
        }
        public string StudentSpecialty
        {
            get
            {
                return this._studentSpecialty;
            }
            set
            {
                this._studentSpecialty = value;
                NotifyPropertyChanged();
            }
        }
        public string StudentCourse
        {
            get
            {
                return this._studentCourse;
            }
            set
            {
                this._studentCourse = value;
                NotifyPropertyChanged();
            }
        }

        public string TeacherName
        {
            get
            {
                return this._teacherName;
            }
            set
            {
                this._teacherName = value;
                NotifyPropertyChanged();
            }
        }
        public string TeacherEmail
        {
            get
            {
                return this._teacherEmail;
            }
            set
            {
                this._teacherEmail = value;
                NotifyPropertyChanged();
            }
        }
        public string TeacherRank
        {
            get
            {
                return this._teacherRank;
            }
            set
            {
                this._teacherRank = value;
                NotifyPropertyChanged();
            }
        }

        public string PowerPoleAddress
        {
            get
            {
                return this._powerPoleAddress;
            }
            set
            {
                this._powerPoleAddress = value;
                NotifyPropertyChanged();
            }
        }
        public string PowerPoleLatitude
        {
            get
            {
                return this._powerPoleLatitude;
            }
            set
            {
                this._powerPoleLatitude = value;
                NotifyPropertyChanged();
            }
        }
        public string PowerPoleStreetLight
        {
            get
            {
                return this._powerPoleStreetLight;
            }
            set
            {
                this._powerPoleStreetLight = value;
                NotifyPropertyChanged();
            }
        }
        public string PowerPolePowerWire
        {
            get
            {
                return this._powerPolePowerWire;
            }
            set
            {
                this._powerPolePowerWire = value;
                NotifyPropertyChanged();
            }
        }

        public ICommand AddStudentCommand
        {
            get
            {
                return this._addStudentCommand
                       ?? (this._addStudentCommand = new RelayCommand(this.AddStudentClicked));
            }
        }
        public ICommand AddTeacherCommand
        {
            get
            {
                return this._addTeacherCommand
                       ?? (this._addTeacherCommand = new RelayCommand(this.AddTeacherClicked));
            }
        }
        public ICommand AddPowerPoleCommand
        {
            get
            {
                return this._addPowerPoleCommand
                       ?? (this._addPowerPoleCommand = new RelayCommand(this.AddPowerPoleClicked));
            }
        }

        private void AddStudentClicked(object args)
        {
            _unityContainer = (UnityContainer)Application.Current.Resources["IoC"];
            _studentService = (StudentService)_unityContainer.Resolve<IStudentService>();

            if (StudentSpecialty != null && StudentCourse != null)
            {
                StudentSpecialty = ComboBoxValueExtractor(StudentSpecialty);
                StudentCourse = ComboBoxValueExtractor(StudentCourse);
            }

            try
            {
                _studentService.AddStudent(StudentName, StudentEmail, StudentSpecialty, StudentCourse);
                MessageBox.Show("Student is successfully added!");
            }
            catch (ArgumentException ae)
            {
                MessageBox.Show(ae.Message);
            }
        }
        private void AddTeacherClicked(object args)
        {
            if (TeacherRank != null)
            {
                TeacherRank = ComboBoxValueExtractor(TeacherRank);
            }

            try
            {
                _teacherService.AddTeacher(TeacherName, TeacherEmail, TeacherRank);
                MessageBox.Show("Teacher is successfully added!");
            }
            catch (ArgumentException ae)
            {
                MessageBox.Show(ae.Message);
            }
        }
        private void AddPowerPoleClicked(object args)
        {
            if (PowerPoleAddress!= null)
            {
                PowerPoleAddress = ComboBoxValueExtractor(PowerPoleAddress);
            }

            try
            {
                _teacherService.AddTeacher(TeacherName, TeacherEmail, TeacherRank);
                MessageBox.Show("Power Pole is successfully added!");
            }
            catch (ArgumentException ae)
            {
                MessageBox.Show(ae.Message);
            }
        }

        private string ComboBoxValueExtractor(string item)
        {
            return item.Split(' ').Skip(1).FirstOrDefault();
        }
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
