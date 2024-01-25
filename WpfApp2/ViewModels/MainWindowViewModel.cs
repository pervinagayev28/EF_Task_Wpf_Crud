using ConsoleApp5.Contexts;
using ConsoleApp5.Entities;
using ConsoleApp5.Entities.BaseEntities;
using ConsoleApp5.Migrations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Whatsapp.Commands;
using Whatsapp.Services;

namespace WpfApp2.ViewModels
{
    public class MainWindowViewModel : ServiceINotifyPropertyChanged
    {
        public ObservableCollection<string> Tables { get => tables; set { tables = value; OnPropertyChanged(); } }
        private MyDbContext context = new();
        private ObservableCollection<string> tables;


        public ICommand GetCommand { get; set; }
        public MainWindowViewModel()
        {
            startUp();
            GetCommand = new Command(ExecuteGetCommand, CanExecuteGetCommand);
        }

        private bool CanExecuteGetCommand(object obj) =>
            obj != null;

        private void ExecuteGetCommand(object obj)
        {


            foreach (var entity in context.Model.GetEntityTypes())
            {
                var type = entity.ClrType;

                //var dtaa = context.Set<>();
            }

        }
     

        private async void startUp()
        {
            Tables = new(context.Model.GetEntityTypes().Select(e => e.Name.Substring(e.Name.LastIndexOf(".") + 1)).ToList());



        }
    }

}
