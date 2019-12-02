using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using CFMData;
using CFMData.Collections.Custom;

namespace CFMWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme, Policy = "BudgetUsers")]
    public class BudgetController : BaseController
    {
        [HttpGet("GetHomeBudget/{homeID}/{budgetID?}")]
        public JArray Get(int homeID, int? budgetID)
        {
            Dictionary<string, object> commandParams = new Dictionary<string, object>();


            commandParams.Add("p_HomeID", homeID);
            if (budgetID.HasValue)
            {
                commandParams.Add("p_BudgetID", budgetID.Value);
            }


            DynamicList lst = DynamicList.GetData("spCFM_BudgetDetails_Home", commandParams);
            if (lst.Count > 0)
            {
                return (JArray) lst[0].GetValue("Data");
            }

            return null;
        }

        [HttpGet("GetBudget/{budgetID}")]
        public JArray GetBudget(int budgetID)
        {
            Dictionary<string, object> commandParams = new Dictionary<string, object>();

            commandParams.Add("p_BudgetID", budgetID);
            DynamicList lst = DynamicList.GetData("spCFM_BudgetLine_Details", commandParams);
            return lst.GetJson();

        }

        [HttpGet("GetHomeBudgetLineCategories")]
        public List<BudgetLineCategoryDTO> GetHomeBudgetLineCategories(int budgetID)
        {
            BudgetLineCategoryCriteria criteria = new BudgetLineCategoryCriteria();
            criteria.IsActive = true;
            return BudgetLineCategoryList.GetByCriteria(criteria).CurrentDTO;

        }

        [HttpPost]
        public bool Post([FromBody] BudgetDTO data)
        {
            if (data != null)
            {
                Budget budget = Budget.NewBudget();
                if (data.BudgetID > 0)
                {
                    budget = Budget.GetByBudgetID(data.BudgetID);
                }
                else
                {
                    budget.CreatedOn = DateTime.Now;
                    budget.CreatedBy = CurrentUserID;

                }

                data.CopyDTO(budget);
                if (budget.IsNew)
                {
                    budget.IsActive = true;
                }
                else
                {
                    if (budget.IsDirty)
                    {
                        budget.UpdatedOn = DateTime.Now;
                        budget.UpdatedBy = CurrentUserID;

                    }
                }

                foreach (BudgetLineDTO dataBudgetLine in data.BudgetLines)
                {
                    BudgetLine budgetLine =
                        budget.BudgetLines.FirstOrDefault(x => x.BudgetLineID == dataBudgetLine.BudgetLineID);
                    if (budgetLine == null)
                    {
                        budgetLine = BudgetLine.NewBudgetLine();
                        budgetLine.CreatedOn = DateTime.Now;
                        budgetLine.CreatedBy = CurrentUserID;
                        budget.BudgetLines.Add(budgetLine);
                    }

                    dataBudgetLine.CopyDTO(budgetLine);
                    if (budgetLine.IsNew)
                    {
                        budgetLine.IsActive = true;
                    }
                    else
                    {
                        if (budgetLine.IsDirty)
                        {
                            budgetLine.UpdatedOn = DateTime.Now;
                            budgetLine.UpdatedBy = CurrentUserID;

                        }
                    }

                }

                budget.Save();
                return true;
            }


            return false;
        }



    }
}