using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Waiter.Models
{
    public interface IMenuRepository
    {
        void SaveOrder(MenuOrder order);

        List<MenuOrder> GetMenu();

        Task<List<MenuOrder>> GetMenuAsync();
    }
}
