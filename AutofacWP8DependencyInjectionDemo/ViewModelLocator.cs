namespace AutofacWP8DependencyInjectionDemo
{
    using Autofac;

    public class ViewModelLocator
    {
        private readonly IContainer container;

        public ViewModelLocator()
        {
            var containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterType<MainViewModel>();
            containerBuilder.RegisterType<ItemViewModel>();

            this.container = containerBuilder.Build();
        }

        public MainViewModel MainViewModel
        {
            get
            {
                return this.container.Resolve<MainViewModel>();
            }
        }

        public ItemViewModel ItemViewModel
        {
            get
            {
                return this.container.Resolve<ItemViewModel>();
            }
        }
    }
}