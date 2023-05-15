using CollegeManagementWebAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CollegeManagementWebAPI.Repositories
{
    public interface INotice
    {
        Task<List<Notice>> GetAllNotices();
    }
}
