using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using MagpieProject.Models;
using MagpieProject.ViewModels;
using Xamarin.Forms;

namespace MagpieProject.CustomUIComponents
{
    public class PeopleViewModel : BaseViewModel
    {
        public ICommand AddUserCommand { get; private set; }
        public ICommand RemoveUserCommand { get; private set; }

        public ObservableCollection<Person> People { get; set; } = new ObservableCollection<Person>();
        List<string> Initials = new List<string>() { "NP", "SM", "SP", "RP"};
        List<Color> colors = new List<Color>()
        {
            Color.FromHex("#18A0FB"),
            Color.FromHex("#6E56F4"),
            Color.FromHex("#E8637B"),
            Color.FromHex("#7D89FC"),
            Color.FromHex("#B43BEF")

        };
        public PeopleViewModel()
        {
            //PeopleCount = new List<object>();

            // setup the commands
            RemoveUserCommand = new Command(RemovePerson);
            CreateSampleData();
        }

        private void CreateSampleData()
        {
            // create 5 peeps
            foreach(var initial in Initials)
            {
                AddPerson(initial);
            }
        }

        private void AddPerson(string initial)
        {
            Random r = new Random();
            int indexofcolor = r.Next(0,colors.Count); //for ints
            
            // add a person using an Image from pravatar.cc
            People.Add(new Person { Initials = initial,
            RandomColor=colors[indexofcolor]
            });

            //OnPropertyChanged(nameof(PeopleCount));
        }

        private void RemovePerson()
        {
            if (People.Any())
            {
                People.Remove(People.Last());

                //OnPropertyChanged(nameof(PeopleCount));

            }
        }

        //public List<object> PeopleCount
        //{
        //    get
        //    {
        //        var numberToShow = 5;
        //        List<object> returnList = new List<object>();

        //        returnList.AddRange(People.Take(numberToShow));

        //        if (People.Count > numberToShow)
        //            returnList.Add(People.Count - numberToShow);

        //        return returnList;
        //    }
        //    set { }
        //} 
    }
}
