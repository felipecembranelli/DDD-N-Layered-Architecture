using System.Web.Mvc;
using Sample.Application;
using Sample.Application.Contracts;
using Sample.Application.Services;
using Sample.Web.Models;



namespace Sample.Web.Controllers
{
    public class CustomerController : Controller
    {

        #region Members

        private ICustomerAppService _customerAppService;

        #endregion

        #region Constructor

        public CustomerController()
        {
            _customerAppService = new CustomerAppService();

        }

        #endregion

        //
        // GET: /Customer/

        public ActionResult Index()
        {
            var customerListDTOs = _customerAppService.FindAllCustomers();

            // fill view model
            var customerListVM = CustomerListVM.FillViewModel(customerListDTOs);

            // call view
            return View("Index", customerListVM);
            
        }

        //
        // GET: /Customer/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Customer/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Customer/Create

        [HttpPost]
        public ActionResult Create(AddCustomerVM customer)
        {
            try
            {
                if (!customer.IsValid())
                {
                    //todo: create custom exceptions
                    return new JsonResult() { };
                }
                    

                var customerDTO = customer.FillDTO(customer);

                // call application service
                _customerAppService.AddNewCustomer(customerDTO);


                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        
        //
        // GET: /Customer/Edit/5
 
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Customer/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Customer/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Customer/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
