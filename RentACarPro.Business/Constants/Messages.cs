using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace RentACarPro.Business.Constants
{
    internal static class Messages
    {
        public const string AddSuccess = "Item added successfully.";
        public const string DeleteSuccess = "Item removed successfully.";
        public const string UpdateSuccess = "Item modified successfully.";
        public const string AllRecieved = "All items were received.";
        public const string ItemRecieved = "Item was received.";
        public const string NullRecieved = "Item was received but it has null value.";

        public const string ErrorCarModelYear = "Car model year must be lower than current year.";
        public const string CarImageLimitExceeded = "Image count limit exceeded for the car.";

        public const string UserAlreadyExists = "User has already exists.";
        public const string UserNotFound = "User has not found.";
        public const string LoginError = "Invalid login. Email or password is wrong.";
        public const string LoginSuccess = "Login has been successful.";
        public const string RegisterSuccess = "User has been registered.";
        public const string AccessTokenCreated = "Access token has been created.";

        public const string AuthorizationDenied = "You have no access for this operation.";
    }
}
