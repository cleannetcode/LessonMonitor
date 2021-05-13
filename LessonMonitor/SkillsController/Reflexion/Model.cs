namespace SkillsController.Reflexion
{
    public class Model
    {
        private string _name = "Class reflexion";

        public void SetName(string name)
        {
            _name = name;
        }
        public string GetName()
        {
            return _name;
        }
    }
}