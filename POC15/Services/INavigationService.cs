using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace POC15.Services
{
    public interface INavigationService
    {
        Task GoToRoute(string route);
    }
}
