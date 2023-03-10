using DCSoft.Domain.Models.Systems;
using System.Threading.Tasks;
using Util.Domain.Repositories;

namespace DCSoft.Domain.Repositories.Systems
{
    /// <summary>
    /// 应用程序仓储
    /// </summary>
    public interface IApplicationRepository : IRepository<Application>
    {
        /// <summary>
        /// 通过应用程序编码查找
        /// </summary>
        /// <param name="code">应用程序编码</param>
        Task<Application> GetByCodeAsync(string code);

        /// <summary>
        /// 是否允许跨域访问
        /// </summary>
        /// <param name="origin">来源</param>
        Task<bool> IsOriginAllowedAsync(string origin);

        /// <summary>
        /// 是否允许创建应用程序
        /// </summary>
        /// <param name="entity">应用程序</param>
        Task<bool> CanCreateAsync(Application entity);

        /// <summary>
        /// 是否允许修改应用程序
        /// </summary>
        /// <param name="entity">应用程序</param>
        Task<bool> CanUpdateAsync(Application entity);
    }
}