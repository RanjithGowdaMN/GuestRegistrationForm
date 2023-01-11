namespace GuestUserModels
{
    class GuestModelBase
    {
        public string OfficalID { get; set; }
        public string ExpiryDate { get; set; }
        public string VisitorCompanyName { get; set; }
        public string VisitorFirstName { get; set; }
        public string VisitorSecondName { get; set; }
        public string VisitorIDBadgeNo { get; set; }
        public string PurposeOfVisit { get; set; }
        public string DateOfVisit { get; set; }
        public string VisitorArraival { get; set; }
        public string VisitorDeparture { get; set; }
        public string EmployeeToVisitName { get; set; }
        public string EmployeeToVisitId { get; set; }

    }
}
