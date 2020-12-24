using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using ToDoList.Annotations;
using Xamarin.Forms;

namespace ToDoList
{
    public class ToDoListViewModel : INotifyPropertyChanged
    {
       ToDoListModel _model = new ToDoListModel();

        public ToDoListViewModel()
        {
            _model.PropertyChanged += (s, e) =>
            {
                OnPropertyChanged(e.PropertyName);
            };

            Delete = new Command<object>(i =>
            {
                _model.RemoveValue(i);
            });

            Add = new Command<string>(str => {
                _model.AddValue(str);
                InputText = string.Empty;
                OnPropertyChanged("InputText");
            });
        }

        public Command<string> Add { get; set; }
        public Command<object> Delete { get; set; }
        public ObservableCollection<object> MyValues => _model.ToDoItems;
        public string InputText { get; set; }
        public int Width => 100;
        public int Height => 20;

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}