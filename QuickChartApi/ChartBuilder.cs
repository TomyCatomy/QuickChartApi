using ChartJSCore.Models;
using System.ComponentModel;
using System.Text.Json;

namespace QuickChartApi
{
    public class ChartBuilder : INotifyPropertyChanged
    {
        #region Private Fields
        private readonly QuickChart.Chart _chart = new();
        #endregion

        #region Event Handlers
        public event PropertyChangedEventHandler? PropertyChanged;
        #endregion

        #region Constructors
        public ChartBuilder(Chart config)
        {
            PropertyChanged += SetInternalConfigJson;

            Config = config;
        }
        #endregion

        #region Properties
        public int Width {
            get => _chart.Width;
            set => _chart.Width = value;
        }

        public int Height
        {
            get => _chart.Height;
            set => _chart.Height = value;
        }

        public double DevicePixelRatio
        {
            get => _chart.DevicePixelRatio;
            set => _chart.DevicePixelRatio = value;
        }

        public string Format
        {
            get => _chart.Format;
            set => _chart.Format = value;
        }

        public string BackgroundColor
        {
            get => _chart.BackgroundColor;
            set => _chart.BackgroundColor = value;
        }

        public string Key
        {
            get => _chart.Key;
            set => _chart.Key = value;
        }

        public string Version
        {
            get => _chart.Version;
            set => _chart.Version = value;
        }

        public string Scheme
        {
            get => _chart.Scheme;
            set => _chart.Scheme = value;
        }

        public string Host
        {
            get => _chart.Host;
            set => _chart.Host = value;
        }

        public int Port
        {
            get => _chart.Port;
            set => _chart.Port = value;
        }

        public Chart Config { get; set; }
        #endregion

        #region Private Methods
        private void SetInternalConfigJson(object? Sender, PropertyChangedEventArgs args)
        {
            if(args.PropertyName == nameof(Config))
                _chart.Config = JsonSerializer.Serialize(Config);
        }
        #endregion

        #region Public Methods
        public string GetUrl() => _chart.GetUrl();

        public string GetShortUrl() => _chart.GetShortUrl();

        public void ToFile(string filePath) => _chart.ToFile(filePath);

        public void ToByteArray() => _chart.ToByteArray();
        #endregion
    }
}
