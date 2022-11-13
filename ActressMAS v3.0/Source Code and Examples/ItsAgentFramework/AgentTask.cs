namespace ItsAgentFramework
{
    public abstract class AgentTask
    {
        private bool _isValidated = false;
        public List<Type> Skills {
            get
            {
                if (!_isValidated)
                    Validate();
                return Skills;
            }
        }

        private void Validate()
        {
            foreach (var skill in Skills) 
            { 
                if(skill.BaseType != typeof(Skill))
                    throw new InvalidCastException("Task can only contain types derived from Skill class.");
            }
            _isValidated = true;
        }
    }
}