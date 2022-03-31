using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Mission13.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Mission13.Controllers
{
    public class HomeController : Controller
    {
        
        private BowlingDbContext _context { get; set; }

        public HomeController(BowlingDbContext temp)
        {
            _context = temp;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult DataView(int teamid)
        {



            if (teamid != 0)
            {
                ViewBag.TeamDisplay = _context.Teams.Single(x => x.TeamID == teamid).TeamName;

                ViewBag.SelectedTeam = _context.Teams.Single(x => x.TeamID == teamid);
                ViewBag.SelectedTeamID = ViewBag.SelectedTeam.TeamID;
            }
            else
            {
                ViewBag.TeamDisplay = "Contacts";
                ViewBag.SelectedTeamID = 0 ;

            }
            ViewBag.Teams = _context.Teams.ToList();

            var bowlers= _context.Bowlers.Where(b => b.TeamID == teamid || teamid == 0).ToList();

            return View(bowlers);
        }

        [HttpGet]
        public IActionResult AddNewBowler()
        {
            ViewBag.Teams = _context.Teams.ToList();


            return View();
        }

        [HttpPost]
        public IActionResult AddNewBowler(Bowler bo)
        {
            _context.Add(bo);
            _context.SaveChanges();

            return RedirectToAction("DataView");
        }

        [HttpGet]
        public IActionResult Edit(int bowlerid)
        {

            ViewBag.Teams = _context.Teams.ToList();
            var bowler = _context.Bowlers.Single(x => x.BowlerId == bowlerid);

            return View(bowler);
        }

        [HttpPost]
        public IActionResult Edit(Bowler Bo)
        {
            _context.Update(Bo);
            _context.SaveChanges();



            return RedirectToAction("DataView");
        }

        [HttpGet]
        public IActionResult Delete(int bowlerid)
        {


            var bowler = _context.Bowlers.Single(x => x.BowlerId == bowlerid);

            

            return View(bowler);
        }

        [HttpPost]
        public IActionResult Delete(Bowler bo)
        {
            _context.Bowlers.Remove(bo);
            _context.SaveChanges();


            return RedirectToAction("DataView");
        }


    }
}
