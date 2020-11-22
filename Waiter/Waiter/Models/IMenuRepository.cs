using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Waiter.Models
{
    public interface IMenuRepository
    {
        void SaveOrder(MenuOrder order);

        List<MenuOrder> GetMenu();

        Task<List<MenuOrder>> GetMenuAsync();
    }
}
