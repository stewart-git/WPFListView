namespace MyListView
{
    internal class StaffDetails
    {
        private string _fullName;
        private string _position;
        private int _salary;

        public string GetName() 
        {
            return _fullName; 
        }
        public void SetFullName(string fullName)
        {
            _fullName = fullName;
        }
        public string GetPosition()
        {
            return _position;
        }
        public void SetPosition(string position)
        {
            _position = position;
        }
        public int GetSalary()
        {
            return _salary;
        }
        public void SetSalay(int salary)
        {
            _salary = salary;
        }
    }
}
