using Prism.Ioc;

namespace HistogramUi
{
    using Histogram.Core.Providers;
    using Histogram.Core.Services;
    using HistogramUi.ViewModels;
    using HistogramUi.Views;
    using System.Windows;

    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.Register<IBinProvider, BinProvider>();
            containerRegistry.Register<IHistogramService, HistogramService>();
        }
    }
}
