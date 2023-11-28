using Microsoft.AspNetCore.Mvc;
using Bussines;
using Entity;
using AppWebLab10.Models;

namespace AppWebLab10.Controllers
{
    public class InvoiceController : Controller
    {

        // GET: InvoiceController
        public ActionResult Index()
        {
            BInvoice bInvoice = new BInvoice();
            List<Invoice> invoicesEntity = bInvoice.GetInvoiceActives();
            List<InvoiceModel> invoices = invoicesEntity.Select(x =>
            {
                double v = Convert.ToDouble(x.Total);
                return new InvoiceModel
                {
                    Id = x.Invoice_id,
                    Total = x.Total,
                    IGV = (decimal)(0.18 * v)
                };
            }).ToList();

            return View(invoices);
        }

        // GET: InvoiceController/Delete/5
        public ActionResult Delete(int id)
        {
            BInvoice bInvoice = new BInvoice();
            bInvoice.DeleteInvoice(id);

            List<Invoice> invoicesEntity = bInvoice.GetInvoiceActives();
            List<InvoiceModel> invoices = invoicesEntity.Select(x =>
            {
                double v = Convert.ToDouble(x.Total);
                return new InvoiceModel
                {
                    Id = x.Invoice_id,
                    Total = x.Total,
                    IGV = (decimal)(0.18 * v)
                };
            }).ToList();
            return View("Index", invoices);
        }

        // POST: InvoiceController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: InvoiceController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: InvoiceController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: InvoiceController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateInvoiceModel model)
        {
            try
            {
                BInvoice bInvoice = new BInvoice();
                Invoice invoice = new Invoice();

                bInvoice.InsertInvoice(model.Customer_id, DateTime.Now, model.Total) ;
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: InvoiceController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: InvoiceController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


    }
}
