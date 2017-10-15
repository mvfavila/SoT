namespace SoT.Application.Interfaces
{
    public interface IBaseAppService
    {
        void BeginTransaction();

        void Commit();
    }
}
