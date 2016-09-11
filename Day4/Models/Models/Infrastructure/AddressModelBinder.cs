using System;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;
using System.Web;
using System.Web.Mvc;
using Models.Models;

namespace Models.Infrastructure
{
    public class AddressModelBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            Address address = bindingContext.Model as Address ?? new Address();
            address.City = GetValue(bindingContext, "City");
            address.Country = GetValue(bindingContext, "Country");
            address.Line1 = GetValue(bindingContext, "Line1");
            address.Line2 = GetValue(bindingContext, "Line2");
            address.PostalCode = GetValue(bindingContext, "PostalCode");

            address.AddressSummary = GetAddressSummary(postalCode: address.PostalCode, 
                line: address.Line1, city: address.City);

            return address;
        }

        private string GetValue(ModelBindingContext context, string name)
        {            
            ValueProviderResult result = context.ValueProvider.GetValue("Address." + name);

            if (result != null)
            {
                switch(name)
                {
                    case "Line2":
                        {
                            if (result.AttemptedValue.ToLower().Contains("po box") || result.AttemptedValue == string.Empty)
                            {
                                return "<not defined>";
                            }
                            break;                            
                        }
                    case "PostalCode":
                        {
                            if (result.AttemptedValue.Length < 6)
                            {
                                return "<not defined>";
                            }
                            break;
                        }
                    case "Line1":
                        {
                            if (result.AttemptedValue.ToLower().Contains("po box"))
                            {
                                return "<not defined>";
                            }
                            break;
                        }                       
                }
                return result.AttemptedValue;
            }

            return "<not defined>";
        }

        private string GetAddressSummary(string postalCode, string city, string line)
        {
            if (IsValidForAddress(postalCode) && IsValidForAddress(city) && IsValidForAddress(line))
            {
                return String.Format("{0} {1}, {2}", postalCode, city, line);
            }

            return "No personal address";
        }

        private bool IsValidForAddress(string item)
        {
            if (string.IsNullOrEmpty(item) || item.Contains("<not defined>"))
                return false;
            else
                return true;
        }
    }
}