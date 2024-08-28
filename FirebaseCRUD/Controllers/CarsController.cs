using FirebaseCRUD.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace FirebaseCRUD.Controllers
{
    public class CarsController : Controller
    {
        // In-memory list to store cars
        private static List<Car> carList = new List<Car>();

        // GET: /Cars/Index (self note* try to add styling and main page)
        public IActionResult Index()
        {
            return View(carList);
        }

        // GET: /Cars/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: /Cars/Create
        [HttpPost]
        public IActionResult Create(Car car)
        {
            if (ModelState.IsValid)
            {
                // Assign a new CarId and add the car to the list
                car.CarId = carList.Count + 1;
                carList.Add(car);
                return RedirectToAction("Index");
            }
            return View(car);
        }

        // GET: /Cars/Edit/{id}
        public IActionResult Edit(int id)
        {
            var car = carList.FirstOrDefault(c => c.CarId == id);
            if (car == null)
            {
                return NotFound();
            }
            return View(car);
        }

        // POST: /Cars/Edit/{id}
        [HttpPost]
        public IActionResult Edit(Car updatedCar)
        {
            if (ModelState.IsValid)
            {
                var car = carList.FirstOrDefault(c => c.CarId == updatedCar.CarId);
                if (car == null)
                {
                    return NotFound();
                }

                car.Make = updatedCar.Make;
                car.Model = updatedCar.Model;
                car.Year = updatedCar.Year;

                return RedirectToAction("Index");
            }
            return View(updatedCar);
        }

        // GET: /Cars/Delete/{id}
        public IActionResult Delete(int id)
        {
            var car = carList.FirstOrDefault(c => c.CarId == id);
            if (car == null)
            {
                return NotFound();
            }
            return View(car);
        }

        // POST: /Cars/Delete/{id}
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var car = carList.FirstOrDefault(c => c.CarId == id);
            if (car != null)
            {
                carList.Remove(car);
            }
            return RedirectToAction("Index");
        }
    }
}
