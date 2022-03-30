using BowlingLeague.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace BowlingLeague.Controllers
{
    public class HomeController : Controller
    {
      private BowlingDbContext _context { get; set; }

        public HomeController(BowlingDbContext temp)
        {
            _context = temp;
        }

        public IActionResult Index(int teamid =-1)
        {
            ViewBag.TeamNames = _context.Teams.ToList();

            if (teamid == -1)
            {
                
                ViewBag.TeamInfo = _context.Teams.Where(x => x.TeamID == teamid).FirstOrDefault();
                ViewBag.Bowlers = _context.Bowlers.ToList();
            }
            else
            {
                
                ViewBag.TeamInfo = _context.Teams.Where(x => x.TeamID == teamid).FirstOrDefault();
                ViewBag.Bowlers = _context.Bowlers.Where(x => x.TeamID == teamid).ToList();
            }
            
            
            var blah = _context.Bowlers.ToList();
            return View(blah);
        }

        //FillOutApplication 
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.TeamNames = _context.Teams.ToList();
            ViewBag.Bowlers = _context.Bowlers.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Create(Bowler b)
        {
            if (ModelState.IsValid)
            {
                
                //Bowler b = new Bowler();
                _context.Add(b);
                
                _context.SaveChanges();
                return View("Confirmation", b);
            }
            else
            {
                ViewBag.TeamNames = _context.Teams.ToList();
                ViewBag.Bowlers = _context.Bowlers.ToList();
                return View(b);
            }
        }

        [HttpGet]
        public IActionResult Edit(int bowlerid)
        {
            ViewBag.Bowlers = _context.Bowlers.ToList();
            ViewBag.TeamNames = _context.Teams.ToList();
            var bowlerinfo = _context.Bowlers.Single(x => x.BowlerID == bowlerid);
            return View("Create", bowlerinfo);
        }

        [HttpPost]
        public IActionResult Edit(Bowler b) 
        {
            if (ModelState.IsValid)
            {
                _context.Update(b);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.TeamNames = _context.Teams.ToList();
                return View(b);
            }
            
        }

        [HttpGet]
        public IActionResult Delete(int bowlerid)
        {
            var bowlerinfo = _context.Bowlers.Single(x => x.BowlerID == bowlerid);
            return View(bowlerinfo);
        }

        [HttpPost]
        public IActionResult Delete(Bowler b)
        {
            _context.Bowlers.Remove(b);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
       
    }
}
