using retailbank.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity.Core.Objects;


namespace retailbank.Controllers
{
    public class homeController : Controller
    {

        DB03TMS24_1819Entities db = new DB03TMS24_1819Entities();
        // GET: home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult cashierhome()
        {
            return View();
        }

        public ActionResult adminhome()
        {
            return View();
        }


        public ActionResult login()

        {
            logincastle_3 lg = new logincastle_3();
            return View(lg);
        }
        [HttpPost]
        public ActionResult login(logincastle_3 lg)

        {
            try {
                if (ModelState.IsValid)
                {
                    if ((lg.username == "primeadmin") && (lg.password == "Access@333"))
                    {
                        Session["check"] = "primeadmin";
                        return RedirectToAction("adminHome");
                    }
                    else if ((lg.username == "cashieradmin") && (lg.password == "Cashier@333"))
                    {
                        Session["check"] = "cashier";
                        return RedirectToAction("cashierHome");

                    }
                    else
                    {
                        Response.Write("<script>alert('invalid password or username');</script>");
                        return View();

                    }

                }
                else
                {
                    return View("Error");
                }
            }
            catch(Exception e)
            {
                return View("Error");
            }
        }

        public ActionResult AddCustDet()
        {

            try
            {
               
                    Custdet_1288 obj = new Custdet_1288();
                List<SelectListItem> lst2 = new List<SelectListItem>()
            {
                new SelectListItem() {Text="Vizag",Value="Vizag"},
                new SelectListItem() {Text="Jaipur",Value="Jaipur"},
                 new SelectListItem() {Text="Kochi",Value="Kochi"},
                new SelectListItem() {Text="Amritsar",Value="Amritsar"}
            };

                List<SelectListItem> lst1 = new List<SelectListItem>()

                    {
                    new SelectListItem() {Text="A.P",Value="A.P"},
                    new SelectListItem() {Text="Rajasthan",Value="Rajasthan"},
                    new SelectListItem() {Text="Kerala",Value="Kerala"},
                    new SelectListItem() {Text="Punjab",Value="Punjab"}
            };
                obj.lst2 = lst2;
                obj.lst1 = lst1;
                return View(obj);
              
            }
            catch (Exception e)
            {


                return View("Error");
            }
        }

        [HttpPost]
        public ActionResult AddCustDet(Custdet_1288 obj1/*, string event1, string city1, string city2*/)

        {



            try {

                //if (Session["check"].ToString() != "primeadmin")
                //{
                    List<SelectListItem> lst2 = new List<SelectListItem>()
                    {
                        new SelectListItem() {Text="Vizag",Value="Vizag"},
                        new SelectListItem() {Text="Jaipur",Value="Jaipur"},
                         new SelectListItem() {Text="Kochi",Value="Kochi"},
                        new SelectListItem() {Text="Amritsar",Value="Amritsar"}
                    };

                    List<SelectListItem> lst1 = new List<SelectListItem>()

                            {
                            new SelectListItem() {Text="A.P",Value="A.P"},
                            new SelectListItem() {Text="Rajasthan",Value="Rajasthan"},
                            new SelectListItem() {Text="Kerala",Value="Kerala"},
                            new SelectListItem() {Text="Punjab",Value="Punjab"}
                    };
                    obj1.lst2 = lst2;
                    obj1.lst1 = lst1;

                //    obj1.state = event1;
                //obj1.city = city1 != "--Select--" ? city1 : city2;
                //var errors = ModelState.Values.SelectMany(v => v.Errors);
                if (ModelState.IsValid)
                    {
                        if (!db.Custdet_1288.Select(x => x.custSsnId == obj1.custSsnId).FirstOrDefault())
                        {

                            ObjectParameter objParam = new ObjectParameter("custid", typeof(int));
                            objParam.Value = 0;
                            db.sp_Custdet_1288(objParam, obj1.custSsnId, obj1.custName, obj1.Age, obj1.Address1, obj1.Address2, obj1.city, obj1.state, obj1.DisplayMessage = "Customer added successfully", obj1.AccountStatus = "Active");
                            int custid = (int)objParam.Value;
                            TempData["first"] = "Customer Id " + custid + " added successfully";
                            return RedirectToAction("Viewdet");
                        }
                        else
                        {
                            TempData["exx"] = "enter a unique ssn id";
                            return View("Error");
                        }
                    }
                    else
                        return View();
               }
              //  else
              //  {
                   // return View("login");
              //  }
         //   }
            catch (Exception e)
            {
                TempData["exx"] = "enter a unique ssn id";
                return View("Error");
            }
        }



        public ActionResult Viewdet()
        {
            
                List<Custdet_1288> list1 = db.Custdet_1288.ToList();
                if (list1 != null)
                {
                    return View(list1);
                }
                else
                {
                    ViewBag.Message = "list is empty";
                    return View("Error");
                }
          
        }

        public ActionResult edit_customer(int id)
        {
            //  if (Session["check"].ToString() != "primeadmin")
            // {
            List<SelectListItem> lst2 = new List<SelectListItem>()
            {
                new SelectListItem() {Text="Vizag",Value="Vizag"},
                new SelectListItem() {Text="Jaipur",Value="Jaipur"},
                 new SelectListItem() {Text="Kochi",Value="Kochi"},
                new SelectListItem() {Text="Amritsar",Value="Amritsar"}
            };

            List<SelectListItem> lst1 = new List<SelectListItem>
                    ()
                    {
                    new SelectListItem() {Text="A.P",Value="A.P"},
                    new SelectListItem() {Text="Rajasthan",Value="Rajasthan"},
                    new SelectListItem() {Text="Kerala",Value="Kerala"},
                    new SelectListItem() {Text="Punjab",Value="Punjab"}
            };



            Custdet_1288 objj = db.Custdet_1288.Where(x => x.custid == id).FirstOrDefault();
                ViewBag.one = objj.custName;
                ViewBag.two = objj.Age;
                ViewBag.three = objj.Address1;
                ViewBag.four = objj.Address2;
            objj.lst2 = lst2;
            objj.lst1 = lst1;

            if (objj != null)
                    return View(objj);
                else
                    return View("Error");
           // }
          //  else
            //{
                //return View("login");
            //}
        }

        [HttpPost]
        public ActionResult edit_customer(Custdet_1288 objj/*,string event1, string city1, string city2*/)
        {
            try {
                //objj.state = event1;
                //objj.city = city1 != "--Select--" ? city1 : city2;
                //var errors = ModelState.Values.SelectMany(v => v.Errors);
                if (ModelState.IsValid)
                {
                    ObjectParameter para = new ObjectParameter("custid", typeof(int));
                    para.Value = 0;
                    int rows = db.update_customer(para, objj.custSsnId, objj.custName, objj.Age, objj.Address1, objj.Address2, objj.city, objj.state);


                    if (rows > 0)
                    {
                        TempData["second"] = "Edit successful";
                        return RedirectToAction("Viewdet");
                    }
                    else
                    {
                        ViewBag.Message = "Edit Failed";
                        return View("Error");
                    }
                }
                else
                {
                    return View("Error");
                }
            }
            catch(Exception e)
            {
                return View("Error");
            }
           

        }

        public ActionResult Delete(int id)
        {
            try
            {
                   Custdet_1288 cst = db.Custdet_1288.Where(x => x.custid == id).FirstOrDefault();
                    return View(cst);
             


            }
            catch (Exception e)
            {
                return View("Error");
            }
        }

        [HttpPost]
        public ActionResult Delete(Custdet_1288 cst)
        {
             
                try {
               
                    castleaccount33 ccc = db.castleaccount33.Where(x => x.CustomerId == cst.custid).FirstOrDefault();
                    if (ccc != null)
                    {

                        TempData["not"] = "Delete Operation unSuccessful as customer has an account";
                        return RedirectToAction("Viewdet");

                    }
                    else
                    {


                        int rows = db.delete_castle(cst.custid);


                        if (rows > 0)
                        {
                            TempData["second"] = "Delete Operation Successful";
                            return RedirectToAction("Viewdet");
                        }
                        else
                        {
                            ViewBag.Message = "Delete Operation Failed";
                            return View("Error");
                        }

                    }
          
            }catch(Exception e)
            {

                ViewBag.Message = "Delete Operation Failed";
                return View("Error");
            }
        }
        public ActionResult AddAccount()
        {
            try {
               
                    castleaccount33 csob = new castleaccount33();
                    List<SelectListItem> acctype = new List<SelectListItem>()
            {



                new SelectListItem() {Text="Current",Value="Current"},
                new SelectListItem() {Text="Savings",Value="Savings"},

            };
                    List<SelectListItem> cidlist = new List<SelectListItem>();

                    cidlist = db.Custdet_1288.Select(x => new SelectListItem { Text = x.custid.ToString(), Value = x.custid.ToString() }).ToList();



                    csob.cidlist = cidlist;
                    //csob.amount = 0;
                    //csob.depositamount = 0;
                    //csob.withdrawlamount = 0;
                    csob.acctype = acctype;
                    return View(csob);
             
            }
            catch(Exception e)
            {
                return View("Error");
            }
        }

        [HttpPost]
        public ActionResult AddAccount(castleaccount33 csob/*,string CustomerId,string AccountType,string Balance*/)

        {
            try {
              
                    //csob.amount = 0;
                    //csob.depositamount = 0;
                    //csob.withdrawlamount = 0;

                   // castleaccount33 csob = new castleaccount33();
                    //if (ModelState.IsValid)
                    //{
                    ObjectParameter flag = new ObjectParameter("flagg", typeof(int));
                    flag.Value = 0;
              
                db.addaccount33(csob.CustomerId, csob.AccountType, csob.ShowMessage = "Account Creation successful", csob.AccountStatus = "Active", csob.Balance, flag);

                if (Convert.ToInt16(flag.Value) == 1)
                    {
                      //  db.addaccount33(csob.CustomerId, csob.AccountType, csob.ShowMessage = "Account Creation successful", csob.AccountStatus = "Active", csob.Balance, flag);
                        TempData["acc"] = "Account added successfully";
                        return RedirectToAction("ViewAccount");
                    }
                    else if (Convert.ToInt16(flag.Value) == 0)
                    {
                        TempData["asc"] = "Account cannot be added as CustomerId is inactive";
                        return RedirectToAction("ViewAccount");
                    }
                else if (Convert.ToInt16(flag.Value) == 2)
                {
                    TempData["sim"] = "Account cannot be added as given CustomerId already has an account of similar type ";
                    return RedirectToAction("ViewAccount");
                }
                return View();
                    //}
                    //else
                    //{
                    //    castleaccount33 csob1 = new castleaccount33();
                    //    List<SelectListItem> acctype = new List<SelectListItem>()
                    //{



                    //    new SelectListItem() {Text="Current",Value="Current"},
                    //    new SelectListItem() {Text="Savings",Value="Savings"},

                    //};
                    //    List<SelectListItem> cidlist = new List<SelectListItem>();

                    //    cidlist = db.Custdet_1288.Select(x => new SelectListItem { Text = x.custid.ToString(), Value = x.custid.ToString() }).ToList();



                    //    csob1.cidlist = cidlist;

                    //    csob1.acctype = acctype;
                    //    return View(csob1);
                    //}
           
            }
            catch(Exception e)
            {
                return View("Error");
            }

        }
        public ActionResult ViewAccount()
        {
            try {
                
                    List<castleaccount33> listt = db.castleaccount33.ToList();
                    if (listt != null)
                    {
                        return View(listt);
                    }
                    else
                    {
                        ViewBag.Message = "list is empty";
                        return View("Error");
                    }
                
              
            }
            catch(Exception e)
            {
                return View("Error");
            }
        }
        public ActionResult DeleteAccount(int id)
        {

            castleaccount33 cstl = db.castleaccount33.Where(x => x.AccountId == id).FirstOrDefault();
            return View(cstl);

        }

        [HttpPost]
        public ActionResult DeleteAccount(castleaccount33 cstl)
        {
            try {
                castleaccount33 tt = db.castleaccount33.Where(x => x.AccountId == cstl.AccountId).FirstOrDefault();
                if (tt != null && tt.Balance != 0)
                {
                    TempData["notdel"] = "Delete Operation unSuccessful as acount has balance";
                    return RedirectToAction("ViewAccount");

                }
                else
                {
                    int rows = db.deleteaccount33(cstl.AccountId);


                    if (rows > 0)
                    {
                        TempData["delacc"] = "Account Deleted  Successfully";
                        return RedirectToAction("ViewAccount");
                    }
                    else
                    {
                        ViewBag.Message = "Delete Operation Failed";
                        return View("Error");
                    }
                }
            }
            catch(Exception e)
            {
                return View("Error");
            }
        }
        public ActionResult signout()
        {
            Session["check"] = null;

            return View();
        }
        [HttpPost]
        public ActionResult signout(string btn)
        {
            RedirectToAction("login");
            return View();
        }

        public ActionResult search()
        {
            return View();
        }
        [HttpPost]
        public ActionResult search(FormCollection a)
        {
            try {
                int abb = int.Parse(a["num"]);
                Session["abb"] = abb;
                return RedirectToAction("searchdetails");
            }
            catch(Exception e)
            {
                return View("Error");
            }
            
        }
        public ActionResult searchdetails()
        {
            int abb = int.Parse(Session["abb"].ToString());
            Custdet_1288 cust = db.Custdet_1288.Where(x => x.custid == abb).FirstOrDefault();
            ViewBag.cid = cust.custid;
            ViewBag.ssnid = cust.custSsnId;
            ViewBag.nm = cust.custName;
            ViewBag.ag = cust.Age;
            ViewBag.ad = cust.Address1;
            ViewBag.add = cust.Address2;
            return View();
        }
        public ActionResult searchaccount()
        {
            return View();
        }
        [HttpPost]
        public ActionResult searchaccount(FormCollection b)
        {
            try {
                int ac = int.Parse(b["numm"]);
                Session["ac"] = ac;
                return RedirectToAction("searchaccountdetails");
            }
            catch(Exception e)
            {
                return View("Error");
            }
        }
        public ActionResult searchaccountdetails()
        {
            int ac = int.Parse(Session["ac"].ToString());
            castleaccount33 cstt = db.castleaccount33.Where(x => x.AccountId == ac).FirstOrDefault();
            ViewBag.actid = cstt.AccountId;
            ViewBag.csid = cstt.CustomerId;
            ViewBag.asts = cstt.AccountStatus;
            ViewBag.amt = cstt.Balance;
            return View();
        }
        public ActionResult deposit()
        {

            return View();

        }
        [HttpPost]
        public ActionResult deposit(FormCollection c)
        {
           
                int dp = int.Parse(c["nm"]);
                Session["dp"] = dp;
                return RedirectToAction("depositdetails");
            
           
        }
        static castleaccount33 ct = new castleaccount33();
        public ActionResult depositdetails()
        {
            int dp = int.Parse(Session["dp"].ToString());
            ct = db.castleaccount33.Where(x => x.AccountId == dp).FirstOrDefault();
            ViewBag.actid = ct.AccountId;
            ViewBag.csid = ct.CustomerId;
            ViewBag.actp = ct.AccountType;
            ViewBag.amt = ct.Balance;
            return View(ct);
        }
        [HttpPost]
        public ActionResult depositdetails(string n)
        {
            try
            {


                castleaccount33 tt = db.castleaccount33.Where(x => x.AccountId == ct.AccountId).FirstOrDefault();
                if (tt != null && tt.AccountStatus == "Inactive")
                {
                    TempData["in"] = "Deposit not Successful as account is inactive";
                    return RedirectToAction("ViewTransaction");

                }
                else
                {
                    int ab = int.Parse(n);
                    ct.depositamount = ab;
                    ObjectParameter para = new ObjectParameter("TransactionId", typeof(int));
                    para.Value = 0;
                    db.deposit(ct.AccountId, "Deposit Successful", ct.depositamount, para);
                    TempData["dep"] = "Deposit Successful";
                    return RedirectToAction("ViewTransaction");
                }
            }
            catch(Exception e)
            {
                return View("Error");
            }
        }
        public ActionResult withdrawl()
        {

            return View();

        }
        [HttpPost]
        public ActionResult withdrawl(FormCollection d)
        {
            try
            {


                int dp = int.Parse(d["nm"]);
                Session["dp"] = dp;
                return RedirectToAction("withdrawldetails");
            }
            catch(Exception e)
            {
                return View("Error");
            }
        }
        public ActionResult withdrawldetails()
        {
            int dp = int.Parse(Session["dp"].ToString());
            ct = db.castleaccount33.Where(x => x.AccountId == dp).FirstOrDefault();
            ViewBag.actid = ct.AccountId;
            ViewBag.csid = ct.CustomerId;
            ViewBag.actp = ct.AccountType;
            ViewBag.amt = ct.Balance;
            return View(ct);
        }
        [HttpPost]
        public ActionResult withdrawldetails(string n)
        {
            try {

                castleaccount33 tt = db.castleaccount33.Where(x => x.AccountId == ct.AccountId).FirstOrDefault();
                if (tt != null && tt.AccountStatus == "Inactive")
                {
                    TempData["fll"] = "Withdrawl fail as account is inactive";
                    return RedirectToAction("ViewTransaction");

                }
                else
                {
                    int ab = int.Parse(n);
                    ct.withdrawlamount = ab;
                    ObjectParameter para = new ObjectParameter("flag", typeof(int));
                    para.Value = 0;
                    ObjectParameter opara = new ObjectParameter("TransactionId", typeof(int));
                    opara.Value = 0;
                    db.withdrawl(ct.AccountId, "Withdrawl Successful", ct.withdrawlamount, para, opara);
                    if (Convert.ToInt16(para.Value) == 1)

                    {
                        TempData["with"] = "Withdrawl Successful";
                        return RedirectToAction("ViewTransaction");
                    }
                    else if (Convert.ToInt16(para.Value) == 0)
                    {
                        TempData["fail"] = "Withdrawl fail";
                        return RedirectToAction("ViewTransaction");
                    }
                }
                return View();
            }
            catch(Exception e)
            {
                return View("Error");
            }
        }
        public ActionResult ViewTransaction()
        {
            List<transaction33> tlist = db.transaction33.ToList();
            if (tlist != null)
            {
                return View(tlist);
            }
            else
            {
                ViewBag.Message = "list is empty";
                return View("Error");
            }
        }
        public ActionResult Transfer()
        {
            castleaccount33 acob = new castleaccount33();
            List<SelectListItem> srcac = new List<SelectListItem>();
            srcac = db.castleaccount33.Select(x => new SelectListItem { Text = x.AccountId.ToString(), Value = x.AccountId.ToString() }).ToList();

            List<SelectListItem> tgtac = new List<SelectListItem>();
            tgtac = db.castleaccount33.Select(x => new SelectListItem { Text = x.AccountId.ToString(), Value = x.AccountId.ToString() }).ToList();

            acob.srcac = srcac;
            acob.tgtac = tgtac;
            return View(acob);
        }
        [HttpPost]
        public ActionResult Transfer(castleaccount33 acob)
        {

            //castleaccount33 tt = db.castleaccount33.Where(x => x.srcac == ct.srcac).FirstOrDefault();
            //castleaccount33 tt1 = db.castleaccount33.Where(x => x.tgtac == ct.tgtac).FirstOrDefault();


            //if (tt != null && tt.AccountStatus == "Inactive" && tt1 != null && tt1.AccountStatus == "Inactive")
            //{
            //    TempData["lfl"] = "Transfer failed as account inactive";
            //    return RedirectToAction("ViewTransfer");


            //}
            //else
            //{
            try {
                int id1 = acob.accid1;
                int id2 = acob.accid2;
                Session["id1"] = id1;
                Session["id2"] = id2;
                castleaccount33 ac1 = db.castleaccount33.Where(x => x.AccountId == id1).FirstOrDefault();
                castleaccount33 ac2 = db.castleaccount33.Where(x => x.AccountId == id2).FirstOrDefault();
                int bal1 = int.Parse(ac1.Balance.ToString());
                int bal2 = int.Parse(ac2.Balance.ToString());
                Session["bal1"] = bal1;
                Session["bal2"] = bal2;
                ObjectParameter para = new ObjectParameter("transid", typeof(int));
                para.Value = 0;
                ObjectParameter flag = new ObjectParameter("flag", typeof(int));
                flag.Value = 0;
                db.transfermoney(acob.accid1, acob.accid2, acob.amount, acob.ShowMessage = "Transfer successful", para, flag);
                int transid = int.Parse((para.Value).ToString());
                if (Convert.ToInt16(flag.Value) == 1)
                {
                    TempData["sc"] = "<script>alert('Transaction successful, Transaction Id is" + transid + "');</script>";
                    return RedirectToAction("ViewTransfer");
                }
                else if (Convert.ToInt16(flag.Value) == 2)
                {
                    TempData["fl"] = "<script>alert('Transaction failed because of insufficient balance');</script>";
                    //Response.Write("<script>alert('Transaction failed because of insufficient balance');</script>");
                    return RedirectToAction("ViewTransfer");
                }
                else if (Convert.ToInt16(flag.Value) == 0)
                {
                    TempData["sm"] = "<script>alert('Transaction failed as source and target account are same';);</script>";
                    return RedirectToAction("ViewTransfer");
                }
                else if (Convert.ToInt16(flag.Value) == 3)
                {
                    TempData["lfl"] = "Transfer failed as account inactive";
                    return RedirectToAction("ViewTransfer");
                }
                return View();
            }
            catch(Exception e)
            {
                return View("Error");
            }
            

        }
        public ActionResult ViewTransfer()
        {
            int id1 = int.Parse(Session["id1"].ToString());
            int id2 = int.Parse(Session["id2"].ToString());
            int bal1 = int.Parse(Session["bal1"].ToString());
            int bal2 = int.Parse(Session["bal2"].ToString());
            castleaccount33 ob1 = db.castleaccount33.Where(x => x.AccountId == id1).FirstOrDefault();
            castleaccount33 ob2 = db.castleaccount33.Where(x => x.AccountId == id2).FirstOrDefault();
            ViewBag.src = ob1.AccountId;
            ViewBag.oldbs = bal1;
            ViewBag.newbs = ob1.Balance;
            ViewBag.tgt = ob2.AccountId;
            ViewBag.oldbt = bal2;
            ViewBag.newbt = ob2.Balance;
            return View();
        }



    }
}

