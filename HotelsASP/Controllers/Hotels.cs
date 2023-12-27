using HotelsASP.Models;
using Microsoft.AspNetCore.Mvc;

namespace HotelsASP.Controllers;

public class Hotels : Controller
{
    private static List<Hotel> hotelList = new List<Hotel>
    {
        new Hotel
        {
            HotelId = 1, Name = "Four Season Hotel", Rooms = 50, Description = "A great hotel", Location = "Beirut - Water Front",
            Phone = "+961 71 123 456", Rating = 4, ImgUrl ="/img/hotel 1.jpg"
        },
        new Hotel
        {
            HotelId = 2, Name = "Habtour Hotel", Rooms = 75, Description = "Another great hotel", Location = "Beirut - Sen Lfel",
            Phone = "+961 3 123 456", Rating = 3, ImgUrl = "/img/hotel 2.jpg"
        }
    };

    public IActionResult Index()
    {
        return View(hotelList);
    }

    public IActionResult Details(int id)
    {
        Hotel hotel = hotelList.FirstOrDefault(h => h.HotelId == id);
        if (hotel == null)
        {
            return NotFound();
        }
        return View(hotel);
    }
    public IActionResult Delete(int id)
    {
        Hotel hotel = hotelList.FirstOrDefault(h => h.HotelId == id);
        if (hotel == null)
        {
            return NotFound();
        }
        hotelList.Remove(hotel);
        return RedirectToAction("Index");
    }
    
    [HttpGet]
    public IActionResult CreateHotel()
    {
        return View();
    }

    [HttpPost]
    public IActionResult CreateHotel(Hotel newHotel)
    {
        hotelList.Add(newHotel);
        return RedirectToAction("index");
    }
}
    
    
