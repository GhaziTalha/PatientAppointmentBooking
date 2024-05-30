using PatientAppointmentBooking.Models;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace PatientAppointmentBooking.Controllers
{
    public class PatientBookingsController : Controller
    {
        private PatientBookingContext db = new PatientBookingContext();

        // GET: PatientBookings
        public ActionResult Index()
        {
            ViewBag.Message = TempData["Message"];
            return View(db.PatientBookings.ToList());
        }


        // GET: PatientBookings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PatientBooking patientBooking = db.PatientBookings.Find(id);
            if (patientBooking == null)
            {
                return HttpNotFound();
            }
            return View(patientBooking);
        }

        // GET: PatientBookings/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PatientBookings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FirstName,LastName,DOB,MobileNo,EmailID,DoctorName,AppointmentSlot")] PatientBooking patientBooking)
        {
            if (ModelState.IsValid)
            {
                db.PatientBookings.Add(patientBooking);
                db.SaveChanges();
                TempData["SuccessMessage"] = "Appointment booked successfully!";
                return RedirectToAction("Create");
            }

            return View(patientBooking);
        }

        // GET: PatientBookings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PatientBooking patientBooking = db.PatientBookings.Find(id);
            if (patientBooking == null)
            {
                return HttpNotFound();
            }
            return View(patientBooking);
        }

        // POST: PatientBookings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,LastName,DOB,MobileNo,EmailID,DoctorName,AppointmentSlot")] PatientBooking patientBooking)
        {
            if (ModelState.IsValid)
            {
                db.Entry(patientBooking).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(patientBooking);
        }

        // GET: PatientBookings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PatientBooking patientBooking = db.PatientBookings.Find(id);
            if (patientBooking == null)
            {
                return HttpNotFound();
            }
            return View(patientBooking);
        }

        // POST: PatientBookings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PatientBooking patientBooking = db.PatientBookings.Find(id);
            db.PatientBookings.Remove(patientBooking);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
