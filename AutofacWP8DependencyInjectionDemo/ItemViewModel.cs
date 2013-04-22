namespace AutofacWP8DependencyInjectionDemo
{
    using System.ComponentModel;
    using System.Runtime.CompilerServices;

    using AutofacWP8DependencyInjectionDemo.Annotations;

    /// <summary>
    /// This ViewModel will be dynamically injected into the view.
    /// </summary>
    public class ItemViewModel : INotifyPropertyChanged
    {
        private string lineOne;
        private string lineTwo;
        private string lineThree;

        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Sample ViewModel property; this property is used in the view to display its value using a Binding.
        /// </summary>
        /// <returns></returns>
        public string LineOne
        {
            get
            {
                return this.lineOne;
            }
            set
            {
                if (value != this.lineOne)
                {
                    this.lineOne = value;
                    this.OnPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Sample ViewModel property; this property is used in the view to display its value using a Binding.
        /// </summary>
        /// <returns></returns>
        public string LineTwo
        {
            get
            {
                return this.lineTwo;
            }
            set
            {
                if (value != this.lineTwo)
                {
                    this.lineTwo = value;
                    this.OnPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Sample ViewModel property; this property is used in the view to display its value using a Binding.
        /// </summary>
        /// <returns></returns>
        public string LineThree
        {
            get
            {
                return this.lineThree;
            }
            set
            {
                if (value != this.lineThree)
                {
                    this.lineThree = value;
                    this.OnPropertyChanged();
                }
            }
        }

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