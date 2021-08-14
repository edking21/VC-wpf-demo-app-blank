using Domain.Models.Interfaces;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Domain.Models
{
    [Serializable, XmlRoot("PowerPole")]
    public class PowerPole : IPowerPole, INotifyPropertyChanged
    {
        private int _id;
        private string _address;
        private string _latitude;
        private string _powerWire;
        private string _streetLight;

        public int Id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
                OnPropertyChanged(nameof(Id));
            }
        }

        [Required(AllowEmptyStrings = false)]
        public string Address
        {
            get
            {
                return _address;
            }
            set
            {
                _address = value;
                OnPropertyChanged(nameof(Address));
            }
        }

        [Required]
        public string Latitude
        {
            get
            {
                return _latitude;
            }
            set
            {
                _latitude = value;
                OnPropertyChanged(nameof(Latitude));
            }
        }

        [Required(AllowEmptyStrings = false)]
        public string PowerWire
        {
            get
            {
                return _powerWire;
            }
            set
            {
                _powerWire= value;
                OnPropertyChanged(nameof(PowerWire));
            }
        }

        [Required(AllowEmptyStrings = false)]
        public string StreetLight
        {
            get
            {
                return _streetLight;
            }
            set
            {
                _streetLight = value;
                OnPropertyChanged(nameof(StreetLight));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}
