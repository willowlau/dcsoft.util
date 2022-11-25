using DCSoft.Domain.Models;
using DCSoft.Domain.Models.Logs;
using Util.Domain.Repositories;

namespace DCSoft.Domain.Repositories.Logs
{
    /// <summary>
    /// 登录日志仓储
    /// </summary>
    public interface ILoginRepository : IRepository<Login>
    {
    }
}