//------------------------------------------------------------------------------
// <auto-generated>
//     這個程式碼是由範本產生。
//
//     對這個檔案進行手動變更可能導致您的應用程式產生未預期的行為。
//     如果重新產生程式碼，將會覆寫對這個檔案的手動變更。
// </auto-generated>
//------------------------------------------------------------------------------

namespace HRMS
{
    using System;
    using System.Collections.Generic;
    
    public partial class LeaveApplication
    {
        public int ApplyNumber { get; set; }
        public int EmployeeID { get; set; }
        public System.DateTime ApplyDate { get; set; }
        public Nullable<int> LeaveCategory { get; set; }
        public Nullable<System.DateTime> LeaveStartTime { get; set; }
        public Nullable<System.DateTime> LeaveEndTime { get; set; }
        public string Reason { get; set; }
        public Nullable<int> CheckStatus { get; set; }
    
        public virtual CheckStatus CheckStatus1 { get; set; }
        public virtual Leave Leave { get; set; }
        public virtual User User { get; set; }
    }
}
