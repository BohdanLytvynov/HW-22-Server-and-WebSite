using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HW21_MVC.Functions
{
    public class CommonFunctions
    {
        public static void ParseErrors(List<ModelStateEntry> errorsEntry,
            List<string> errorList)
        {
            foreach (var item in errorsEntry)
            {
                foreach (var eror in item.Errors)
                {
                    errorList.Add(eror.ErrorMessage);
                }
            }
        }
    }
}
