using Microsoft.AspNetCore.Mvc;
using MVCPIzzaOrderingApplication.Services;
using PizzaOrderingApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCPIzzaOrderingApplication.Controllers
{
    public class OrderDetailController : Controller
    {
        private readonly IRepo<OrderDetail> _repo;

        public OrderDetailController(IRepo<OrderDetail> repo)
        {
            _repo = repo;
        }
        public IActionResult Index()
        {
            return View(_repo.GetOrderDetails());
        }
        public IActionResult Details()
        {
            return View(_repo.GetOrderItemDetails(1));
        }
    }
}
