using CM.DataAccess.Repository.UnitOfWork;

namespace CM.WebApi.BLL.Base
{
    public class BllBase
    {
        protected IUnitOfWork UoW { get; }

        public BllBase(IUnitOfWork uoW)
        {
            UoW = uoW;
        }
    }
}