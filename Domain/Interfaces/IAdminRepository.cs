using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IAdminRepository
    {
        Admin GetAdminById(int id);
        IEnumerable<Admin> GetAllAdmins();
        void AddAdmin(Admin admin);
        void UpdateAdmin(Admin admin);
        void DeleteAdmin(int id);
    }
}
