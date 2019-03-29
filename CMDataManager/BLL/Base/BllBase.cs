using CMDataModel.Repository.UnitOfWork;

namespace CMDataManager.BLL.Base
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