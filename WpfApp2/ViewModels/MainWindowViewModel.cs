using ConsoleApp5.Contexts;
using ConsoleApp5.Entities;
using ConsoleApp5.Entities.BaseEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using Whatsapp.Commands;
using Whatsapp.Services;

namespace WpfApp2.ViewModels
{



    public class MainWindowViewModel : ServiceINotifyPropertyChanged
    {
        static bool check = true;
        static bool checkInserted = false;

        public ObservableCollection<object> datas { get => datas1; set { datas1 = value; OnPropertyChanged(); } }
        public ObservableCollection<string> Tables { get => tables; set { tables = value; OnPropertyChanged(); } }
        private MyDbContext context = new();
        private ObservableCollection<string> tables;

        private static int tempCount;
        private ObservableCollection<object> datas1;

        public ICommand GetCommand { get; set; }
        public ICommand UpdateCommand { get; set; }
        public ICommand InsertCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand AddingNewItem { get; set; }
        public MainWindowViewModel()
        {
            startUp();
            GetCommand = new Command(ExecuteGetCommand, CanExecuteGetCommand);
            UpdateCommand = new Command(ExecuteUpdateCommand, CanExecuteUpdateCommand);
            InsertCommand = new Command(ExecuteInsertCommand, CanExecuteUInsertCommand);
            DeleteCommand = new Command(ExecuteDeleteCommand, CanExecuteDeleteCommand);
            AddingNewItem = new Command(ExecuteAddingNewItem);
        }

        private async Task ExecuteAddingNewItem(object arg)
        {
            checkInserted = false;
        }

        private bool CanExecuteDeleteCommand(object obj) =>
            ((DataGrid)((Grid)obj).FindName("DataGrid")).SelectedItem is not null
            && check
            && checkInserted;

        private async Task ExecuteDeleteCommand(object arg)
        {
            dynamic data = ((DataGrid)((Grid)arg).FindName("DataGrid")).SelectedItem;
            int Id = data.Id;
            //context.Find(id);
            var tablename = ((ComboBox)((Grid)arg).FindName("TableName")).SelectedValue;
            switch (tablename)
            {
                case "Author":
                    context?.Authors?.Remove(await context?.Authors?.FirstAsync(b => b.Id == Id)!); break;
                case "Book":
                    context?.Books?.Remove(await context?.Books?.FirstAsync(b => b.Id == Id)!); break;
                case "Category":
                    context?.Categories?.Remove(await context?.Categories?.FirstAsync(b => b.Id == Id)!); break;
                case "Department":
                    context?.Departments?.Remove(await context?.Departments?.FirstAsync(b => b.Id == Id)!); break;
                case "Facultie":
                    context?.Faculties?.Remove(await context?.Faculties?.FirstAsync(b => b.Id == Id)!); break;
                case "Group":
                    context?.Groups?.Remove(await context?.Groups?.FirstAsync(b => b.Id == Id)!); break;
                case "Lib":
                    context?.Libs?.Remove(await context?.Libs?.FirstAsync(b => b.Id == Id)!); break;
                case "Press":
                    context?.Presses?.Remove(await context?.Presses?.FirstAsync(b => b.Id == Id)!); break;
                case "S_Card":
                    context?.S_Cards?.Remove(await context?.S_Cards?.FirstAsync(b => b.Id == Id)!); break;
                case "T_Card":
                    context?.T_Cards?.Remove(await context?.T_Cards?.FirstAsync(b => b.Id == Id)!); break;
                case "Teacher":
                    context?.Teachers?.Remove(await context?.Teachers?.FirstAsync(b => b.Id == Id)!); break;
                case "Theme":
                    context?.Themes?.Remove(await context?.Themes?.FirstAsync(b => b.Id == Id)!); break;
                case "Student":
                    context?.Students?.Remove(await context?.Students?.FirstAsync(b => b.Id == Id)!); break;
                default:
                    break;
            }
            await context?.SaveChangesAsync()!;
            await ExecuteGetCommand(arg);

        }

        private bool CanExecuteUInsertCommand(object obj) =>
           datas?.Count > tempCount;


        private async Task ExecuteInsertCommand(object obj)
        {
            //TakeLast(datas.Count - tempCount)
            //var adds = datas.OfType<Author>().TakeLast(datas.Count-tempCount);
            //await context.AddRangeAsync(data);
            //await context.SaveChangesAsync();
            var tablename = ((ComboBox)((Grid)obj).FindName("TableName")).SelectedValue;


            switch (tablename)
            {
                case "Author":
                    await context?.Authors?.AddRangeAsync(datas.OfType<Author>().TakeLast(datas.Count - tempCount))!;
                    break;
                case "Book":
                    await context?.Books?.AddRangeAsync(datas.OfType<Book>().TakeLast(datas.Count - tempCount))!; break;
                case "Category":
                    await context?.Categories?.AddRangeAsync(datas.OfType<Category>().TakeLast(datas.Count - tempCount))!; break;
                case "Department":
                    await context?.Departments?.AddRangeAsync(datas.OfType<Department>().TakeLast(datas.Count - tempCount))!; break;
                case "Facultie":
                    await context?.Faculties?.AddRangeAsync(datas.OfType<Facultie>().TakeLast(datas.Count - tempCount))!; break;
                case "Group":
                    await context?.Groups?.AddRangeAsync(datas.OfType<Group>().TakeLast(datas.Count - tempCount))!; break;
                case "Lib":
                    await context?.Libs?.AddRangeAsync(datas.OfType<Lib>().TakeLast(datas.Count - tempCount))!; break;
                case "Press":
                    await context?.Presses?.AddRangeAsync(datas.OfType<Press>().TakeLast(datas.Count - tempCount))!; break;
                case "S_Card":
                    await context?.S_Cards?.AddRangeAsync(datas.OfType<S_Card>().TakeLast(datas.Count - tempCount))!; break;
                case "T_Card":
                    await context?.T_Cards?.AddRangeAsync(datas.OfType<T_Card>().TakeLast(datas.Count - tempCount))!; break;
                case "Teacher":
                    await context?.Teachers?.AddRangeAsync(datas.OfType<Teacher>().TakeLast(datas.Count - tempCount))!; break;
                case "Theme":
                    await context?.Themes?.AddRangeAsync(datas.OfType<Theme>().TakeLast(datas.Count - tempCount))!; break;
                case "Student":
                    await context?.Students?.AddRangeAsync(datas.OfType<Student>().TakeLast(datas.Count - tempCount))!; break;
                default:
                    break;
            }


            try
            {
                await context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                ((Label)((Grid)obj).FindName("errorCode")).Content = e.Message;
                ((Label)((Grid)obj).FindName("errorCode")).Visibility = System.Windows.Visibility.Visible;
                return;
            }
           ((Label)((Grid)obj).FindName("errorCode")).Visibility = System.Windows.Visibility.Hidden;
            checkInserted = true;
            tempCount = datas.Count;
            await ExecuteGetCommand(obj);
        }

        private bool CanExecuteUpdateCommand(object obj) =>
            context.ChangeTracker.HasChanges();

        private async Task ExecuteUpdateCommand(object arg)
        {
            await context.SaveChangesAsync();
            await ExecuteGetCommand(arg);
        }

        private bool CanExecuteGetCommand(object obj) =>
             ((ComboBox)((Grid)obj).FindName("TableName")).SelectedIndex != -1;
        private async Task ExecuteGetCommand(object obj)
        {
            check = true;
            var tablename = ((ComboBox)((Grid)obj).FindName("TableName")).SelectedValue;
            datas = new();

            switch (tablename)
            {
                case "Author":
                    datas = new(await context.Authors.ToListAsync());
                    if (datas.Count == 0)
                    {
                        datas.Add(new Author());
                        check = false;
                    }
                    break;
                case "Book":
                    datas = new(await context.Books.ToListAsync());
                    if (datas.Count == 0)
                        datas.Add(new Book());
                    break;
                case "Category":
                    datas = new(await context.Categories.ToListAsync());
                    if (datas.Count == 0)
                    {
                        datas.Add(new Category());
                        check = false;
                    }
                    break;
                case "Department":
                    datas = new(await context.Departments.ToListAsync());
                    if (datas.Count == 0)
                    {
                        datas.Add(new Department());
                        check = false;
                    }
                    break;
                case "Facultie":
                    datas = new(await context.Faculties.ToListAsync());
                    if (datas.Count == 0)
                    {
                        datas.Add(new Facultie());
                        check = false;
                    }
                    break;
                case "Group":
                    datas = new(await context.Groups.ToListAsync());
                    if (datas.Count == 0)
                    {
                        datas.Add(new Group());
                        check = false;
                    }
                    break;
                case "Lib":
                    datas = new(await context.Libs.ToListAsync());
                    if (datas.Count == 0)
                    {
                        datas.Add(new Lib());
                        check = false;
                    }
                    break;
                case "Press":
                    datas = new(await context.Presses.ToListAsync());
                    if (datas.Count == 0)
                    {
                        datas.Add(new Press());
                        check = false;
                    }
                    break;
                case "S_Card":
                    datas = new(await context.S_Cards.ToListAsync());
                    if (datas.Count == 0)
                    {
                        datas.Add(new S_Card());
                        check = false;
                    }
                    break;
                case "T_Card":
                    datas = new(await context.T_Cards.ToListAsync());
                    if (datas.Count == 0)
                    {
                        datas.Add(new T_Card());
                        check = false;
                    }
                    break;
                case "Teacher":
                    datas = new(await context.Teachers.ToListAsync());
                    if (datas.Count == 0)
                    {
                        datas.Add(new Teacher());
                        check = false;
                    }
                    break;
                case "Theme":
                    datas = new(await context.Themes.ToListAsync());
                    if (datas.Count == 0)
                    {
                        datas.Add(new Theme());
                        check = false;
                    }
                    break;
                case "Student":
                    datas = new(await context.Students.ToListAsync());
                    if (datas.Count == 0)
                    {
                        datas.Add(new Student());
                        check = false;
                    }
                    break;
                default:
                    break;
            }
            if (check)
                tempCount = datas.Count;
            else
                tempCount = 0;


        }


        private async void startUp()
        {
            Tables = new(context.Model.GetEntityTypes().Select(e => e.Name.Substring(e.Name.LastIndexOf(".") + 1)).ToList());



        }
    }

}
