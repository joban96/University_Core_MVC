namespace University_Core_MVC.Models
{//An allocation.
    public class Allocation
    {
        //Primary key
        public int Id { get; set; }

        //Department id
        public int DepartmentId { get; set; }

        //Lecturer id 
        public int LecturerId { get; set; }

        //Module Id
        public int ModuleId { get; set; }


        //Department reference
        public Department Department { get; set; }

        //Module reference 
        public Module Module { get; set; }

        //Lecturer reference
        public Lecturer Lecturer { get; set; }

    }
}
