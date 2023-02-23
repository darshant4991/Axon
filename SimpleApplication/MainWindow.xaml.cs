/**
 * Copyright Axon Enterprise, Inc (c) 2022
 * Licensed for use to Axon partners with active Axon NDA
 **/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Net.Http;
using System.Linq.Expressions;
using System.Text.Json;
using System.Collections;
using System.Threading;
using System.Windows.Threading;
using System.Timers;
using System.Runtime.InteropServices;
using SimpleApplication.Models;
using SimpleApplication.BLL;
using Microsoft.Extensions.Logging;

namespace SimpleApplication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly ApiService _apiService;
        private readonly ILogger<MainWindow> _logger;
        public MainWindow(ApiService apiService, ILogger<MainWindow> logger)
        {
            _apiService = apiService;
            _logger = logger;
            InitializeComponent(); 
            RegisterTimer();
        }
        private void RegisterTimer() 
        {
            System.Timers.Timer aTimer = new System.Timers.Timer();
            aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            aTimer.Interval = 1;
            aTimer.Enabled = true;
        }
        private void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            Dispatcher.BeginInvoke((Action)delegate ()
            {
                if (DateTime.Now.Hour % 2 == 1)
                {
                    MainTabControl.Background = Brushes.DarkGray;
                    this.Background = Brushes.DarkGray;
                }
                else
                {

                    MainTabControl.Background = Brushes.White;
                    this.Background = Brushes.White;
                }
                CurrentTimeLabel.Content = DateTime.Now.ToString("HH:mm:ss:fff");
            });
        }
        private async void GetAnimalAPIs_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var result = await _apiService.GetAnimals();
                AnimalsGrid.ItemsSource = result.entries;
                _logger.LogInformation("Animal APIs retrieved successfully.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving animal APIs.");
            }
            //HttpClient c = new HttpClient();
            //HttpResponseMessage r = c.GetAsync("https://api.publicapis.org/entries?Category=Animals").Result;
            //string rb = r.Content.ReadAsStringAsync().Result;
            ////AnimalResult res = JsonSerializer.Deserialize<AnimalResult>(rb);
            //Result res = JsonSerializer.Deserialize<Result>(rb);
            ////for (int i = 0; i < res.count; i++)
            ////{
            ////    Dictionary<string, object> o = res.entries[i];
            ////    string li = "Name: " + o["API"].ToString() + " - Description: " + o["Description"].ToString() + " - Link: " + o["Link"].ToString();

            ////    AnimalsList.Items.Add(li);
            ////}
        }
        private async void GetWeatherAPIs_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var result = await _apiService.GetWeather();
                WeatherGrid.ItemsSource = result.entries;
                _logger.LogInformation("Weather APIs retrieved successfully.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving weather APIs.");
            }
        }
        private async void GetVideoAPIs_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var result = await _apiService.GetVideo();
                VideoGrid.ItemsSource = result.entries;
                _logger.LogInformation("Video APIs retrieved successfully.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving video APIs.");
            }
        }
        private async void GetHealthAPIs_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var result = await _apiService.GetHealth();
                HealthGrid.ItemsSource = result.entries;
                _logger.LogInformation("Health APIs retrieved successfully.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving health APIs.");
            }
        }
    }
}
