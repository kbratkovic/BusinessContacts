using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BusinessContacts.Data;
using BusinessContacts.Models;
using Microsoft.AspNetCore.Authorization;

namespace BusinessContacts.Controllers
{
    public class ContactDataController : Controller
    {
        private readonly BusinessContactsContext _context;

        public ContactDataController(BusinessContactsContext context)
        {
            _context = context;
        }

        // GET: ContactData
        [AllowAnonymous]
        public async Task<IActionResult> Index(string searchPattern)
        {
            ViewBag.Query = searchPattern;
            if (!String.IsNullOrEmpty(searchPattern))
            {
                var contact = from contactData in _context.ContactDataModel
                              where contactData.CompanyName.Contains(searchPattern)
                              select contactData;

                return View(contact.ToList());
            }
            return View(await _context.ContactDataModel.ToListAsync());
        }

        // GET: ContactData/Details/5
        [AllowAnonymous]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contactDataModel = await _context.ContactDataModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contactDataModel == null)
            {
                return NotFound();
            }

            return View(contactDataModel);
        }

        // GET: ContactData/Create
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST: ContactData/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CompanyName,BussinessTaxNumber,City,Address,ContactPerson,MobilePhone,Email")] ContactDataModel contactDataModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(contactDataModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(contactDataModel);
        }

        // GET: ContactData/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contactDataModel = await _context.ContactDataModel.FindAsync(id);
            if (contactDataModel == null)
            {
                return NotFound();
            }
            return View(contactDataModel);
        }

        // POST: ContactData/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CompanyName,BussinessTaxNumber,City,Address,ContactPerson,MobilePhone,Email")] ContactDataModel contactDataModel)
        {
            if (id != contactDataModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contactDataModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContactDataModelExists(contactDataModel.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(contactDataModel);
        }

        // GET: ContactData/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contactDataModel = await _context.ContactDataModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contactDataModel == null)
            {
                return NotFound();
            }

            return View(contactDataModel);
        }

        // POST: ContactData/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var contactDataModel = await _context.ContactDataModel.FindAsync(id);
            _context.ContactDataModel.Remove(contactDataModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContactDataModelExists(int id)
        {
            return _context.ContactDataModel.Any(e => e.Id == id);
        }
    }
}
