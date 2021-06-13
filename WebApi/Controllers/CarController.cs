using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApı.Model;

namespace WebApı.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private CarRepository _carRepository;

        public CarController(CarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        [HttpGet]
        public IEnumerable<Car> Get()
        {
            return _carRepository.GetAll();
        }
        [HttpGet("{id}")]
        public Car Get(int id)
        {
            return _carRepository.GetById(id);
        }
        [HttpPost]
        public void Post([FromBody] Car prod)
        {
            if (ModelState.IsValid)
                _carRepository.Add(prod);
        }
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Car car)
        {
            car.CarId = id;
            if (ModelState.IsValid)
                _carRepository.Update(car);
        }
        [HttpDelete]
        public void Delete(int id)
        {
            _carRepository.Delete(id);
        }
    }
}
