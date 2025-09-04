internal class Department
{
    public int DepartmentId { get; set; }
    public decimal Financing { get; set; }
    public string Name { get; set; }

    public List<Teacher> Teachers { get; set; }
}
