using Microsoft.Extensions.Configuration;
using System.Configuration;
using System.Data;
using System.IO;
using System.Windows;

namespace JulioCode.Views
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        #region ConfigurationBuilder
        private ConfigurationBuilder _configurationBuilder;
        public ConfigurationBuilder ConfigurationBuilder
        {
            get { return _configurationBuilder ?? (_configurationBuilder = new ConfigurationBuilder()); }
            set { _configurationBuilder = value; }
        }
        #endregion ConfigurationBuilder
        protected override void OnStartup(StartupEventArgs e) {

            var builder = ConfigurationBuilder;
            ConfigurationBuilder = builder.Build();

            base.OnStartup(e);


        }
    }

}
