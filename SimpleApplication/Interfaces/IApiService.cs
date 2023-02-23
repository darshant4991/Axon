using SimpleApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleApplication.Interfaces
{
    public interface IApiService
    {
        Task<Result> GetAnimals();
        Task<Result> GetWeather();
        Task<Result> GetVideo();
        Task<Result> GetHealth();
    }
}
