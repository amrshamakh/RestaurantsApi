using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurants.Application.Common.Interfaces
{
    public interface IFileStorage
    {
        Task<string> SaveFileAsync(Stream stream, string fileName,string contentType);
    }
}
