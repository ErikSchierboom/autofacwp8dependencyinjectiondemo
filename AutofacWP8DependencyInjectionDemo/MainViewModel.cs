namespace AutofacWP8DependencyInjectionDemo
{
    using System;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Linq;
    using System.Runtime.CompilerServices;

    using AutofacWP8DependencyInjectionDemo.Annotations;

    public class MainViewModel : INotifyPropertyChanged
    {
        public MainViewModel(Func<ItemViewModel> createItemViewModelFunc)
        {
            this.Items = new ObservableCollection<ItemViewModel>();

            foreach (var index in Enumerable.Range(1, 20))
            {
                var itemViewModel = createItemViewModelFunc();
                itemViewModel.LineOne = "line one of item " + index;
                itemViewModel.LineTwo = "line two of item " + index;
                itemViewModel.LineThree = "line three of item " + index;

                this.Items.Add(itemViewModel);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public ObservableCollection<ItemViewModel> Items { get; private set; }

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = this.PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}