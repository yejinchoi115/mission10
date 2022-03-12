using System;
namespace m10.Models.ViewModels
{
    public class PageInfo
    {
        public int TotalNumProjects { get; set; }
        public int ProjectsPerPage { get; set; }
        public int Currentpage { get; set; }

        //Figure out how many pages we neeed
        public int TotalPages => (int)Math.Ceiling((double)TotalNumProjects / ProjectsPerPage); //casting: () infront of variable
    }
}
