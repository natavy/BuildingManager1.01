//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Building.Manager.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class OfferService
    {
        public int Id { get; set; }
        public int ServiceId { get; set; }
        public int OfferId { get; set; }
        public int Quantity { get; set; }
        public decimal Amount { get; set; }
    
        public virtual Offer Offer { get; set; }
        public virtual Service Service { get; set; }
    }
}
