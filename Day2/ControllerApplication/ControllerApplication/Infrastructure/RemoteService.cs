using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace ControllerApplication.Infrastructure
{
    public class RemoteService
    {
        public string GetRemoteData()
        {
            Thread.Sleep(1000);
            return "sleeeep";
        }

        public async Task<string> GetRemoteDataAsync()
        {
            return await Task<string>.Factory.StartNew(() =>
            {
                Thread.Sleep(2000);
                return "Hello from asenc";
            });
        }
    }
}