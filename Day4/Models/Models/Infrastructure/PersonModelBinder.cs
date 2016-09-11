using Models.Models;
using System;
using System.Globalization;
using System.Web.Mvc;

namespace Models.Infrastructure
{
    public class PersonModelBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            Person personModel = (Person)bindingContext.Model ?? new Person();
            personModel.FirstName = GetValue(bindingContext, "FirstName");
            personModel.LastName = GetValue(bindingContext,  "LastName");
            personModel.BirthDate = (DateTime)GetDataOfBirth(controllerContext, bindingContext);
            personModel.Role = (Role)GetRole(controllerContext, bindingContext); 
            personModel.HomeAddress = (Address)(new AddressModelBinder()).BindModel(controllerContext, bindingContext);
            return personModel;
        }

 
        private string GetValue(ModelBindingContext context, string name)
        {
            name = (context.ModelName == "" ? ""
                : context.ModelName + ".") + name;

            ValueProviderResult result = context.ValueProvider.GetValue(name);

            if (result == null || result.AttemptedValue == "")
            {
                return "<Not Specified>";
            }

            return result.AttemptedValue;        
        }

        private Role GetRole(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            string role= GetValue(bindingContext, "Role");

            if (controllerContext.HttpContext.Request.IsLocal && role == "admin")
            {
                return Role.Admin;
            }
            else if (role.ToLower() == "admin" || role.ToLower() == "user")
            {
                return Role.User;
            }          
            else
            {
                return Role.Guest;
            }           
        }

        private DateTime GetDataOfBirth(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {            
            DateTime dateOfBirth;
            DateTime.TryParseExact(GetValue(bindingContext, "BirthDate"), "dd##M**yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dateOfBirth);
            return dateOfBirth;
        }                
    }
}