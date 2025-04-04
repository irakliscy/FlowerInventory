
using FlowerInventory.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics; // For Debugging

namespace FlowerInventory.Services
{
    public class FlowerService : IFlowerService
    {
        private readonly FlowerInventoryContext _context;  

        
        public FlowerService(FlowerInventoryContext context)
        {
            _context = context;
        }

        public IEnumerable<Flower> GetAllFlowers()
        {
            return _context.Flowers.Include(f => f.Category).ToList(); 
        }

        public Flower GetFlowerById(int id)
        {
            return _context.Flowers.Include(f => f.Category).FirstOrDefault(f => f.Id == id);  
        }

        public void AddFlower(Flower flower)
        {
            Debug.WriteLine("Using Database: " + _context.Database.GetDbConnection().ConnectionString);
            Debug.WriteLine($"Adding flower: Name={flower.Name}, Type={flower.Type}, Price={flower.Price}, CategoryId={flower.CategoryId}");

            _context.Flowers.Add(flower);  
            _context.SaveChanges();
            Debug.WriteLine("Flower added to database.");
        }

        public void UpdateFlower(Flower flower)
        {
            _context.Flowers.Update(flower);  
            _context.SaveChanges();
        }

        public void DeleteFlower(int id)
        {
            var flower = _context.Flowers.Find(id);  
            if (flower != null)
            {
                _context.Flowers.Remove(flower); 
                _context.SaveChanges();
            }
        }
    }
}
