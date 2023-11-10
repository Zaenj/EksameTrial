using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WoodPelletsLib
{
    public class WoodPelletRepository
    {
        private int _nextId = 1;
        private readonly List<WoodPellet> _woodPellet = new();

        public WoodPelletRepository()
        { 
            _woodPellet.Add(new WoodPellet() { Id = _nextId++, Brand = "Raze", Price = 123, Quality = 4 });
            _woodPellet.Add(new WoodPellet() { Id = _nextId++, Brand = "Spruce", Price = 224, Quality = 1 });
            _woodPellet.Add(new WoodPellet() { Id = _nextId++, Brand = "Dark", Price = 522, Quality = 5 });
            _woodPellet.Add(new WoodPellet() { Id = _nextId++, Brand = "Jungle", Price = 1244, Quality = 2});
            _woodPellet.Add(new WoodPellet() { Id = _nextId++, Brand = "Plank", Price = 1543, Quality = 3 });
        }   
        public List<WoodPellet> GetWoodPellets() 
        { 
            return _woodPellet;
        }

        public WoodPellet? GetById(int id)
        {
            return _woodPellet.Find(WoodPellet => WoodPellet.Id == id);
        }

        public WoodPellet Add(WoodPellet woodPellet)
        {
            woodPellet.Validate();
            woodPellet.Id = _nextId++;
            _woodPellet.Add(woodPellet); 
            return woodPellet;
        }

        public WoodPellet? Update(int id, WoodPellet woodPellet)
        {
            woodPellet.Validate();
            WoodPellet? existingwoodpallet = GetById(id);
            if (existingwoodpallet == null) { return null; }
            existingwoodpallet.Brand = woodPellet.Brand;
            existingwoodpallet.Price = woodPellet.Price;
            existingwoodpallet.Quality = woodPellet.Quality;
               return existingwoodpallet;
        }
    }
}
