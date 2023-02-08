using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceV2.Shared.Utilities.Results.ComplexTypes
{
    public enum EAuthority
    {
        Admin = 0,       //Admin
        Seller = 1,      //Seller
        Buyer = 2,       //Buyer
        VIPSeller = 3,   //Very Important Person Seller
        VIPBuyer = 4,    //Very Important Person Buyer
        King = 5         //Very Important Than All
    }
}
