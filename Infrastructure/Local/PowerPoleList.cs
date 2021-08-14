using Domain.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.IO;
using System.Xml.Serialization;

namespace Infrastructure.Local
{
    [Serializable]
    public class PowerPoleList : ObservableCollection<PowerPole>
    {
        public PowerPoleList() : base()
        {
            this.CollectionChanged += PowerPoleList_CollectionChanged;
            this.LoadData();
        }

        private void LoadData()
        {
            if (File.Exists("PowerPoles.xml"))
            {
                var serializer = new XmlSerializer(typeof(List<PowerPole>));
                using (var file = File.OpenRead("PowerPoles.xml"))
                {
                    var savedData = (List<PowerPole>)serializer.Deserialize(file);

                    foreach (var powerPole in savedData)
                    {
                        Add(powerPole);
                    }
                }
            }
            else
            {
                Add(new PowerPole { Id = 1, Address = "Peter Lucas", Latitude = "peter.lucas@mail.com", PowerWire = "First", StreetLight = "Computer Science" });
                Add(new PowerPole { Id = 2, Address = "Martha Golding", Latitude = "m.golding@mail.com", PowerWire = "Second", StreetLight = "Computer Science" });
                Add(new PowerPole { Id = 3, Address = "Sandra Butler", Latitude = "s.butler@mail.com", PowerWire = "First", StreetLight = "Networking" });
                Add(new PowerPole { Id = 4, Address = "Robert Balentine", Latitude = "robert.b@mail.com", PowerWire = "Third", StreetLight = "Electronics" });
                Add(new PowerPole { Id = 5, Address = "Joseph Spicer", Latitude = "j.spicer@mail.com", PowerWire = "Second", StreetLight = "Networking" });
                Add(new PowerPole { Id = 6, Address = "Linda Sam", Latitude = "sam.linda@mail.com", PowerWire = "Fourth", StreetLight = "Networking" });
                Add(new PowerPole { Id = 7, Address = "Delia Smith", Latitude = "ddelia@mail.com", PowerWire = "Second", StreetLight = "Electronics" });
                Add(new PowerPole { Id = 8, Address = "Shannon Glass", Latitude = "shan.glass@mail.com", PowerWire = "Third", StreetLight = "Computer Science" });
                Add(new PowerPole { Id = 9, Address = "George Griffin", Latitude = "griffinn@mail.com", PowerWire = "First", StreetLight = "Computer Science" });
                Add(new PowerPole { Id = 10, Address = "Keith Neimann", Latitude = "k.neimann@mail.com", PowerWire = "Second", StreetLight = "Computer Science" });
                Add(new PowerPole { Id = 11, Address = "Kim Thomas", Latitude = "k.tommas@mail.com", PowerWire = "Fourth", StreetLight = "Electronics" });
                Add(new PowerPole { Id = 12, Address = "Jared Hilton", Latitude = "hiltonn@mail.com", PowerWire = "Third", StreetLight = "Electronics" });
                Add(new PowerPole { Id = 13, Address = "Brandy Hunt", Latitude = "hunt.brandy@mail.com", PowerWire = "Second", StreetLight = "Networking" });
                Add(new PowerPole { Id = 14, Address = "David Cox", Latitude = "d.coxx@mail.com", PowerWire = "First", StreetLight = "Computer Science" });
                Add(new PowerPole { Id = 15, Address = "Martha Mejia", Latitude = "mmejia@mail.com", PowerWire = "Third", StreetLight = "Computer Science" });
                Add(new PowerPole { Id = 16, Address = "Andrew Maez", Latitude = "a.maezz@mail.com", PowerWire = "Fourth", StreetLight = "Networking" });
                Add(new PowerPole { Id = 17, Address = "Connie Williams", Latitude = "c.williams@mail.com", PowerWire = "First", StreetLight = "Computer Science" });
                Add(new PowerPole { Id = 18, Address = "Brett Miller", Latitude = "bredd.mil@mail.com", PowerWire = "Third", StreetLight = "Electronics" });
                Add(new PowerPole { Id = 19, Address = "Kevin Vargas", Latitude = "kev.vargas@mail.com", PowerWire = "Second", StreetLight = "Networking" });
                Add(new PowerPole { Id = 20, Address = "Joseph Garmon", Latitude = "joseph.s.garmon@mail.com", PowerWire = "Fourth", StreetLight = "Computer Science" });
            }
        }

        private void PowerPoleList_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Remove)
            {
                foreach (PowerPole item in e.OldItems)
                {
                    item.PropertyChanged -= Item_PropertyChanged;
                }
            }
            else if (e.Action == NotifyCollectionChangedAction.Add)
            {
                foreach (PowerPole item in e.NewItems)
                {
                    item.PropertyChanged += Item_PropertyChanged;
                }
            }
        }

        private void Item_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            this.CreateXml();
        }

        private void CreateXml()
        {
            var serializer = new XmlSerializer(typeof(List<PowerPole>));
            using (var file = new FileStream("PowerPoles.xml", FileMode.Create))
            {
                serializer.Serialize(file, new List<PowerPole>(this));
            }
        }
    }
}
