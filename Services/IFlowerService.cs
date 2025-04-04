using FlowerInventory.Models;

namespace FlowerInventory.Services
{
    public interface IFlowerService
    {
        IEnumerable<Flower> GetAllFlowers();
        Flower GetFlowerById(int id);
        void AddFlower(Flower flower);
        void UpdateFlower(Flower flower);
        void DeleteFlower(int id);
    }
}
