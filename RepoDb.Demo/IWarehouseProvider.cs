namespace RepoDb.Demo
{
    public interface IWarehouseProvider
    {
        Warehouse[] Get();
        Warehouse Get(int id);
    }
}